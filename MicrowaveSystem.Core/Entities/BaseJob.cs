using FluentValidation.Results;
using MicrowaveSystem.Core.Enumerators;

namespace MicrowaveSystem.Core.Entities;

public abstract class BaseJob
{
    public Potency? Potency { get; set; }
    public short? TimeLeft { get; set; }

    public ValidationResult ValidationResult { get; set; } = new();

    public bool IsValid
        => ValidationResult.IsValid;
}

