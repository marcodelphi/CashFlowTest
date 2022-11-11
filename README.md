# CashFlowTest

## Build do Frontend

Baixar o Docker e rodar os seguintes comandos dentro da pasta .\frontend:

`docker build -t cashflowtestfrontend-image .`

`docker run --name cashflowtestfrontend-container -d -p 4200:80 cashflowtestfrontend-image`

## Backend

Abrir o código diretamente no Visual Studio e rodar o projeto CashFlowTest.WebApi.csproj

Para acessar diretamente os endpoints, abrir o browser no seguinte endereço: `http://localhost:33001/swagger/index.html`

## Abrir o frontend

Abrir o browser no endereço: `http://localhost:4200/`
