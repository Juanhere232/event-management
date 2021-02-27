# Gestão de Evento - WEB API

# Ferramentas utilizadas
  
  
  - ASP.NET Core 5
  - CSharp
  - Entity Framework Core
  - Docker
  - SQL Server
  - Swagger

# Como utilizar


## Docker (Apenas SQL SERVER)

Primeiramente você irá precisar instalar o [Docker](https://www.docker.com) (Siga os passos de instalação conforme o seu sistema operacional). <br/>
Após a instalação do Docker, faça o clone do projeto. <br/>
Altere o arquivo `ef-cofiguration.json` localizado na pasta `EventManagement.Api`. Altere para o IP da sua maquina:
![image](https://user-images.githubusercontent.com/38699623/109399212-3e88d000-7920-11eb-97d3-8d3224eaae95.png)
<br/>
Abra o terminal na raiz do Projeto. <br/>
Execute o comando `docker-compose up -d`.

## Ambiente Local

Para executar o projeto você precisa do [Kit de Desenvolvimento da Microsoft](https://dotnet.microsoft.com/download/dotnet/5.0). (Siga os passos de instalação conforme o seu sistema operacional). <br/>
Após instalado, navegue novamente até a pasta `EventManagement.Api`. <br/>
Execute o comando `dotnet restore`. <br/>
Após a execução anterior, execute o comando `dotnet run`. <br/>
Uma janela como essa deverá abrir:<br/>
![image](https://user-images.githubusercontent.com/38699623/109399300-d1c20580-7920-11eb-8aa7-158d6003fd8a.png)

## Ambiente Grafico/Documentação

Com o Projeto sendo executado. Abra o navegador de sua preferência e navegue até a url https://localhost:5001/swagger/index.html  <br/>
Após isso você pode testar a API.
