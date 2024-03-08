namespace MicrowaveSystem.Core.Utils;

public abstract class StringSources
{
    public const string EXIT = "ou pressione 0 para cancelar!. ";
    public const string FAIL = " Falha ao tentar inicializar o microondas ";
    public const string BEEP = " BeeeeeeP =) ";

    public const string WARM_UP_CANCELED = " Aquecimento cancelado! ";
    public const string WARM_UP_FINISHED = " Aquecimento concluído! ";
    public const string WARM_UP_PAUSE = "Aquecimento pausado, para continuar pressione enter, para cancelar pressione ESC.";

    public const string POTENCY_VALIDATION = " Por favor, informe uma POTÊNCIA entre Um e Dez ";
    public const string TIMELEFT_VALIDATION = " Por favor, informe um TEMPO entre um segundo e dois minutos ";
    public const string DOT_INSERT_VALIDATIONS = "Para SUBSTITUIR tecle 1, para CANCELAR tecle 0.";
    public const string DOT_VALIDATIONS = "Para TENTAR NOVAMENTE digite 1, para CANCELAR tecle 0.";
    public const string PROGRAM_EXISTS = "O programa com o IDENTIFICADOR {0} já existe no sistema!";
    public const string TEMPLATE_INCORRECT = "Identificador INCORRETO/NÃO ENCONTRADO";

    public const string STRING_DIVISION = "---------------------------------------";

    #region Instructions

    public const string DOT_INSTRUCTIONS = "Digite o CARACTERE ESPECIAL para identificação:";

    public const string INSTRUCTIONS_START = " {0} O aquecimento {1} irá começar! ";
    public const string INSTRUCTIONS_DEFAULT = " {0} A potência definida está em {1} e o tempo em {2}:{3} ";
    public const string INSTRUCTIONS_QUICKSTART = "Início Rápido";

    public const string INSTRUCTIONS_POPCORN =
        " Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento. ";

    public const string INSTRUCTIONS_MILK =
        " Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras ";

    public const string INSTRUCTIONS_BEEFMEAT
        = " Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme. ";

    public const string INSTRUCTIONS_CHICKEN
        = " Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme. ";

    public const string INSTRUCTIONS_BEAN
        = " Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas. ";

    public const string DEFAULT_PROGRAMS = "Identificador: {0} \r\nNome: {1} \r\nPotência: {2} \r\nTempo: {3} \r\n";

    #endregion
}