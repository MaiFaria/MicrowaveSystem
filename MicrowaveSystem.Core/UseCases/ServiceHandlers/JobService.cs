using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Core.UseCases.Contracts;
using MicrowaveSystem.Core.Utils;

namespace MicrowaveSystem.Core.UseCases.ServiceHandlers;

public class JobService : IJobService
{
    public const int PAUSE = 27;

    public TimeSpan TimerValidations(short? timeLeft)
    {
        int? minutes = timeLeft / 60;
        int? seconds = timeLeft % 60;

        return new TimeSpan(0, (int)minutes, (int)seconds);
    }

    public void Timer(DigitalMicrowave microwave)
    {
        GetInstructions(microwave);

        if (!Console.KeyAvailable)
        {
            while (microwave.TimeLeft > 0)
            {
                var display = StringRetorno(microwave);

                Console.WriteLine(display);
                Thread.Sleep(1000);
                microwave.Timer = microwave.Timer.Subtract(TimeSpan.FromSeconds(1));
                microwave.TimeLeft--;

                if (Console.KeyAvailable)
                {
                    Console.WriteLine(StringSources.WARM_UP_PAUSE);
                    Console.ReadKey();

                    var resume = Console.ReadKey();

                    if (resume.KeyChar == PAUSE)
                        break;
                    else
                        continue;
                }
            }
        }

        Thread.Sleep(500);
        Console.WriteLine(StringSources.BEEP);
        Console.WriteLine(StringSources.WARM_UP_FINISHED);
        Thread.Sleep(2000);
    }

    public void ParameterizableOptions(DigitalMicrowave _microwave)
    {
        Console.WriteLine(StringSources.POTENCY_VALIDATION);
        var potency = short.Parse(Console.ReadLine());
        var newPotency = (Potency)potency;

        if (newPotency != null)
            _microwave.Potency = newPotency;

        Console.WriteLine(StringSources.TIMELEFT_VALIDATION);
        var time = short.Parse(Console.ReadLine());

        if (time != null)
            _microwave.TimeLeft = time;

        _microwave.TimeLeft = time;
    }

    private static void GetInstructions(DigitalMicrowave microwave)
    {
        if (microwave.Instruction is null)
            return;

        var instructions = string.Format(StringSources.INSTRUCTIONS_START,
                                         Environment.NewLine,
                                         microwave.Template.Name);

        instructions += string.Format(StringSources.INSTRUCTIONS_DEFAULT,
                                      Environment.NewLine,
                                      (decimal)microwave.Potency,
                                      microwave.Timer.Minutes,
                                      microwave.Timer.Seconds);

        Console.WriteLine(instructions + Environment.NewLine);
    }

    private static string StringRetorno(DigitalMicrowave microwave)
    {
        int caracteresPorSegundo = (int)microwave.Potency;

        return new('.', caracteresPorSegundo);
    }
}