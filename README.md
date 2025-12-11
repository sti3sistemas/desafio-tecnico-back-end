**Desafio Técnico — Desenvolvedor Backend .NET (STi3)**

Bem-vindo ao desafio técnico para a vaga de Desenvolvedor Backend .NET na STi3.  
Este repositório contém um projeto base e todas as instruções necessárias para a realização do teste. Importante que você leia todas as instruções contidas aqui. Qualquer dúvida pode ser direcionada pelo linkedin ou e-mail nos contatos abaixo:
E-mail: lucas.freire@sti3.com.br.
Linkedin: https://www.linkedin.com/in/lucassrfreire

O objetivo deste desafio é avaliar:

 Sua capacidade de:

-   Ler, entender e evoluir um projeto existente em .NET.
-   Identificar e corrigir problemas de código, arquitetura e regras de negócio.
-   Organizar o código em camadas (Controllers, Services, Repositories, DTOs) de forma clara e coesa.
-   Modelar e expor APIs REST para cadastro de clientes e compras.
-   Implementar validações, regras de negócio e tratamento de erros.
-   Utilizar boas práticas de versionamento com Git.

----------

**Visão geral do desafio**

Você receberá um projeto base em .NET (Web API) que implementa parcialmente um cadastro de **Clientes** e **Compras**, seguindo um padrão MVC em camadas:

Esse projeto base contém **falhas intencionais** e **pontos incompletos**, tanto de código quanto de arquitetura, para que você possa:

-   Identificar problemas.
-   Corrigir o que estiver errado.
-   Implementar o que estiver faltando.
-   Melhorar o que considerar necessário.

Não se trata apenas de “fazer funcionar”, mas de demonstrar **qualidade de código**, **organização** e **boas decisões técnicas**.

----------

**Domínio do problema (resumo)**

O sistema é uma API para gerenciar **Clientes** e **Compras**.

**Cliente (exemplo de atributos)**

-   Id (Guid, PK)
-   Nome
-   CPF
-   DataCadastro
-   Ativo (bool)
-   (Opcionalmente podem existir outros campos ou entidades relacionadas já no projeto base.)

**Compra (exemplo de atributos)**

-   Id (Guid, PK)
-   ClienteId
-   DataHora
-   Status (ex.: Criada, Confirmada, Cancelada)
-   ValorTotal
-   (Opcionalmente podem existir outros campos ou entidades relacionadas já no projeto base.)

O modelo exato pode variar de acordo com o código fornecido no projeto base. Parte do desafio é **entender a modelagem existente** e, se necessário, ajustá-la de forma coerente.

----------

**O que você deverá fazer**

**1. Corrigir problemas do projeto base**

O projeto inicial contém falhas propositalmente inseridas, que podem envolver, por exemplo:

-   Erros de compilação ou de runtime.
-   Falhas de mapeamento entre entidades e DTOs.
-   Problemas na injeção de dependências.
-   Repositórios ou services mal estruturados.
-   Regras de negócio incorretas ou ausentes.
-   Validações inexistentes ou inconsistentes.
-   Endpoints incompletos ou retornos inadequados.

Sua missão é:

-   Fazer o projeto **compilar e executar** corretamente.
-   Identificar e corrigir os problemas que comprometam:

-   A corretude da lógica.
-   A organização da solução.
-   A clareza e a manutenibilidade do código.

-   Melhorar onde considerar necessário, sem fugir do escopo do desafio.

Sempre que achar relevante, você pode documentar suas decisões em um arquivo DECISOES_TECNICAS.md ou seção no próprio README.

----------

**2. Implementar o fluxo de Compras e Clientes**

Você pode complementar o domínio (ex.: adicionar itens da compra) se fizer sentido para você, mas não é obrigatório e nem determinante.

----------

**4. Validações e regras de negócio**

O projeto deve conter validações coerentes, tanto na entrada quanto na lógica de negócio.

Você é livre para usar a abordagem que preferir para validação (ex.: validação manual, bibliotecas de validação, DataAnnotations, etc.), desde que mantenha consistência.

