using FluentValidation;
using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Core.Utils;

namespace MicrowaveSystem.Core.Validations;

public class MicrowaveValidationsResult : AbstractValidator<DigitalMicrowave>
{
    public MicrowaveValidationsResult()
    {
        RuleFor(e => e.Potency)
            .Must(ValidatePotency)
            .WithMessage(StringSources.POTENCY_VALIDATION + StringSources.EXIT);

        RuleFor(e => e.TimeLeft)
            .Must(ValidateTimeLeft)
            .WithMessage(StringSources.TIMELEFT_VALIDATION + StringSources.EXIT);
    }

    private bool ValidateTimeLeft(short? timeLeft)
    {
        if (timeLeft < 0 || timeLeft > 120)
            return false;

        return true;
    }

    private bool ValidatePotency(Potency? potency)
    {
        var pot = (int)potency;

        if ((pot < 1 || pot > 10))
            return false;

        return true;
    }
}

