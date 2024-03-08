using FluentValidation;
using MicrowaveSystem.Core.Entities;

namespace MicrowaveSystem.Core.Validations;

public class JobTemplateValidationsResult : AbstractValidator<JobTemplate>
{
    public JobTemplateValidationsResult()
    {
        RuleFor(e => e.Instructions)
            .Must(ValidateInstructions);
    }

    private bool ValidateInstructions(string Instructions)
    {
        if (Instructions == "0")
            Instructions = null;

        return true;
    }
}

