using AutoMapper;
using MicrowaveSystem.Core.Entities;

namespace MicrowaveSystem.Console.Mappings;

public class TemplateMapper : Profile
{
    public TemplateMapper()
    {
        CreateMap<RegistrationTemplate, JobTemplate>().ReverseMap();
    }
}

