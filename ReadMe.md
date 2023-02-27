# Documentação Dell First Steps
Essa documentação é pertinente ao projeto Dell First Steps, uma aplicação desenvolvida por estágiários do IT Academy. O projeto teve seu início no dia 02 de Janeiro do ano de 2023 e continua em desenvolvimento ativo.

# Sobre a aplicação Dell First Steps
Trata-se de um sistema de gerenciamento dos programas de Estágio da Dell em parceria com universidades. Até o presente momento, a aplicação gerencia as seguintes informações: 

- **Programs:** São os programas de estágio da Dell. Exemplo: IT Academy (Dell e PUCRS),  Dell Product Design Program (DPDP, Dell e Unisinos) e Infrastructure Residency.
- **Editions:** São as edições de determinado programa de estágio. Por exemplo, o IT Academy encontra-se na edição 17, enquanto o DPDP está na edição 5.
- **Events**: São os eventos relativos a determinada edição, que são registrados num calendário.
- **News:** São as notícias sobre os programas de estágio.
- **Roles:** São os tipos de usuários do sistema: Admin (Admnistrador), Intern (Estagiário), DellManager (Gerente Dell), DellMember (outros funcionários Dell) e PucrsStaff (Funcionários PUCRS). Nesta aplicação, _somente o Admin tem acesso à página da lista de usuários_, podendo adicioná-los, editá-los e removê-los. É também, _o único usuário_ que pode adicionar e editar programas/edições/notícias.


Até o presente momento, a aplicação contém as seguintes funcionalidades:

1. Adicionar novos programas de Estágio. Por exemplo, IT Academy.
2. Editar informações de um programa criado anteriormente.
3. Adicionar uma nova edição ao respectivo programa.
4. Editar informações de uma edição.
5. Adicionar notícias sobre os programas de estágio.
6. Editar notícias dos programas de estágio.
7. Adicionar eventos a uma determinada edição, através do calendário.
8. Editar eventos que já foram adicionados a determinada edição, através do calendário.
9. Adicionar, remover ou editar usuários, ao acessar a aplicação com um usuário que seja Admin.

### Tecnologias Utilizadas
| **Tecnologia**          | **Instalação**        |
| -----------             | :----------:          |
| **SDK.NET 6.0.400**     |   Workspace One       |
| **.NET 6.0.13**         |   Cmd                 |
| **Node 18.12.1**        |   Workspace One       |
| **NPM 9.1.3**           |   Cmd                 |
| **VUE.js 5.0.8**        |   Cmd                 |
| **NUnit 3.13.3**        |   Cmd                 |
| **Git 2.36.0**          |   Workspace One       |


### Instalações e configuração de ambiente
Para possibilitar que a aplicação seja executada corretamente na sua máquina, deve-se realizar as seguintes instalações a fim de configurar o ambiente de desenvolvimento:

