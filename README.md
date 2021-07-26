# HyperCubesPrototyp

https://github.com/PyroFourTwenty/ProjektStudiumAugmentedReality21

## Table of Contents
1. [Description](#description)
2. [Lemming](#lemming)
3. [Hypercube types](#hypercube-types)
4. [Hyerpcube functionalities](#hypercube-functionalities)
5. [Unity version](#unity-version)

### Description
***
A little prototyp to test out an idea called hyper cube

### Lemming
***
An only forward moving object that can be triggered by collider hyper cubes to do awesome things
![Image text](https://github.com/Rhayn2366/HyperCubesPrototyp/blob/main/readMeData/Lemming.PNG)
### Hypercube types
***
#### Trigger
Can be activated through events (Ex. clicking on UI)
> Example: 
> Lemming spawn cube, will be activated through the play button.

![Image text](https://github.com/Rhayn2366/HyperCubesPrototyp/blob/main/readMeData/Spawn.gif)

#### Collider
Will be activated once a lemming steps inside them.
> Example: 
> T-, V-, X-Split cubes. When a lemming enters one of these, it will spawn new lemmings that will run into the shape formed direction.

![Image text](https://github.com/Rhayn2366/HyperCubesPrototyp/blob/main/readMeData/VSplit.gif)
### Hypercube Functionalities
***
Rotation on Y
> Adds a set amount of degrees to the lemmings Y axis rotation

Direction
> Forces a lemmings to move towards the set direction

Spawner
> Spawns x amount of Lemmings with a set color, time to live and model
> Can be triggered through the UI or an activator

Activator
> Triggers surrounding Trgger-Hyoercubes (Ex. Spawner)

Split
> Splits a lemmings into different directions (Ex. V-Split) and copies its status into them (Color, TTL, LemmingModel, ..)

Recolor
> Changes the current color of a lemming to the specified one

AddTTL
> Adds a set amount of time to live to a lemming to let it live a little longer

### Unity version
***
2021.1.x
