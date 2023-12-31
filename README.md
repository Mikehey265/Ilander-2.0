# Ilander-2.0

Ilander is a game made as a project for finishing first course in FutureGames called "Fundamentals of C# Programming with Unity3D Engine" led by amazing Sebastian Bularca. Game is a type of 3D side-scrolling, created in Unity 2022.3.9.f1 and C# by me - Michał Szcząchor.

## Table of contents
* [General Info](#general-info)
* [Key bindings](#key-bindings)
* [Game Mechanics](#game-mechanics)
* [Code](#code)
* [Sources](#sources)

## General info

This project is made with the new input system and cinemachine. For now, game can be played only by one player and only with a keyboard. The first scene player should see is Main Menu scene. From there, there are 3 levels that come one after another. There is only one win condition: player needs to go from launch pad (blue) to the landing pad (green). However, there are two lose conditions: if player touches anything else, health is reduced and when health hits zero, player need to restart the current level. Second lose condition is running out of the fuel, that is being used when using main rocket thrust. Player can beat his own high scores that are displayed in main menu and at the end of every level. Each level has its own high score. 

## Key bindings

* A - tilt rocket left
* D - tilt rocket right
* SPACE - use rocket booster
* Esc - enter / exit pause menu

## Game mechanics

* Movement - movement is really simple, there are only 3 controls: A and D keys are used to tilt the rocket left and right, SPACE is used for main rocket booster. Gravity does the rest.
* Physics system - player can collide with environment and gravity is alwyas pulling player down.
* Health & Fuel system - fully working Health and Fuel system with corresponding UI for player to see its current level.
* Cinemachine camera - camera is smoothly following the player and has bounds for player to not see what is hiding behind the level.
* Level system - game currently has 3 fully working levels. You can move to the next level by passing the previous one.
* Moving obstacles - in level 2 and 3, there are moving obstacles. I am explaining how I made them work in code section.
* PowerUp system - through the levels I put powerups. Powerups have fixed locations, but are spawned with random effects. So player never know what powerup is he gonna get. Apart from good (buff) powerups, there are also debuffing ones. When player triggers the powerup which has timer on itself, player can see in the UI for how long this powerup is gonna work. There is one powerup that has no timer, so the UI won't show up after collecting it. This specific powerup heals player.
* Scoring system - scores are being saved in PlayerPrefs. Every level has its own high score for player to see after finishing one of the levels or in main menu. There is also a button in main menu that resets every high score.
* Pause menu - while playing game, player can hit Esc key to pause the game. While in pause menu, one can resume current game, restart current level or go back to main menu.
* Menu system - game has a Main Menu which by default should be the first scene that player sees.

## Code

I tried to use as much optimized code as I could for my current knowledge. For powerups I used scriptable object and abstract class to inherit from so every PowerUp script override the abstract methods. Back at the time I used to use a lot of GetComponent or FindObjectOfType. For this project I used Events instead. <br/>
Score is based on time and numbers of collisions. Equation looks like this: 100 * ( 100 / time) / (number of collisions + 1). If there are 0 collisions, last division is ignored.
<br/>
The most math in this project I used for creating an "ObstacleMover" script. It does.. move an obstacle, thanks to the sine wave going back and forth, adding vector to the starting position of an obstacle and applying movement factor from 0 (starting position) to 1 (starting position + added vector). I added comments in the script so it would be easier to understand.

## Sources

* An idea of a gameplay came to my mind from c# course from GameDev.tv. I used to learn basics from them and one of the projects called "project boost" was the one I relied on. Here's the link to the course: https://www.udemy.com/course/unitycourse2/ 
* For new input system I used recorded lessons from FutureGames and also this video: https://www.youtube.com/watch?v=zIhtPSX8hqA 
* I made User Interface mostly by myself, but I want to put a link to a long tutorial where I learned more intermediate things, as well as this UI. Here's the link: https://www.youtube.com/watch?v=AmGSEH7QcDg&t=7449s , and I actually created "Kitchen Chaos" game with this tutorial here: [Kitchen Chaos](https://github.com/Mikehey265/KitchenChaos) 
* Spawning powerups: https://www.youtube.com/watch?v=E40ZdSaGsZY 
* Moving obstacle feature was also done thanks to the course from GameDev.tv. I used my knowledge of sine waves and Vectors to combine it into working system. The same link to the same course: https://www.udemy.com/course/unitycourse2/ . And I will also attach links to wikipedia about sine wave: https://en.wikipedia.org/wiki/Sine_and_cosine and turn: https://en.wikipedia.org/wiki/Turn_(angle)

