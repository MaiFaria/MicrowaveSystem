using MicrowaveSystem.Core.Enumerators;

namespace MicrowaveSystem.Core.Entities;

public class RegistrationTemplate
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MealKind { get; set; } = string.Empty;
    public TimeSpan Time { get; set; }
    public Potency Potency { get; set; }
    public string? Instructions { get; set; }
}