- Instalar o SKD.NET utilizando o aplicativo Workspace One da sua máquina.
- Instalar o Dotnet. Para fazer isso, execute o seguinte comando via command prompt: `dotnet tool install --global dotnet-ef` Assim que a instalação for concluída, siga para o próximo passo.
- Instalar o NPM/NODE utilizando o aplicativo Workspace One da sua máquina.
- Instalar o NUnit. Um tutorial para realizar isso pode ser visto aqui: [Tutorial de Instalação Nunit](https://docs.nunit.org/articles/nunit/getting-started/installation.html)
- Instalar o Selenium. Existe um plug-in no Microsoft Edge que pode ser instalado no seu Browser.
- Instalar o Git for Windows utilizando o aplicativo Workspace One da sua máquina.
- Existe tambem a opção de instalar o Github for Desktop, caso tenha conhecimento da ferramenta.

Após finalizar estes passos, pode-se criar uma cópia local do projeto na sua máquina, usando do versionamento do Git para tal.

--- 

### Utilizando o Git
Para poder criar uma cópia do projeto, crie uma conta no Github e peça para que seja adicionado no diretório.
Na sua máquina, crie uma pasta dedicada para o projeto. Dentro dessa pasta, clique com o botão direito do mouse e escolha a opção de Git Bash. 

#### Configurando seu usuário

- Configurar usuário:
`git config --global user.name "seuNomeDeUsuario"`

- Configurar email:
`git config --global user.email "GFGexample@gmail.orgg"`

- Configurar senha:
`git config --global user.password "suaSenhaAqui"`

Após isso, já é possível criar uma cópia do projeto na sua máquina. Dentro da pasta do projeto, insira o seguinte comando: `git clone https://github.com/LarissaRosaIT17/Dell_FirstSteps.git`.

#### Comentário sobre padronização

Existe um passo a passo que deve ser realizado antes de sair codando. O principal é abrir uma _issue_ no git. O nome da issue deve ser simples e de fácil compreensão sobre o que será feito, exemplo: _Criação de Usuários no Banco_.

Informações mais pertinentes sobre essa tarefa devem ser adicionados na descrição. Caso exista uma documentação pertinente, é possível adiconá-la também na descrição da issue.

Após ela ter sido criada, ela terá um número associado a mesma, como no caso dessa issue, é #3.

---

#### Finalizações

Agora na pasta do projeto, chamada Dell_FirstSteps, vamos executar o comando para instalar o Vue e os Cookies, no frontend.

- Vue: `npm install vue-router@4`
- Cookies: `npm install vue-cookies --save`

Após isso. instale o Vuelidate.

- `npm install @vuelidate/core @vuelidate/validators`

Para buildar o projeto, utilize o comando: `dotnet build`.
Para rodar o projeto, utilize os seguintes comandos nas pastas de backend ou frontend: 

- Backend: 
  - `dotnet add package Microsoft.EntityFrameworkCore.Design`
  - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
  - `dotnet ef database update`
- Frontend: 
  - `npm install`
  
### DDS- Dell Design System
O [Dell Design System (DDS)](https://www.delldesignsystem.com/) é uma biblioteca que visa padronizar os elementos visuais das aplicações Dell. 

**Instalação geral do DDS:**

<br>

Para que seja possível utilizar DDS sem complicações,  siga os passos abaixo: 
- Acesse https://dcsartifacts.dell.com/ui/login/  e logue com seu usuário Dell (nome_sobrenome) e senha do notebook Dell.
- Clique no canto direito superior em Welcome e depois em Set me Up - > NPM.
- Mude o repository pra dx-npm-prod.
- Insira a senha do notebook novamente no campo de insert your credentials.
- Copie o último código que aparece na página, que começa com @<SCOPED>.
- Vá para o Windows file explorer -> Meu computador, C: -> Usuários -> Nome_Sobrenome.
- No arquivo .npmrc (se não existir pode criar), cole o código copiado anteriormente e altere o <SCOPED> por dds.
- Vá no front do projeto, abra o terminal, digite `npm config set strict-ssl false` e rode o comando.
- Digite `npm install --save-dev @dds/components --registry=https://artifacts.dell.com/artifactory/api/npm/dx-npm-prod` e rode comando.
- O @dds/components deve estar no seu package.json e você já pode usar o Javascript do DDS. 

**Utilizando um atributo do DDS**

<br>

Para utilizar um atributo do dds nas páginas, é necessário:<br> 
- Ter o dds instalado conforme o tutorial anterior. 
- Declarar o DDS no script da página que está sendo estilizada:<br> 
  Quando usar Typescript: *declare var DDS: any;*<br>
  Quando usar Javascript: *var DDS = window.DDS;*<br> 
  
- Inicializar o atributo na interface, por exemplo, puxando um dropdown do dds: `interface Data { randomVar: unknown | null }`

- Declarar o atributo no data do export default defineComponent: `export default defineComponent({ data() : Data { return { randomVar: null, }};)` 

- Criar a variável que recebe o atributo requerido do dds dentro do mounted() no export default defineComponent: `export default defineComponent({ mounted() { this.randomVar = DDS.dropdown(this.$refs.randomVar)}})`

<br>


OBS.: Dentro do parâmetro deste exemplo com dropdown, o código em parênteses , *this.$refs*, é o "get" do Vue.
Para aproveitar melhor tudo o que o DDS oferece, sempre analisar os "Events" no fim da página, em que constam vários métodos que podem satisfazer as necessidades da página que está sendo estilizada. 

<br>

No exemplo de dropdown: 
<br>
![image](https://user-images.githubusercontent.com/122370584/221579964-f9eb32b8-9530-4786-834e-64e91ff15b2f.png) 

- Clicar em "copy" no código que é apresentado no site e colar  na página que precisa da estilização. **OBS.:** Para eventuais dúvidas em relação a Javascript e DDS, entre em contato com Norton Zambone ou Aaron Carneiro via chat no Teams ou [acesse o Teams do DDS](https://teams.microsoft.com/l/team/19%3a9354a17c845d4069af19fccdd15fdecb%40thread.skype/conversations?groupId=e7dbbb3b-12b5-444b-982f-3deb03d25261&tenantId=945c199a-83a2-4e80-9f8c-5a91be5752dd). 

**Sobre a Base de Dados** <br> 
Como a aplicação foi criada com Entity Framework, a criação da Base de Dados foi feita automaticante. Entretanto, os primeiros dados do banco foram populados de forma manual (seeding) no arquivo ApplicationContext. 

  
### Executando a aplicação a partir do editor de texto local

Para executar a aplicação desenvolvida no projeto, após fazer o clone do git e as configuraçãos de ambiente já mencionadas anteriormente, é necessário:
- Backend:
  - Selecionar a parte do projeto que trata do backend (Diretório DellConnectBack)
  - Abrir um terminal integrado a partir dele
  - Executar o comando `dotnet run serve`. 
- Frontend:
  - Selecionar a parte do projeto que trata do backend (Diretório DellConnectFront)
  - Abrir um terminal integrado a partir dele
  - Executar o comando `npm run serve`. 
  - Clicar no link do localhost para abrir a aplicação de forma local no seu navegador padrão.
  
#### Erros comuns
  
- Axios:
  - Caso occora um erro de Axios, rode o seguinte comando no terminal do frontend: `npm install --save axios vue-axios`

- Database
  - Caso sua database não esteja funcionando corretamente, delete a pasta Migrations do seu projeto, e execute os seguintes comandos no terminal do Backend:
    - `dotnet ef migrations add <MigrationName>`
    - `dotnet ef database update`
    
- EntityFramework não encontrado
  - Caso seu programa não consiga instalar as dependencias do backend, e apresenta um erro de encoding em linhas aleatórias, pode ser um problema com o Nuget. Tente rodar os seguintes comandos no terminal do Backend:
    - `dotnet nuget locals all --clear` E tente instalar as dependencias novamente
    

---

### Tutorial Rápido de Git

Dentro da pasta dedicada, abrir o git bash, e entrar na branch específica:
_ex: `git checkout nomeBranch`_ No caso do projeto, trabalhamos a partir da dev

- Para verificar se está na branch certa:
`git branch`

- Para resgatar o código atualizado:
`git pull`

- Para resgatar o código atualizado de uma branch específica:
`git pull origin nomeBranch`

- Para criar uma branch nova:
`git checkout -b nomeDaBranchNova`

- Para trocar de branch:
`git checkout nomeBranch`

- Para abrir no VsCode:
`code .`

#### Padronização de nome de Branch

Vamos trabalhar com uma padronização simples para a nomenclatura das branchs. A ideia é simples:

- seuNome ou nomeGrupo/tipoDemanda/#numeroIssue (Issue criada anteriormente)
  - Exemplo: _alexya/documentation/#3_

  ### Sobre Testes Unitários
Foi acertado que o Definition of Done (DOD) para testes seria de no mínimo 50% no backend. A realização de testes no backend foi realizada com Nunit. A fim de garantir a realização dos testes com eficiência, uma Spike foi criada na primeira Sprint e os cursos abaixo serviram de base para esta Spike:
- [CURSO WEB API COM MODULO DE TESTES](https://delldigital.udemy.com/course/the-complete-guide-to-aspnet-web-api/) 
 
- [CURSO DE TESTE COM .NET E ENTITY](https://delldigital.udemy.com/course/complete-guide-to-unit-testing-in-net-core-nunit-xunit/) 
 
- [CURSO GERAL DE TESTES EM C#](https://delldigital.udemy.com/course/unit-testing-csharp/)

- [CREATING A TEST – C#](https://www.linkedin.com/learning/c-sharp-test-driven-development-14275015/creating-a-test)

- [Understand the NUnit framework - ASP.NET Core](https://www.linkedin.com/learning/advanced-asp-dot-net-core-unit-testing/understand-the-nunit-framework?autoplay=true) 

  Dito isto, recomenda-se que os próximos times do IT Academy realizem uma Spike de testes para ampliarem seus conhecimentos sobre testes.
  
#### Comitando trabalho

Dentro do Vs code, existem opções que podem auxiliar no processo de dar commits e pushs. Assim que finalizar seu serviço, vá no terceiro ícone da barra lateral do VsCode. Lá é possível ver a opção de realizar commit. No campo acima do botão, descrever o trabalho que foi feito. Selecionar somente as files do programa que foram trabalhadas e clicar no ícone de <kbd>+</kbd>. Assim que finalizado, clicar no botão de commit. Quando completo, clicar em sincronizar mudanças, para enviar o trabalho feito para o git.

<br/>

Assim que o trabalho estiver terminado:
Abrir um Pull Request da sua branch para a branch dev no git. Aguardar aprovação.
