using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Interfaces;
using MicrowaveSystem.Core.Utils;

namespace Microwave.Infra.Repositories;

public class TemplatesRepository : ITemplatesRepository
{
    public IList<JobTemplate> LoadDefaultTemplates()
    {
        var templates = new List<JobTemplate>
        {
            new JobTemplate("Pipoca (de micro-ondas)", StringSources.INSTRUCTIONS_POPCORN, 7, 180, true, "@"),
            new JobTemplate("Leite", StringSources.INSTRUCTIONS_MILK, 5, 360, true, "#"),
            new JobTemplate("Carnes de boi (em pedaço ou fatias)", StringSources.INSTRUCTIONS_BEEFMEAT, 4, 840, true, "$"),
            new JobTemplate("Frango (qualquer corte)", StringSources.INSTRUCTIONS_CHICKEN, 7, 480, true, "%"),
            new JobTemplate("Feijão congelado", StringSources.INSTRUCTIONS_BEAN, 9, 540, true, "&"),
        };

        return templates;
    }

    public async void SaveTemplatesToFile(string fullpath,
                                          IList<JobTemplate> templates)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        options.Converters.Add(
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        using FileStream fs = File.Create(fullpath);
        await JsonSerializer.SerializeAsync(fs, templates);
    }

    public IList<JobTemplate> ReadTemplatesFromFile(string fullpath)
    {
        if (File.Exists(fullpath))
        {
            var templates = JsonSerializer
                .Deserialize<IList<JobTemplateParameterLess>>
                    (File.ReadAllText(fullpath));

            return templates.Select(t => t.Get()).ToList();
        }
        else return LoadDefaultTemplates();
    }

    public string GetCurrentPath(string fileName)
    {
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + fileName;
    }
}
