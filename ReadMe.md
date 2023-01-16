# Documentação Dell First Steps
Essa documentação é pertinente ao projeto Dell First Steps, um programa colaborativo entre os times de estagiários da Dell. O projeto teve seu início no dia 02 de Janeiro do ano de 2023 e continua em desenvolvimento ativo.

### Tecnologias Utilizadas
| **Tecnologia**  | **Instalação**        |
| -----------     | :----------:          |
| **SDK.NET**     |   Workspace One       |
| **Dotnet**      |   Cmd                 |
| **NPM/Node**    |   Workspace One       |
| **VUE.js**      |   Cmd                 |
| **NUnit**       |   Cmd                 |
| **Selenium**    |   Plugin por Browser  |
| **Git**         |   Workspace One       |


### Instalações
Para realizar as instalações necessárias para que o programa possa rodar com sucesso em seu ambiente, é necessário seguir os seguintes passos:

- Instalar o SKD.NET utilizando o aplicativo Workspace One da sua máquina.
- Instalar o Dotnet. Para fazer isso, execute o seguinte comando via command prompt: `dotnet tool install --global dotnet-ef` Assim que a instalação for concluída, siga para o próximo passo.
- Instalar o NPM/NODE utilizando o aplicativo Workspace One da sua máquina.
- Istalar o NUnit. Um tutorial para realizar isso pode ser visto aqui: [Tutorial de Instalação Nunit](https://docs.nunit.org/articles/nunit/getting-started/installation.html)
- Instalar o Selenium. Existe um plug-in no Microsoft Edge que pode ser instalado no seu Browser.
- Instalar o Git for Windows utilizando o aplicativo Workspace One da sua máquina.
- Existe tambem a opção de instalar o Github for Desktop, caso tenha conhecimento da ferramenta.

Após as instalações. Podemos seguir para utilizar o git para ter uma cópia do código. 

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

Existe um passo a passo que deve ser realizado antes de sair codando. O principal é abrir uma Issue no git. O nome da issue deve ser simples e de facil compreensão sobre o que será feito, exemplo: _Criação de Usuários no Banco_.

Informações mais pertinentes sobre essa tarefa devem ser adicionados na descrição. Caso exista uma documentação pertinente, é possivel adicona-la tambem na descrição da issue.

Após ela ter sido criada, ela tera um numero associado a mesma, como no caso dessa issue, é #3.

---

#### Finalizações

Agora na pasta do projeto, chamada Dell_FirstSteps, rodar o comanado para instalar o Vue e os Cookies.

- Vue: `npm install vue-router@4`
- Cookies: `npm install vue-cookies --save`

Para buildar o projeto, utilize o comando: `dotnet build`.
Para rodar o projeto, utilize os seguintes comandos nas pastas de backend ou frontend: 

- Backend: 
  - `dotnet add package Microsoft.EntityFrameworkCore.Design`
  - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
  - `dotnet ef database update`
- Frontend: 
  - `npm install`
  
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
  - Caso occora um erro de Axios, rode o seguinte comando no terminal do frontend: `install --save axios vue-axios`

- Database
  - Caso sua database não esteja funcionando corretamente, delete a pasta Migrations do seu projeto, e rode os seguintes comandos no terminal do Backend:
    - `dotnet ef migrations add <MigrationName>`
    - `dotnet ef database update`

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

#### Comitando trabalho

Dentro do Vs code, existem opções que podem auxiliar no processo de dar commits e pushs. Assim que finalizar seu serviço, vá no terceiro ícone da barra lateral do VsCode. Lá é possível ver a opção de realizar commit. No campo acima do botão, descrever o trabalho que foi feito. Selecionar somente as files do programa que foram trabalhadas e clicar no ícone de <kbd>+</kbd>. Assim que finalizado, clicar no botão de commit. Quando completo, clicar em sincronizar mudanças, para enviar o trabalho feito para o git.

<br/>

Assim que o trabalho estiver terminado:
Abrir um Pull Request da sua branch para a branch dev no git. Aguardar aprovação.
