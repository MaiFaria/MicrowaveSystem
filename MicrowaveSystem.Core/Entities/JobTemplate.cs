using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Core.Validations;

namespace MicrowaveSystem.Core.Entities;

public class JobTemplate : BaseJob
{
    public JobTemplate() { }

    public JobTemplate(short timeLeft,
                       Potency potency,
                       Guid id)
    {
        Id = id;
        TimeLeft = timeLeft;
        Potency = potency;
    }

    public JobTemplate(string name,
                       string instructions,
                       int potency,
                       short timeLeft,
                       bool template,
                       string dot)
    {
        Id = Guid.NewGuid();
        Name = name;
        Instructions = instructions;
        Potency = (Potency)potency;
        TimeLeft = timeLeft;
        Default = template;
        Dot = dot;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = "New Job";
    public string? Instructions { get; set; }
    public bool Default { get; set; }
    public string Dot { get; set; }



    public async Task Validate()
        => ValidationResult = await new JobTemplateValidationsResult()
            .ValidateAsync(this);
}

public class JobTemplateParameterLess
{
    public Potency Potency { get; set; }
    public short TimeLeft { get; set; }
    public string Name { get; set; } = "New Job";
    public string Dot { get; set; }
    public string? Instructions { get; set; }
    public bool Default { get; set; }
    public Guid Id { get; set; }

    public JobTemplate Get()
    {
        return new JobTemplate(TimeLeft, Potency, Id)
        {
            Default = Default,
            Name = Name,
            Instructions = Instructions,
            Dot = Dot
        };
    }
}