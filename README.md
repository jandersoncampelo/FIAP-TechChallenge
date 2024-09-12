[![.NET](https://github.com/jandersoncampelo/FIAP-TechChallenge/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jandersoncampelo/FIAP-TechChallenge/actions/workflows/dotnet.yml)
# FIAP-TechChallenge01
## API de Portal de Investimentos

Esta é uma API para um portal de investimentos desenvolvida em C# utilizando o framework .NET. A API fornece endpoints para realizar operações relacionadas a usuários, ativos financeiros, portfólios e ordens de investimento.

## Configuração do Ambiente

1. **Pré-requisitos:**
   - [.NET SDK](https://dotnet.microsoft.com/download)
   - [SQL Server](https://www.microsoft.com/sql-server/)

2. **Configuração do Banco de Dados:**
   - Execute os scripts de criação de tabelas localizados em `DatabaseScripts` no seu servidor SQL Server.

3. **Configuração da Aplicação:**
   - Abra o arquivo `appsettings.json` e atualize a string de conexão com o banco de dados.

## Como Executar a Aplicação

1. Navegue até o diretório raiz da aplicação no terminal.

2. Execute o seguinte comando para compilar e executar a aplicação:
   ```bash
   dotnet run
3.Acesse a API em `http://localhost:5000` no seu navegador ou através de ferramentas como o Postman.

## Documentação da API
A documentação da API está disponível no endpoint /swagger. Acesse `http://localhost:5000/swagger` para explorar os endpoints e testar as operações.

**Endpoints Principais**
- Usuários:

  - `GET /api/user/profile: Recuperação do perfil do usuário.`
  - `PUT /api/user/profile: Atualização do perfil do usuário.`

- Portfólio:

  - `GET /api/portfolio: Recuperação do portfólio do usuário.`
  - `POST /api/portfolio: Adição de um novo ativo ao portfólio.`
  - `DELETE /api/portfolio/{portfolioId}: Remoção de um ativo do portfólio.`

- Ativos Financeiros:

  - `GET /api/assets: Recuperação da lista de ativos disponíveis.`
  - `GET /api/assets/{symbol}: Recuperação de detalhes de um ativo específico.`

- Ordens de Investimento:
  
  - `GET /api/orders: Recuperação da lista de ordens de investimento do usuário.`
  - `POST /api/orders: Criação de uma nova ordem de investimento.`
  - `DELETE /api/orders/{orderId}: Cancelamento de uma ordem de investimento.`
    
Para mais detalhes sobre os endpoints e seus parâmetros, consulte a documentação da API.

## Contribuição
Contribuições são bem-vindas! Antes de contribuir, abra uma issue para discutir as mudanças propostas.

## Nome dos participantes
Janderson Campelô - RM352814
Gustavo Kazuo - RM352485
Cleyber Silva - RM353086
André Fonseca -  RM353003

## Licença
Este projeto está licenciado sob a MIT License - veja o arquivo LICENSE para detalhes.

**Desenvolvido por Janderson Campelo et al. | 2024**
