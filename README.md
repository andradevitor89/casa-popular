# Projeto Casa Popular

## Execução
- Para executar a aplicação, é necessário que a .NET 6 SDK esteja instalada no ambiente.
- Execute o comando 
```
dotnet run --project Aplicacao/
```

- A aplicação está configurada para usar uma massa de testes gerada em tempo de execução. Após a execução, um arquivo de texto chamado `Resultado` será criado no diretório raiz do projeto.

## Testes Automatizados
- Para executar os testes automatizados e coletar a cobertura de código, execute o comando
  
```
dotnet test p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=lcov
```
