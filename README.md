# Sistema para console simulando funcionalidades de um micro-ondas :)

Pequeno projeto que visa simular programas de aquecimento, como:

- Programa de Início rápido
- Parametrizável (podendo escolher a potência e tempo desejável)
- Programas pré-definidos
- Cadastrar um novo programa

## Frameworks utilizados
Consulte **[Implantação](-##Implantacao)** para saber como implantar o projeto.

- Estará descrito por projeto quais frameworks deverão ser baixados para utilização.

### Pré-Requisitos
- .Net 7.0
- Visual Studio 2022

### Instruções 
Para inicialização do projeto:

- Abrir terminar em projeto **console**
- Digitar comando para build: ```dotnet run```

![image](https://github.com/MaiFaria/MicrowaveSystem/assets/52571069/0e566430-d6fc-4142-b1ec-2089f8e71275)

- Selecionar **opção desejada**

- 1 - **[QuickStart](-QuickStart)** Início Rápido - Aquecimento 30 segundos 
- 2 - **[Parameterizable](-Parameterizable)** - Selecionar tempo e potência
- 3 - **[DefaultPrograms](-DefaultPrograms)** - Selecionar Programas pré-definidos
- 4 - **[ProgramRegistration](-ProgramRegistration)** - Cadastrar novo programa
- 5 - Sair (Encerrar programa)

## QuickStart
Neste programa o sistema está parametrizado para que o tempo e a potência esteja com o valor **default** 
- TimeLeft => 30
- Potency => 10

![image](https://github.com/MaiFaria/MicrowaveSystem/assets/52571069/910160aa-02e4-46c6-9505-3f78bf3330d9)
- O usuário pode pausar e cancelar/continuar a operação durante o processo.

## Parameterizable
Neste programa o sistema permite que o usuário insira o tempo e a potência desejada com as seguintes regras:
- O tempo não pode ser menor que 0 segundos
- O tempo não pode ser maior que 120 segundos
- Caso insira um ou ambos parâmetros nulos, o sistema irá usar o padrão **default** para utilização.
  
![image](https://github.com/MaiFaria/MicrowaveSystem/assets/52571069/bde24183-d061-455e-b8f2-c6c7c8b20f5f)
- O usuário pode pausar e cancelar/continuar a operação durante o processo.

## DefaultPrograms
Neste programa o sistema possui **templates** salvos, onde irá mostrar as opções para aquecimento:

![image](https://github.com/MaiFaria/MicrowaveSystem/assets/52571069/904228bd-9542-4ecf-9459-6d743dd9e1e1)

- Para escolha o usuário deverá informar o **cacactere especial** para identicação.
- O usuário pode pausar e cancelar/continuar a operação durante o processo.

## ProgramRegistration
Neste programa o sistema permite que o usuário crie um programa de aquecimento:
- Fazendo com o que o mesmo fique salvo nos **templates** de programas pré-definidos.
- O template novo não poderá ser excluído.
- O usuário pode pausar e cancelar/continuar a operação do template salvo durante o processo.

## Implantação
### Projeto Console v.7.0.0
- Microsoft.Extensions.DependencyInjection
### Projeto Core
- AutoMapper v.13.0.1
- FluentValidation v11.9.0
### Projeto Infra
- Microsoft.EntityFramworkCore v.7.0.0
### Projeto Tests
- Bogus v.35.4.1
- coverlet.collector v.3.2.0
- Microsoft.NET.Test.Sdk v.17.5.0
- Moq v.4.13.0
- xunit v.2.4.2
- xunit.runner,visualstudio v.2.4.5
