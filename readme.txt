Projeto executado com o dotnet core 2.2 + Docker

Acessar no powerShell o diretório onde se encontra o arquivo docker-compose.yml

Passos para Rodar a Aplicação

1 - Start no Docker
2 - Executar no powershell "docker-compose build"
3 - Executar no powershell "docker-compose up"
4 - Pelo postman acessar o endPoint http://localhost:7000/api/inicial/AddItensInicias(Obs: Sem parâmetro) para registrar os tamanhos, sabores e adicionais
5 - verificar o arquivo endpoints.txt (lá estão todos os endpoints da aplicação)

Obs: para acessar o banco pelo Microsoft SQL Server Management Studio
Nome servidor: localhost,1400
Usuario: sa
Senha: Fgv101007
