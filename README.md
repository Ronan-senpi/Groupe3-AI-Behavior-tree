# Behaviour Tree Library

Cette librairie réalisée en C# contient tous les éléments requis vous permettant de créer un BehaviourTree facilement.

## Présentation

Notre librairie se base sur deux classes principales, étant la source principale de la structure du BehaviourTree.

### La classe Tree

La première est la classe **Tree**. C'est la classe qui contiendra toute la structure du Behaviour tree. C'est en créant son arbre qu'on va définir le flow des actions. 

### La classe Node
Le second est **Node**. Chaque élément d'un arbre hérite de node. Chaque node est défini par un état. Il y a 4 états possibles : Parmis ces éléments nous avons 2 types de nodes principaux.
- ***NotExecuted*** : the node is in its initialized state and had never been run.
- ***IsRunning*** : the node is currently running,
- ***Success*** : the node obtained a successful result (i.e completing an attack or a condition is true)
- ***Failed*** : the node either failed to run its behaviour or if it's a condition, the condition was false.

Those nodes are divided in 2 main categories :
- Les nodes de control. Ils permettent de guider l'exploration de l'arbre afin de choisir quel Node est le node actuellement en cours d'exécution. Comme par exemple *Selector* et *Sequence*. En plus de ces nodes, d'autres nodes de control sont disponibles comme : 
  - Inverter, qui inverse le resultat d'un node. Un Success 

#### Test