using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Core.Interfaces;
using MicrowaveSystem.Core.UseCases.Contracts;
using MicrowaveSystem.Core.Utils;
using MicrowaveSystem.Core.Validations;

namespace MicrowaveSystem.Core.UseCases.ServiceHandlers;

public class MicrowaveService : IMicrowaveService
{
    private readonly IJobService _jobService;
    private ITemplatesRepository _templatesRepository;
    private DigitalMicrowave _microwave;

    private IList<JobTemplate> _templateList;
    private const Potency _defaultPotency = Potency.Ten;
    private const short _defaultTime = 30;
    private const string _templateFileName = "JobTemplates.json";

    public MicrowaveService(IJobService jobService,
                            ITemplatesRepository templatesRepository)
    {
        _jobService = jobService;
        _templatesRepository = templatesRepository;
    }

    public void QuickStart()
    {
        try
        {
            var template = new JobTemplate("Início rápido",
                                           StringSources.INSTRUCTIONS_QUICKSTART,
                                           10,
                                           30,
                                           true,
                                           "!");

            Validations(template);
            StartJob();
        }
        catch
        {     
            Console.WriteLine(StringSources.FAIL);
        }
    }

    #region Parameterizable

    public void Parameterizable()
    {
        try
        {
            ParameterizableOptions();
            MicrowaveValidations.Validate(_microwave);
            StartJob();
        }
        catch
        {
            Console.WriteLine(StringSources.FAIL);
            Console.ReadKey();
        }
    }

    private void ParameterizableOptions()
    {
        _microwave = new DigitalMicrowave(null,
                                          _defaultTime,
                                          _defaultPotency);

        _jobService.ParameterizableOptions(_microwave);
    }

    #endregion

    #region Default Programs

    public void DefaultProgams()
    {
        try
        {
            GetDefaultTemplations();
            ShowTemplates();
        }
        catch
        {
            Console.WriteLine(StringSources.FAIL);
        }
    }

    public void StartDefaultProgams(string option)
    {
        try
        {
            var template =
                _templateList.FirstOrDefault(e => (e.Dot.Equals(option)));

            GetDefaultTemplate(option, false, ref template);

            Validations(template);
            StartJob();
        }
        catch
        {
            Console.WriteLine(StringSources.FAIL);
        }
    }

    private void GetDefaultTemplate(string option,
                                    bool repeat,
                                    ref JobTemplate? template)
    {
        do
        {
            repeat = false;

            template = _templateList.FirstOrDefault(e => e.Dot.Equals(option));

            if (template is null)
            {
                repeat = true;

                Console.WriteLine(StringSources.TEMPLATE_INCORRECT);
                Console.WriteLine(StringSources.DOT_VALIDATIONS);
                var result = short.Parse(Console.ReadLine());

                if (result == 0)
                    Environment.Exit(0);
                else if (result == 1)
                {
                    Console.WriteLine(StringSources.DOT_INSTRUCTIONS);
                    option = Console.ReadLine();
                }
            }

        } while (repeat);
    }

    #endregion

    public void ProgramRegistration(JobTemplate template)
    {
        GetDefaultTemplations();

        var oldVersion = _templateList.FirstOrDefault(t => t.Dot.Equals(template.Dot));
        if (oldVersion != null)
        {
            Console.WriteLine(StringSources.PROGRAM_EXISTS, oldVersion.Dot);
            Console.WriteLine(StringSources.DOT_INSERT_VALIDATIONS);
            var result = short.Parse(Console.ReadLine());

            if (result is 0)
                Environment.Exit(0);
        }

        Validations(template);
        
        _templateList.Add(template);

        PersistTemplates();
    }

    private void GetDefaultTemplations()
    {
        var fullpath = _templatesRepository.GetCurrentPath(_templateFileName);
        _templateList = _templatesRepository.ReadTemplatesFromFile(fullpath);
    }

    private void ShowTemplates()
    {
        foreach (var item in _templateList)
        {
            var timer = _jobService.TimerValidations(item.TimeLeft);

            Console.WriteLine(StringSources.DEFAULT_PROGRAMS,
                              item.Dot,
                              item.Name,
                              (int)item.Potency,
                              timer);
        }
    }

    private void StartJob()
    {
        TimerValidations();

        _jobService.Timer(_microwave);
    }

    #region Validations

    private void Validations(JobTemplate? template)
    {
        _microwave = new DigitalMicrowave(template,
                                          _defaultTime,
                                          _defaultPotency);

        if (template != null)
        {
            _microwave.Potency = template.Potency;
            _microwave.TimeLeft = template.TimeLeft;
        }

        MicrowaveValidations.Validate(_microwave);
    }

    private void TimerValidations()
        => _microwave.Timer = _jobService.TimerValidations(_microwave.TimeLeft);

    public void PersistTemplates()
    {
        try
        {
            var fullpath =
                _templatesRepository.GetCurrentPath(_templateFileName);

            _templatesRepository.SaveTemplatesToFile(fullpath, _templateList);
        }
        catch
        {
            Console.WriteLine(StringSources.FAIL);
        }
    }

    #endregion
}