## LP1 Projeto 2

### Humanos vs Zombies

### Autores:
* [Rodrigo Marques] a21802593
* [Rafael Castro e Silva] 21805637  
* [Rodrigo Pinheiro] a2180488


#### Participação
* A participação geral do grupo foi equilibrada entre o Rafael Silva e o Rodrigo
Pinheiro, enquanto o Rodrigo Marques acompanhou o projeto de forma mais leve.

* Rodrigo Marques: Criou a classe `MainMenu` e foi o autor dos dois diagramas
apresentados no trabalho.

* Rafael Silva: Realizou a maioria da procura dos NPC's no mapa de jogo e resolveu
vários *bugs* que foram surgindo ao longo do projeto. Embora a solução original
realizada pelo Rafael não tenha sido a final, grande parte do código foi reutilizável,
nas classes `Pathfinder`, `Board` e `Tile`. Por sentido de utilidade criou dois *overloads*
de operadores para a `struct` `Position` criada pelo colega Rodrigo Pinheiro.
Também criou a interface `ÌBoardActionable` e a sua implementação devida.

* Rodrigo Pinheiro: Realizou em conjunto com o Rafael a arquitetura base do projeto,
criou a base para as classes `Agent` e as suas estendidas, `Render`, `Game`, `Shuffle`. 
Criou o sistema de *tags* e resolveu vários problemas quanto ao tabuleiro toroidal
em conjunto com o Rafael. Para alem destes tentou criar o sistema de *save files* sem sucesso.
Escreveu o Relatório.

#### Descrição da Solução

* O programa está baseado à volta de duas classes principais, `Agent` e `Tile`.
Os agentes tratam de saber se são humanos ou zombies e de como interagir, enquanto
as *tiles* fazem a unidade base do tabuleiro de jogo, sendo que estas conte-em um
ocupador do tipo `Agent`.

* A procura no tabuleiro de forma a que este se torne toroidal está na classe
`PathFinder` e no movimento dos humanos e dos zombies. O *pathfinder* então calcula
as distâncias tendo em conta se o agente atual se encontra antes ou depois de metade
do mapa. Depois desta distância calculada, é então usada para a procura do inimigo
mais próximo e da direção da casa a andar.

##### Assim Sendo o UML das classes que compõem o programa é o seguinte:

![DiagramaUML]

#### [Repositório utilizado][rep]



[rep]:(https://github.com/RodrigoPrinheiro/lp1_project2)
[Rodrigo Marques]:https://github.com/RodrigoMarques23
[Rafael Castro e Silva]:https://github.com/RafaelCS-Aula
[Rodrigo Pinheiro]:https://github.com/RodrigoPrinheiro