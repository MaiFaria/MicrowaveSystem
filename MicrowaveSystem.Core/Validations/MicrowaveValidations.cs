using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Core.Utils;

namespace MicrowaveSystem.Core.Validations;

public abstract class MicrowaveValidations
{
    public const short PAUSE = 0;

    public static void Validate(DigitalMicrowave microwave)
    {
        ValidatePotency(microwave);
        ValidateTimeLeft(microwave);
        ValidateInstructions(microwave);
    }

    private static void ValidatePotency(DigitalMicrowave microwave)
    {
        var pot = (int)microwave.Potency;

        if ((pot < 1 || pot > 10) && !microwave.Template.Default)
        {
            Console.WriteLine
                (StringSources.POTENCY_VALIDATION + StringSources.EXIT);

            var resume = short.Parse(Console.ReadLine());

            if (resume == PAUSE)
            {
                Console.WriteLine(StringSources.WARM_UP_CANCELED);
                Environment.Exit(0);
            }
            else
                microwave.Potency = (Potency)resume;
        }
    }

    private static void ValidateTimeLeft(DigitalMicrowave microwave)
    {
        if ((microwave.TimeLeft < 0 || microwave.TimeLeft > 120)
            && !microwave.Template.Default)
        {
            Console.WriteLine
                (StringSources.TIMELEFT_VALIDATION + StringSources.EXIT);

            var resume = short.Parse(Console.ReadLine());

            if (resume == PAUSE)
            {
                Console.WriteLine(StringSources.WARM_UP_CANCELED);
                Environment.Exit(0);
            }
            else
                microwave.TimeLeft = resume;
        }
    }

    private static void ValidateInstructions(DigitalMicrowave microwave)
    {
        if (microwave.Instruction == "0" && !microwave.Template.Default)
            microwave.Template.Instructions = null;
    }
}