using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Core.Validations;

namespace MicrowaveSystem.Core.Entities
{
    public class DigitalMicrowave : BaseJob
	{
        public DigitalMicrowave() { }

        public DigitalMicrowave(JobTemplate? template,
                                short? defaultTime,
                                Potency? defaultPotency)
        {
            Template = template;
            Potency = defaultPotency;
            TimeLeft = defaultTime;
            Instruction = template?.Instructions;
        }

        public JobTemplate? Template { get; set; }
        public TimeSpan Timer { get; set; }
        public string? Instruction { get; set; }

        public async Task Validate()
            => ValidationResult = await new MicrowaveValidationsResult()
                .ValidateAsync(this);
    }
}