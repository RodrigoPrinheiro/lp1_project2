## LP1 Projeto 2

### Humanos vs Zombies

### Autores:
* [Rodrigo Marques] a21802593
* [Rafael Castro e Silva] 21805637  
* [Rodrigo Pinheiro] a2180488


#### Participa��o
* A participa��o geral do grupo foi equilibrada entre o Rafael Silva e o Rodrigo
Pinheiro, enquanto o Rodrigo Marques acompanhou o projeto de forma mais leve.
Para alem disto o grupo considerou que a solu��o tornou-se um pouco confusa para
o que o problema era.

* Rodrigo Marques: Criou a classe `MainMenu` e foi o autor dos dois diagramas
apresentados no trabalho.

* Rafael Silva: Realizou a maioria da procura dos NPC's no mapa de jogo e resolveu
v�rios *bugs* que foram surgindo ao longo do projeto. Embora a solu��o original
realizada pelo Rafael n�o tenha sido a final, grande parte do c�digo foi reutiliz�vel,
nas classes `Pathfinder`, `Board` e `Tile`. Por sentido de utilidade criou dois *overloads*
de operadores para a `struct` `Position` criada pelo colega Rodrigo Pinheiro.
Tamb�m criou a interface `�BoardActionable` e a sua implementa��o devida.

* Rodrigo Pinheiro: Realizou em conjunto com o Rafael a arquitetura base do projeto,
criou a base para as classes `Agent` e as suas estendidas, `Render`, `Game`, `Shuffle`. 
Criou o sistema de *tags* e resolveu v�rios problemas quanto ao tabuleiro toroidal
em conjunto com o Rafael. Para alem destes tentou criar o sistema de *save files* sem sucesso.
Escreveu o Relat�rio.

#### Descri��o da Solu��o

* O programa est� baseado � volta de duas classes principais, `Agent` e `Tile`.
Os agentes tratam de saber se s�o humanos ou zombies e de como interagir, enquanto
as *tiles* fazem a unidade base do tabuleiro de jogo, sendo que estas conte-em um
ocupador do tipo `Agent`.

* A procura no tabuleiro de forma a que este se torne toroidal est� na classe
`PathFinder` e no movimento dos humanos e dos zombies. O *pathfinder* ent�o calcula
as dist�ncias tendo em conta se o agente atual se encontra antes ou depois de metade
do mapa. Depois desta dist�ncia calculada, � ent�o usada para a procura do inimigo
mais pr�ximo e da dire��o da casa a andar.

##### Assim Sendo o UML das classes que comp�em o programa � o seguinte:

![DiagramaUML][#img1]

##### Diagrama do Ciclo principal do jogo:

![DiagramaCiclo][#img2]

#### Refer�ncias
1. [Shuffle Fisher Yates][#ref1]
2. [Visuais de consola][#ref2]
3. [Serializa��o de objetos][#ref3]
4. Alguma da l�gica do tabuleiro em si foi retirada do primeiro projeto
5. [Site para visualizar a acada 5 segundos][#ref4]
#### [Reposit�rio utilizado][rep]


[#img1]:ClassDiagram.png
[#img2]:
[#ref1]:https://jamesshinevar.com/2017/05/28/shuffle-a-list-c-fisher-yates-shuffle/
[#ref2]:https://stackoverflow.com/questions/11150332/how-to-change-foreground-color-of-each-letter-in-a-string-in-c-sharp-console
[#ref3]:https://docs.microsoft.com/en-us/dotnet/standard/serialization/serialization-guidelines
[#ref4]:https://en.wikipedia.org/wiki/KISS_principle
[rep]:(https://github.com/RodrigoPrinheiro/lp1_project2)
[Rodrigo Marques]:https://github.com/RodrigoMarques23
[Rafael Castro e Silva]:https://github.com/RafaelCS-Aula
[Rodrigo Pinheiro]:https://github.com/RodrigoPrinheiro