using Bogus;
using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Tests.Commom;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MicrowaveSystem.Tests.Builders;

public class JobTemplateBuilder
{
    private readonly Faker _faker;

    public Guid Id { get; set; }
    public string Name { get; set; } = "New Job";
    public string Instructions { get; set; }
    public bool Default { get; set; }
    public string Dot { get; set; }
    public Potency Potency { get; set; }
    public short TimeLeft { get; set; }
    public ValidationResult ValidationResult { get; set; } = new();

    public JobTemplateBuilder()
        => _faker = FakerBuilder.New().Build();

    public JobTemplateBuilder New()
    {
        Id = _faker.GetId();
        Name = _faker.Name.JobDescriptor();
        Instructions = _faker.Random.AlphaNumeric(100);
        Default = true;
        Dot = _faker.Random.Char().ToString();
        Potency = _faker.GetPotency();
        TimeLeft = _faker.Random.Short(1, 120);
        ValidationResult = new ValidationResult();

        return this;
    }

    public JobTemplate Build()
    {
        var result = new JobTemplate();

        if (Id != null)
            result.Id = Id;

        if (Name != null)
            result.Name = Name;

        if (Instructions != null)
            result.Instructions = Instructions;

        if (Default != null)
            result.Default = Default;

        if (Dot != null)
            result.Dot = Dot;

        if (Potency != null)
            result.Potency = Potency;

        if (TimeLeft != null)
            result.TimeLeft = TimeLeft;

        if (ValidationResult != null)
            result.ValidationResult = ValidationResult;

        return result;
    }
}

