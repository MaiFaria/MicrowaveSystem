using Bogus;
using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;

namespace MicrowaveSystem.Tests.Commom;

public static class FakerHelper
{
    public static Guid GetId(this Faker faker)
    {
        return faker.Random.Guid();
    }

    public static string GetName(this Faker faker)
    {
        return faker.Name.FirstName() + " " + faker.Name.LastName();
    }

    public static Potency GetPotency(this Faker faker)
    {
        return faker.PickRandom<Potency>();
    }

    public static JobTemplate GetTemplate(this Faker faker)
    {
        return new JobTemplate(faker.Name.JobDescriptor(),
                               faker.Company.CatchPhrase(),
                               faker.Random.Int(1, 10),
                               faker.Random.Short(),
                               faker.Random.Bool(),
                               faker.Random.Char().ToString());
    }
}
