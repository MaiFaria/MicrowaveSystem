using MicrowaveSystem.Core.Entities;

namespace MicrowaveSystem.Core.Interfaces
{
    public interface ITemplatesRepository
	{
        IList<JobTemplate> LoadDefaultTemplates();
        void SaveTemplatesToFile(string fullpath, IList<JobTemplate> templates);
        IList<JobTemplate> ReadTemplatesFromFile(string fullpath);
        string GetCurrentPath(string fileName);
    }
}