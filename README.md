# Ilander-2.0

Ilander is a game made as a project for finishing first course in FutureGames called "Fundamentals of C# Programming with Unity3D Engine" led by amazing Sebastian Bularca. Game is a type of 3D side-scrolling, created in Unity 2022.3.9.f1 and C# by me - Michał Szcząchor.

## Table of contents
* [General Info](#general-info)
* [Game Mechanics](#game-mechanics)
* [Code](#code)
* [Sources](#sources)

## General info

This project is made with new input system and cinemachine. For now, game can be played only by one player and only with keyboard. A - tilt rocket left, D - tilt rocket right, SPACE - use rocket booster. The first scene player should see is Main Menu scene. From there, there are 3 levels that come one after another. There is only one win condition: player needs to go from launch pad (blue) to the landing pad (green). However, there are two lose conditions: if player touches anything else, health is reduced and when health hits zero, player need to restart the current level. Second lose condition is runing out of the fuel, that is being used when using main rocket thrust. Player can beat his own high scores that are displayed in main menu. Every level has its own high score. 

## Game mechanics

* Movement - movement is really simple, there are only 3 controls: A and D keys are used to tilt the rocket left and right, SPACE is used for main rocket booster. Gravity does the rest.
* Physics system - player can collide with environment and gravity is alwyas pulling player down.
* Health & Fuel system - fully workinhg Health and Fuel system with corresponding UI for player to see its current level.
* Cinemachine camera - camera is smoothly following the player and has bounds for player to not see what is hiding behind the level.
* Level system - game currently has 3 fully working levels. You can move to the next level by passing the previous one.
* Moving obstacles - in level 2 and 3, there are moving obstacles. I am explaining how I made them work in code section.
* PowerUp system - throughout the levels i put powerups. Powerups has fixed locations, but are spawned randomly. So player never know what powerup is he gonna get. Apart from good (buff) powerups, there are also debuffing ones. When player triggers the powerup and it has timer on itself, player can see int he UI how much time this powerup is gonna work. For now there is only one powerup that has no timer, so the UI won't show up.
* Scoring system - scores are being saved in PlayerPrefs, every level has its own high score for player to see after finishing one of the levels or in main menu. There is also a button in main menu that resets every high score.
* Menu system - game has a Main Menu which by default should be the first scene that player sees. While playing game, player can hit Esc key to pause the game. While in pause menu, one can resume current game, restart current level or go back to main menu.

## Code

I tried to use as much optimized code as I could for my current knowledge. For powerups I used scriptable object and abstract class to inherit from. Back at the time I used to use a lot of GetComponent or FindObjectOfType. For this project I used Events instead. <br/>
Score is based on time and numbers of collisions. Calculation looks like this: 100 * ( 100 / time) / (number of collisions + 1). If there are 0 collisions, last division is ignored.
<br/>
