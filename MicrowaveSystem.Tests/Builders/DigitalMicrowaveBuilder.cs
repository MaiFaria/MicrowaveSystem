using Bogus;
using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Tests.Commom;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MicrowaveSystem.Tests.Builders;

public class DigitalMicrowaveBuilder
{
    private readonly Faker _faker;

    public JobTemplate? Template { get; private set; }
    public TimeSpan Timer { get; internal set; }
    public string? Instruction { get; internal set; }
    public Potency Potency { get; set; }
    public short TimeLeft { get; set; }
    public ValidationResult ValidationResult { get; set; } = new();

    public DigitalMicrowaveBuilder()
        => _faker = FakerBuilder.New().Build();

    public DigitalMicrowaveBuilder New()
    {
        Template = _faker.GetTemplate();
        Timer = new TimeSpan();
        Instruction = _faker.Random.AlphaNumeric(100);
        ValidationResult = new ValidationResult();
        Potency = _faker.GetPotency();
        TimeLeft = _faker.Random.Short(1, 120);

        return this;
    }

    public DigitalMicrowave Build()
    {
        var result = new DigitalMicrowave();

        if (Template != null)
            result.Template = Template;

        if (Timer != null)
            result.Timer = Timer;

        if (Instruction != null)
            result.Instruction = Instruction;

        if (ValidationResult != null)
            result.ValidationResult = ValidationResult;

        if (Potency != null)
            result.Potency = Potency;

        if (TimeLeft != null)
            result.TimeLeft = TimeLeft;

        return result;
    }
}

