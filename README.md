# CashFlowTest

## Frontend

Baixar o Docker e rodar os seguintes comandos dentro da pasta .\frontend:

`docker build -t cashflowtestfrontend-image .`

`docker run --name cashflowtestfrontend-container -d -p 4200:80 cashflowtestfrontend-image`

## Backend

Abrir o código diretamente no Visual Studio e rodar o projeto CashFlowTest.WebApi.csproj

## Execução

Abrir o browser no endereço: `http://localhost:4200/`
