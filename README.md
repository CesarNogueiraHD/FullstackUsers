Passos para a execução:
1. Verifique se você tem o Docker instalado e se está executando corretamente.
2. Clone o projeto: git clone https://github.com/CesarNogueiraHD/FullstackUsers.git
3. Ao extrair em uma pasta, na pasta raiz você verá as pastas dos projetos back end e front end, junto a um arquivo docker-compose.yml. Execute o docker com: docker-compose up --build -d
  - -- build       - serve para buildar todas as dependências
  - -d (opcional)  - serve para não ficar aberto no terminal, abrirá no Docker e o terminal poderá ser fechado
4. Ao finalizar, verifique no docker se há 3 containeres rodando: sql (banco de dados), api (projeto da API .NET 8) e front end (projeto do Front End Angular 19).
Sempre é bom verificar, pois pode haver algum conflito no momento da execução.
5. Acesse http://localhost:5000/swagger
6. No endpoint [POST] /Users, crie um usuário. Será o usuário inicial:
{
  "name": "Usuário 01",
  "email": "user01@test.com",
  "password": "12345678",
  "passwordConfirmation": "12345678",
  "birth": "2000-01-01"
}

7. Após criar este usuário, acesse http://localhost:4200/login e realize o login com o usuário:
 - email: user01@test.com
 - senha: 12345678
8. Explore o sistema, criando e listando usuários. Apenas a rota [GET] /Users é protegida, sendo obrigatória a geração de um token para utilização.
