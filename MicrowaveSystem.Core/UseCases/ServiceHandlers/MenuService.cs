using MicrowaveSystem.Core.Entities;
using MicrowaveSystem.Core.Enumerators;
using MicrowaveSystem.Core.UseCases.Contracts;
using MicrowaveSystem.Core.Utils;

namespace MicrowaveSystem.Core.UseCases.ServiceHandlers;

public class MenuService : IMenuService
{
    private readonly IMicrowaveService _microwaveService;

    public MenuService(IMicrowaveService microwaveService)
    {
        _microwaveService = microwaveService;
    }

    public void Start()
    {
        do
        {
            StartMenu();

        } while (true);
        
    }

    private void StartMenu()
    {
        var result = StartMenuOptions();

        if (result.Equals((int)Menu.Exit))
            Environment.Exit(0);

        switch (result)
        {
            case 1:
                _microwaveService.QuickStart();
                break;
            case 2:
                _microwaveService.Parameterizable();
                break;
            case 3:
                _microwaveService.StartDefaultProgams(DefaultProgramsMenuOptions());
                break;
            case 4:
                _microwaveService.ProgramRegistration(ProgramRegistrationMenu());
                break;
            default:
                break;
        }
    }

    #region Menu Options

    private static short StartMenuOptions()
    {
        Console.Clear();

        Console.WriteLine("Selecione a opção de aquecimento desejada:");
        Console.WriteLine(StringSources.STRING_DIVISION + Environment.NewLine);
        
        Console.WriteLine("1 - Início Rápido - Aquecimento 30 segundos");
        Console.WriteLine("2 - Selecionar Tempo e Potência");
        Console.WriteLine("3 - Selecionar Programas pré-definidos");
        Console.WriteLine("4 - Cadastrar novo programa");
        Console.WriteLine("0 - Sair");

        Console.WriteLine(Environment.NewLine + StringSources.STRING_DIVISION);

        return short.Parse(Console.ReadLine());
    }

    private string DefaultProgramsMenuOptions()
    {
        Console.Clear();

        Console.WriteLine("Selecione o programa de aquecimento desejado digitando o IDENTIFICADOR:");
        Console.WriteLine(StringSources.STRING_DIVISION + Environment.NewLine);

        _microwaveService.DefaultProgams();

        return Console.ReadLine();
    }

    private static JobTemplate ProgramRegistrationMenu()
    {
        Console.Clear();

        Console.WriteLine("Digite o nome do ALIMENTO:");
        var name = Console.ReadLine();
        Console.WriteLine("Digite o TEMPO de aquecimento:");
        var time = Console.ReadLine();
        Console.WriteLine("Digite o valor da POTÊNCIA:");
        var potency = Console.ReadLine();
        Console.WriteLine(StringSources.DOT_INSTRUCTIONS);
        var dot = Console.ReadLine();
        Console.WriteLine("Digite as INSTRUÇÕES(opcional - para cancelar pressione 0!):");
        var instructions = Console.ReadLine();

        var template = new JobTemplate(name,
                                       instructions,
                                       int.Parse(potency),
                                       short.Parse(time),
                                       false,
                                       dot);

        return template;
    }

    #endregion
}
