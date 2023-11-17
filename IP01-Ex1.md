Para verificar se o .NET SDK está corretamente instalado em seu sistema e realizar operações como listar versões, remover e atualizar, você pode usar a linha de comando. Dentre os comandos úteis que você pode executar no terminal ou prompt de comando, dependendo do sistema operacional que você está usando (Windows, macOS, Linux), temos:

## 1. Verificar versão do .NET SDK:

    dotnet --version -> Este comando exibirá a versão atualmente instalada do .NET SDK.

## 2. Listar todas as versões do .NET SDK instaladas:

    dotnet --list-sdks -> Esse comando mostrará todas as versões do .NET SDK instaladas no sistema.

## 3. Listar todas as versões do .NET SDK instaladas globalmente:

    dotnet --list-sdks --global -> Este comando exibirá todas as versões globais do .NET SDK instaladas.

## 4. Remover uma versão específica do .NET SDK:

    dotnet --uninstall-sdk <version> -> Substitua <version> pela versão que você deseja remover.

## 5. Atualizar o .NET SDK:

    dotnet --version -> Este comando verificará se há uma versão mais recente do .NET SDK disponível e fornecerá instruções sobre como atualizá-lo. Se uma atualização estiver disponível, siga as instruções fornecidas.