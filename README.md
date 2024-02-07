# API C# .NET CORE 6.0

## SEQUENCIA PARA EXECUÇÃO DA API

* Abra a solução denominada `Avaliacao_CScharp.sln`
* Defina o arquivo `WebApi` como "Projeto de inicialização", e depois compile-a
* Abra o "Console do Gerenciador de Pacotes" (Ferramentas -> Gerenciador de Pacotes NuGet -> Console do Gerenciador de Pacotes) e execute os dois comandos a seguir em sequencia:
    * * Antes verifique ser você possui o postgreSQL instalado em seu computador
    * * Na seleção do "Projeto padrão" selecione a opção `3 - Database\Database`
    * * `Add-Migration inicial_base -Context ContextBase`
    * * `Update-Database -Context ContextBase`
* Se tudo ocorrer bem execute a API com F5
* Após use a rota `/api/AdicionarUsuario` para criar um usuário para gerar o token e acessar as demais rotas
