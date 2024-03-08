using MicrowaveSystem.Core.Entities;

namespace MicrowaveSystem.Core.UseCases.Contracts;

public interface IJobService
{
    void ParameterizableOptions(DigitalMicrowave microwave);
    void Timer(DigitalMicrowave microwave);
    TimeSpan TimerValidations(short? timeLeft);
}
