using MicrowaveSystem.Core.Entities;

namespace MicrowaveSystem.Core.UseCases.Contracts;

public interface IMicrowaveService
{
    void QuickStart();
    void Parameterizable();
    void DefaultProgams();
    void ProgramRegistration(JobTemplate template);
    void StartDefaultProgams(string option);
}