----------

**5. Organização em camadas e boas práticas**

O projeto já está dividido em:

-   Controllers
-   Services
-   Repositories
-   DTOs

Esperamos que você:

-   Evite regras de negócio diretamente nos Controllers.
-   Evite acesso direto ao banco a partir de Controllers.
-   Use injeção de dependência de forma adequada.
-   Evite duplicação desnecessária de código.

Se considerar interessante, você pode aplicar conceitos de SOLID, Clean Code ou padrões de projeto que achar adequado.

----------

**Requisitos técnicos**

-   .NET.
-   C#.
-   Banco de dados relacional (por exemplo SQL Server).
-   ORM (Entity Framework Core).

Caso você julgue necessário alterar algum detalhe de infraestrutura (por exemplo, trocar o provedor de banco, ajustar migrations ou connection string), **documente isso claramente no README**.

----------

**Diferenciais (opcionais)**

As funcionalidades abaixo **não são obrigatórias**, mas serão consideradas como diferencial:

-   Uso de FluentValidation ou outra biblioteca de validação.
-   Documentação da API com Swagger/OpenAPI bem configurada.
-   Tratamento global de exceções (middleware ou filter).
-   Logs estruturados.
-   Paginação e filtros bem projetados nos endpoints de listagem.
-   Versionamento da API (ex.: v1, v2).

----------

**Organização e Git**

-   Use commits **claros e bem descritos**, que contem:

-   O que foi feito.
-   Por que foi feito (quando fizer sentido).

-   Não é necessário um fluxo de branches complexo, mas:

-   Evite concentrar tudo em um único commit monolítico, se possível.
-   Mostre a evolução do raciocínio e das entregas.

-   Mantenha o README.md atualizado com:

-   Instruções de execução.
-   Decisões importantes.
-   Pontos que você julgar relevantes e determinantes para que seu projeto funcione.

----------

**Como executar o projeto**

Descreva ou ajuste conforme necessário no seu repositório os detalhes de como rodar (exemplo):

1.  Pré-requisitos:

-   SDK do .NET (versão do projeto).
-   Banco de dados (ex.: SQL Server/LocalDB ou outro informado).

3.  Configuração:

-   Ajustar a connection string em appsettings.json ou outro local indicado.
-   Aplicar migrations ou executar script SQL (se fornecido).

5.  Execução:

-   Via linha de comando:
-   dotnet restore
-   dotnet run
-   Via IDE (Visual Studio / Rider / VS Code).

7.  Acesso:

-   URL base da API (ex.: https://localhost:5001).
-   Endpoints principais:

-   GET /api/clientes
-   POST /api/clientes
-   GET /api/compras
-   etc. (liste ao final da implementação).

----------

**O que é necessário entregar**

-   Código da aplicação com as correções e implementações realizadas.
-   Script SQL ou migrations para criação/atualização do banco, se aplicável.
-   README.md atualizado com:

-   Passo a passo para rodar o projeto.
-   Dependências necessárias.
-   Descrição resumida das principais decisões técnicas.
-   Qualquer instrução adicional relevante.

----------

**Como entregar**

1.  Clone este projeto base.
2.  Crie um **repositório privado** no GitHub com a sua solução.
3.  Adicione como colaborador do repositório o usuário:  
    lucas.freire@sti3.com.br
4.  Desenvolva a solução no repositório criado até a data combinada para a entrega.

----------

**Observações finais**

-   Você é livre para organizar o projeto da forma que achar mais adequada, desde que mantenha a ideia geral apresentada.
-   Sinta-se à vontade para acrescentar funcionalidades que considerar relevantes (sem fugir muito do escopo).
-   Não buscamos perfeição absoluta, e sim:

-   clareza de raciocínio,
-   organização,
-   boas práticas,
-   capacidade de lidar com um código que já existe e melhorá-lo.

-   Não é permitido copiar projetos prontos da internet. Focaremos em entender seu raciocínio e suas decisões.

Boa sorte!  
Estamos ansiosos para ver o seu trabalho.
