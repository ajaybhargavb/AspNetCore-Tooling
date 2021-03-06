// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace Microsoft.AspNetCore.Razor.Language.IntegrationTests
{
    public class ComponentBindIntegrationTest : RazorIntegrationTestBase
    {
        internal override string FileKind => FileKinds.Component;

        internal override bool UseTwoPhaseCompilation => true;

        [Fact]
        public void BindDuplicates_ReportsDiagnostic()
        {
            // Arrange
            AdditionalSyntaxTrees.Add(Parse(@"
using System;
using Microsoft.AspNetCore.Components;

namespace Test
{
    [BindElement(""div"", ""value"", ""myvalue2"", ""myevent2"")]
    [BindElement(""div"", ""value"", ""myvalue"", ""myevent"")]
    public static class BindAttributes
    {
    }
}"));

            // Act
            var result = CompileToCSharp(@"
@addTagHelper *, TestAssembly
<div bind-value=""@ParentValue"" />
@functions {
    public string ParentValue { get; set; } = ""hi"";
}");

            // Assert
            var diagnostic = Assert.Single(result.Diagnostics);
            Assert.Equal("BL9989", diagnostic.Id);
            Assert.Equal(
                "The attribute 'bind-value' was matched by multiple bind attributes. Duplicates:" + Environment.NewLine +
                "Test.BindAttributes" + Environment.NewLine +
                "Test.BindAttributes",
                diagnostic.GetMessage());
        }

        [Fact]
        public void BindFallback_InvalidSyntax_TooManyParts()
        {
            // Arrange & Act
            var generated = CompileToCSharp(@"
@addTagHelper *, TestAssembly
<input type=""text"" bind-first-second-third=""Text"" />
@functions {
    public string Text { get; set; } = ""text"";
}");

            // Assert
            var diagnostic = Assert.Single(generated.Diagnostics);
            Assert.Equal("BL9991", diagnostic.Id);
        }

        [Fact]
        public void BindFallback_InvalidSyntax_TrailingDash()
        {
            // Arrange & Act
            var generated = CompileToCSharp(@"
@addTagHelper *, TestAssembly
<input type=""text"" bind-first-=""Text"" />
@functions {
    public string Text { get; set; } = ""text"";
}");

            // Assert
            var diagnostic = Assert.Single(generated.Diagnostics);
            Assert.Equal("BL9991", diagnostic.Id);
        }

        [Fact]
        public void Bind_InvalidUseOfDirective_DoesNotThrow()
        {
            var generated = CompileToCSharp(@"
@addTagHelper *, TestAssembly
<input type=""text"" bind=""@page"" />
@functions {
    public string page { get; set; } = ""text"";
}");

            // Assert
            Assert.Collection(
                generated.Diagnostics,
                d => Assert.Equal("RZ2005", d.Id),
                d => Assert.Equal("RZ1011", d.Id));
        }
    }
}
