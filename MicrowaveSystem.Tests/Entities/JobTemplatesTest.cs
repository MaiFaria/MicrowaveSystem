using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Tests.Builders;
using Xunit;
using Xunit.Abstractions;
using Assert = MicrowaveSystem.Tests.Commom.Assert;

namespace MicrowaveSystem.Tests.Entities;

public class JobTemplatesTest
{
    private readonly JobTemplateBuilder _builder;
    private readonly ITestOutputHelper _output;

    public JobTemplatesTest(ITestOutputHelper output)
    {
        _builder = new JobTemplateBuilder();
        _output = output;
    }

    [Fact(DisplayName = "#01 - Must create a JobTemplate")]
    public void MustCreateAClient()
    {
        var builder = _builder.New().Build();
        var template = _builder.Build();

        template.Validate().Wait();
        template.ValidationResult = builder.ValidationResult;
        Assert.Equal<JobTemplate>(builder, template, _output);
    }

    #region Instructions

    [Fact(DisplayName = "#02 - Must create a Instructions not null")]
    public void JobTemplate_InstructionsNotNull()
    {
        var template = _builder.New().Build();
        template.Instructions = template.Instructions;

        template.Validate().Wait();
        Assert.True(template.IsValid,
                    string.Join(Environment.NewLine,
                    template.ValidationResult.Errors), _output, template);
    }

    [Fact(DisplayName = "#03 - Must create a Instructions with zero")]
    public void JobTemplate_InstructionsWithZero()
    {
        var template = _builder.New().Build();
        template.Instructions = "0";

        template.Validate().Wait();
        Assert.True(template.IsValid,
                    string.Join(Environment.NewLine,
                    template.ValidationResult.Errors), _output, template);
    }
    #endregion

}

