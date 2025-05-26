# max-process-challenge

✅ O que esperamos de você

Este desafio não é sobre apenas escrever código, mas sobre avaliar o que já existe. Seu papel será:

1) Analisar o projeto entregue:
  1.1) Avalie a arquitetura, padrões utilizados, organização do código e boas práticas de segurança, performance e manutenção.

    - O projeto recebido veio arquivo de solution (.sln).
    - Arquitetura feita sem abstrações tais como segregações de interfaces que corresponde ao príncipio "I" do SOLID.
    - Controller não respeita os padrões de IoC (inversion of control) acessando diretamente a camada de acesso a dados (DAO Layer)
    - Interface de repositório com métodos padrões não abstraídos
    - Operação de registro de senha no banco visível aos desenvolvedores
    - Swagger não configurado para receber o Token JWT e portanto os endpoints tornam-se inacessíveis
    - Classe LoginRequest dentro do arquivo controller do AuthController.
   
  1.2) Identifique pontos positivos (boas decisões de implementação).
    - Data annotations na classe Usuario.cs
    - Método de geração de Token JWT abstraído em um serviço, além deste método também respeitar o princípio de responsabilidade única do SOLID
 
  1.3) Identifique pontos fracos (erros, omissões, más práticas, etc.).
    - Mesmos motivos do subitem (1.1)

3) Propor melhorias:
  2.1) Sugira alterações que você acredita que tornariam o projeto mais robusto, escalável ou aderente a boas práticas.
    - Configurar Swagger para aceitar entrada do Token Bearer JWT
    - Aplicar algoritmo de encrypt para senhas no banco para não torná-las visíveis e sendo gerado apenas um HASH da senha respeitando as normas LGPD
    - Aplicar conceitos de Clean Architecture para esse produto de MVP escalar
    - Separação de Camadas, a priori criação da Camada de Business (Core) e Infrastructure para lidar com acesso a dados, migrations e contexts, interfaces abstratas com métodos default no repository.
    - Serviço de EncryptPassword além do JWT na camada Core
    - Interfaces abstratas para a camada Core
    - Projeto de Api contendo apenas Controllers e DTOs
    - Separação de Camadas via CLASS Libray
    - Entidades de Domínio na camada Infrastructure
    - Migrations na camada Infrastructure
    - Mover LoginRequest para uma folder de DTOs
    - Folder de DTOs segredada com Requests e Responses

  2.2) Justifique cada sugestão com argumentos técnicos.
    - A maioria das sugestões são embasadas em padrões de projetos do mundo real, tais como clean architecture, clean code como comportamentos do SOLID e Code Smell.
    - A sugestão de encrypt da senha é visando segurança do dado do usuário que está sendo armazenado no banco, ficando visível para desenvolvedores ou possíveis ataques hackers,
    se obterem as senhas terão que utilizar um algoritmo de Decrypt que é custoso baseado em fatorações de números primos.


3) Aplicar parte das melhorias sugeridas
  3.1) Selecione pelo menos 2 melhorias (ou mais, se desejar) e implemente no código.
    - Segregação de interfaces
    - Segregação de Camadas
    - Algoritmo de Encrypt para senhas
    - Melhorar usualmente o Swagger para ser possível aceitar o token JWT e assim as rotas tornarem acessíveis
    - Implementar migrations no projeto/camada de Infrastructure
    - Aplicar Conceitos do SOLID
    - Aplicar Conceitos para evitar Code Smell
    - Aplicar Clean Arquitecture para tornar o MVP escalável

  3.2) Para cada melhoria aplicada, escreva uma explicação sobre o que foi feito, por que foi feito e quais os benefícios esperados
    - Segregação de interfaces:
        O que foi feito:  
          * Interfaces foram divididas por responsabilidade.
        Por que foi feito: 
          * Evitar implementação desnecessária com o ganho da abstração
        Benefícios: 
          * Código mais limpo e fácil de manter.
    - Segregação de Camadas:
        O que foi feito: 
          * Projeto separado em camadas (Core, Api, Infra, etc).
        Por que foi feito: 
          * Organizar responsabilidades.
        Benefícios: 
          * Melhor manutenção e escalabilidade.
    - Algoritmo de Encrypt para senhas:
        O que foi feito: 
          * Implementado hash seguro
        Por que foi feito: 
          * Proteger senhas no banco
        Benefícios: 
          * Mais segurança e conformidade com boas práticas        
    - Melhorar usualmente o Swagger para ser possível aceitar o token JWT e assim as rotas tornarem acessíveis:
        O que foi feito:  
          * Swagger configurado para aceitar token JWT.
        Por que foi feito: 
          * Permitir testar rotas protegidas.
        Benefícios: 
          * Facilidade nos testes e validações.        
    - Implementar migrations no projeto/camada de Infrastructure:
        O que foi feito: 
          * Adicionadas migrations para controle do banco.
        Por que foi feito:  
          * Padronizar e versionar alterações.
        Benefícios: 
          * Menos erros e mais controle nas mudanças.        
    - Aplicar Conceitos do SOLID:
        O que foi feito:  
          * Refatoração seguindo os princípios SOLID.
        Por que foi feito: 
          * Melhorar estrutura e manutenibilidade.
        Benefícios: 
          * Código mais flexível e testável. 
    - Aplicar Conceitos para evitar Code Smell:
        O que foi feito: 
          * Remoção de duplicações, métodos grandes, etc.
        Por que foi feito: 
          * Melhorar qualidade do código.
        Benefícios: 
          * Menos bugs e manutenção mais fácil.
    - Aplicar Clean Arquitecture para tornar o MVP escalável:
        O que foi feito: 
          * Estrutura reorganizada com base na Clean Architecture.
        Por que foi feito: 
          * Separar responsabilidades e isolar regras de negócio.
        Benefícios:  
          * Projeto mais escalável e de fácil evolução.
        
