"# Battleship" 
Hi welcom in API for Battlespip game backend 

To run the game locally:
- download VS2022,
- set up a connection to the postgres database. ConnectionString is in appsettings,
- I post setup postgres docker image : https://towardsdatascience.com/local-development-set-up-of-postgresql-with-docker-c022632f13ea (set up login and password)
- Install all Migrations: Update-Database
- F5

How to play:
Game/NewGame() -          create new two empty boards in the response will return Game id ! it will be required for next endpoints
Game/SetShipsRandom() -   set all not see ships in random places
Game/Shot()-              Strike! You  can enter x and y axes where you want to shoot 1-10. If you do not provide them, they will be randomly selected. Next strike do next user.
