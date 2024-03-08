using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Tests.Builders;
using Xunit;
using Xunit.Abstractions;
using Assert = MicrowaveSystem.Tests.Commom.Assert;

namespace MicrowaveSystem.Tests.Entities;

public class DigitalMicrowaveTest
{
    private readonly DigitalMicrowaveBuilder _builder;
    private readonly ITestOutputHelper _output;

    public DigitalMicrowaveTest(ITestOutputHelper output)
    {
        _builder = new DigitalMicrowaveBuilder();
        _output = output;
    }

    [Fact(DisplayName = "#01 - Must create a Microwave")]
    public void MustCreateAClient()
    {
        var builder = _builder.New().Build();
        var microwave = _builder.Build();

        microwave.Validate().Wait();
        microwave.ValidationResult = builder.ValidationResult;
        Assert.Equal<DigitalMicrowave>(builder, microwave, _output);
    }

    #region Template
    [Fact(DisplayName = "#02 - Must create a template - null")]
    public void MustCreateMicrowave_WithoutTemplate()
    {
        var microwave = _builder.New().Build();
        microwave.Template = null;

        microwave.Potency = Core.Enumerators.Potency.Three;
        microwave.TimeLeft = 98;

        microwave.Validate().Wait();
        Assert.True(microwave.IsValid,
                    string.Join(Environment.NewLine,
                    microwave.ValidationResult.Errors), _output, microwave);
    }

    [Fact(DisplayName = "#03 - Must create a template")]
    public void MustCreateMicrowave_WithTemplate()
    {
        var microwave = _builder.New().Build();
        microwave.Template = microwave.Template;

        microwave.Potency = Core.Enumerators.Potency.Three;
        microwave.TimeLeft = 98;

        microwave.Validate().Wait();
        Assert.True(microwave.IsValid,
                    string.Join(Environment.NewLine,
                    microwave.ValidationResult.Errors), _output, microwave);
    }

    #endregion

    #region TimeLeft

    [Fact(DisplayName = "#04 - Must create a time valid")]
    public void MustCreateMicrowave_WithTimeValid()
    {
        var microwave = _builder.New().Build();

        microwave.Validate().Wait();
        Assert.True(microwave.IsValid,
                    string.Join(Environment.NewLine,
                    microwave.ValidationResult.Errors), _output, microwave);
    }

    [Fact(DisplayName = "#05 - Must create a time ivalid")]
    public void MustCreateMicrowave_WithTimeInvalid()
    {
        var microwave = _builder.New().Build();
        microwave.TimeLeft = 134;

        microwave.Validate().Wait();
        Assert.False(microwave.IsValid,
                    string.Join(Environment.NewLine,
                    microwave.ValidationResult.Errors), _output, microwave);
    }
    #endregion

    #region Potency

    [Fact(DisplayName = "#06 - Must create a Potency valid")]
    public void MustCreateMicrowave_WithPotencyValid()
    {
        var microwave = _builder.New().Build();

        microwave.Validate().Wait();
        Assert.True(microwave.IsValid,
                    string.Join(Environment.NewLine,
                    microwave.ValidationResult.Errors), _output, microwave);
    }

    [Fact(DisplayName = "#07 - Must create a Potency ivalid")]
    public void MustCreateMicrowave_WithPotencyInvalid()
    {
        var microwave = _builder.New().Build();
        microwave.Potency = Core.Enumerators.Potency.Eleven;

        microwave.Validate().Wait();
        Assert.False(microwave.IsValid,
                    string.Join(Environment.NewLine,
                    microwave.ValidationResult.Errors), _output, microwave);
    }
    #endregion
}