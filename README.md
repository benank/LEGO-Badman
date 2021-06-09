# Game Basic Information #

## Summary ##

In a world that looks like a low budget commercial for LEGO, you must use your skills, weapons, and brain to solve the puzzles and complete each level. Beware though! Some levels have traps and enemies that you must avoid or destroy. Destroy objects to gain bricks and use those bricks to build new LEGO sets to progress through each level. Use your environment to your advantage to traverse and get closer to the end.

The game is set in a 3D third person world, with exploration, building and puzzle solving. You are a LEGO villain whose mission is to collect as many GOLD BRICKS as possible. There is one GOLD BRICK in each level that you must obtain to progress to the next level. Each level is unique and will require new strategies to complete it.


## Gameplay Explanation ##

Depending on the level, the game will have to be played differently. For example, a level that requires puzzles to progress through a certain area will slow the gameplay down and make the player puzzle solve. A level with buildables and enemies will require the player to seek resources and kill enemies to progress through the level. Multiple levels exist that choose to either isolate or implement all these systems together.

On start you will see a “Click to Play” screen that takes you to a Main Menu. You have the option to click play, go to settings or quit. Then you go to a level selection screen where you can choose which level you want to play.
On selecting a level to play, your character will spawn into the associated scene/level. You can move your character using WASD keys and look around using your mouse.

Some Specifics:
1. Blueprint Mini Scene  
  a. This level focuses on searching for objects to destroy and collect loot from.   
  b. Once enough loot has been collected, the player can build a Lever at the designated build zone.  
  c. The lever activates a teleporter in the level that can transport the player right next to the GOLD BRICK.  
  
2. Indoor Prison Scene  
  a. This level is a larger map that showcases multiple systems.  
  b. As soon as you spawn in you will see the GOLD BRICK that is behind bars. Your goal is to traverse the two floors of the map and unlock new rooms as you go.  
  c. The first section involves solving a ball-in-a-maze puzzle by rotating the box or platforms using the levers present in the room. This is important as you get an object that may be used to _power down_ the gate that blocks you from the next section.  
  d. The second section involves scouting a room filled with objects that can be destroyed in a few clicks. You will need to destroy enough objects to fill up your inventory and then build something to power down the gate that stops you from using the elevator.  
  e. The third section focuses on defeating the patrolling security guards who have caught you trying to escape. Attack them using the left mouse button or out run them to the conveniently placed teleporter that lets you cross the room quickly. Bewarned, the fire must not be touched otherwise you will respawn again!  
  
3. Ice Mountain Scene  
  a. This level focuses on putting everything together, solving simple puzzles like finding an interesting way to bring a rock onto a button, having multiple buttons that require trial and error to spawn a platform to climb and some parkour that may require a single/double jump, depending on the distance.  
  b. Solving these puzzles requires the player to beware of enemies patrolling the area and can be solved with or without killing them.  
  
4. Tutorial Scene  
  a. This level was originally planned as a tutorial level to introduce the player to various aspects of the game, such as parkour, levers, buttons, and pushable objects, such as rocks.  
  b. After escaping the initial rock prison, the player fights some guards and then must find a way to go down the middle path to obtain the gold brick. There are two side paths that the player can complete in any order to be able to teleport rocks back to the main area to hold the buttons down to open the gates to the gold brick.  

To interact with the levels, players will be using the `Left Mouse Button` to perform melee attacks, the `F` key for interacting with levers, and the `Space` key for jumping and double-jumping.

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

### User Interface

The user interface for our game is pretty straightforward. I created a theme for the different menu displays as well as connected all the buttons to the necessary scenes with different scripts for each screen. For example, the first scene has instructions to “click to play” that takes you to the main menu. Here is the script attached to the front screen: https://github.com/benank/LEGO-Badman/blob/main/Assets/Final%20Project/Scripts/MenuScripts/FrontScreen.cs#L10 After the front screen, the main menu can navigate the player to the level selector screen where we have a list of the different levels created. In addition, I have created a “Game Over” scene that is displayed when the player loses and allows them to try again or go back to the main menu. There is also a pause option using Escape that lets the player pause the game mid play (https://github.com/benank/LEGO-Badman/blob/main/Assets/Final%20Project/Scripts/PauseMenu.cs). There is also a level complete screen. In addition to the main UI navigation of the game, I also created an Inventory UI which allows the player to see what resources they currently have and the count of each item in order to build in the correct build zones. This script is in charge of keeping count of each item in inventory: https://github.com/benank/LEGO-Badman/blob/main/Assets/Final%20Project/Scripts/InventoryPanelItemCounter.cs 


### Enemies

The process of making the enemies and editing the mini figure of the lego itself (badman model) was very difficult to find. I looked up in the micro game tutorials for how to edit an existing minifigure, like the pizza guy one that already existed in the prefabs, but I could not touch anything on it and could not find a way to change anything on it. After looking for hours and hours, trying to find a complete minifigure in Bricklink Studio 2.0 where the tutorials said to make assets to the game, I came across a youtube comment that said to edit the minifig prefab. So I edited the gray minifig that existed in the resources and tried to add the hat and baton for the policeman (the first enemy) in unity from Bricklink Studio 2.0. They did not connect to the player at the beginning and so I figured that they need to be children of the place in which they are supposed to be, so the hat for the head and the baton for the right hand, but then LEGO assets can not be children of other game objects. So I found a tricky way of exporting the assets from Studio 2.0 to Blender and then from blender to export into Unity so the LEGO prefabs can be part of the minifigures. Later, I thought of more enemies that are usually good guys, like a security guard, a soldier, a firefighter and a detective and added their assets the same way.
The enemy AI was a bit tricky, I had to first test the patrol, I tried looking up tutorials on how to move enemies with an AI but I found that, again, the LEGO assets do not behave the same way as a game object. So I found the MoveTo function, Follow function and etc in the MinifigController script the minifigs have on them which included the walking animation[Patrol](https://github.com/benank/LEGO-Badman/blob/85c8717cceb08ba7283ccb28f4dc18799a8f6d9a/Assets/Final%20Project/Scripts/Enemies/EnemyAI2.cs#L112). Later I added the chase the same way but I started adding a distance check. If the player is within chase distance, calculated with the [Vector3.Distance function](https://github.com/benank/LEGO-Badman/blob/85c8717cceb08ba7283ccb28f4dc18799a8f6d9a/Assets/Final%20Project/Scripts/Enemies/EnemyAI2.cs#L86) with the player's gameobject position, then the minifig will chase the player [Chase](https://github.com/benank/LEGO-Badman/blob/85c8717cceb08ba7283ccb28f4dc18799a8f6d9a/Assets/Final%20Project/Scripts/Enemies/EnemyAI2.cs#L120). Lastly, I added the attack animation that Neema made for the player when comparing the same distance as before and a public attack distance variable, like the chase public distance variable [Attack](https://github.com/benank/LEGO-Badman/blob/85c8717cceb08ba7283ccb28f4dc18799a8f6d9a/Assets/Final%20Project/Scripts/Enemies/EnemyAI2.cs#L126). 
The health bar is made using a slider and works in a similar way to the health bar in the last project we did in class, although the enemies do not regenerate. Also, there is an option to not show the health bar [Healthbar](https://github.com/benank/LEGO-Badman/blob/85c8717cceb08ba7283ccb28f4dc18799a8f6d9a/Assets/Final%20Project/Scripts/Enemies/EnemyAI2.cs#L36). When the health bar hits 0, the enemy plays a sleeping animation and is destroyed after 2 seconds, to wait for the animation to finish [Enemy Death](https://github.com/benank/LEGO-Badman/blob/85c8717cceb08ba7283ccb28f4dc18799a8f6d9a/Assets/Final%20Project/Scripts/Enemies/EnemyAI2.cs#L76).


### Animation and Visuals

For combat, there are a few animations that are played to represent a wide sword swing, a reverse wide sword swing, and an impale. When the player presses the `Left Mouse Button` it will play a random melee animation with it’s appropriate sound-clip to provide an immersive combat experience. The jumping, double-jumping, lever-pulling, walking, and enemy death animations are built-in animations from the LEGO game package.

Most of the components used in different levels are built from Bricklink Studio 2.0 to build on top of the “LEGO” theme of the game while environmental detail and terrain is mostly generated from the Terrain game object in Unity. 

The overall graphic design is meant to fit with the LEGO universe, meaning less realistic visuals and more solid colors. The only exception is the GOLD BRICK which has a reflective gold surface. 


### Game Logic / Level Component Design

Since our game is a puzzle oriented game, I wanted to create a system where you could place easily editable interactable components in the scene and hook everything up without needing to write any extra code, but you could if you wanted custom interactions. Players would see the same components in every level so they would know how to work them, but they wouldn’t know exactly what they do because it would differ for each level. The system I came up with allows any “triggerable” object (such as a lever or button that you step on) to trigger a list of “actions”, which are other objects with various Action scripts on them, such as Door or Appear. Underneath the hood, I used a callback system using actions and a data container class called TriggerData to pass data from the interactable input components (levers and buttons) to the objects that they trigger. For example, as a player stands on a button, the button takes some time to recess completely. During this time, the callback is continuously fired with information about how much the button is pressed so that the callback actions can use that to interpolate states. An object with the Door action script on it will smoothly interpolate between its initial position and rotation to the configured end state position and rotation. I wasn’t sure how I would do all of this initially, but I am pretty pleased with the final result and how it all works together!

To create all the models for the level design components, I used Bricklink Studio 2.0, which is a virtual LEGO model editor where you can place bricks and build 3D lego models, then export them to use in Unity with the LEGO Microgame package. 

In terms of game logic, most of the game logic already existed from the default scripts in the microgame package, but we had to adjust them for our purposes. An example of this is the game over event that’s part of their custom event system. Since they already had a global event system set up, I was able to use that to create a “level win” event when the player gets the gold brick. Other scripts can subscribe to this event to do more things when the level is complete, such as showing a level complete screen.

### Inventory and Building

My role involved setting up scripts/components that can be attached to the player or any object needed to act as an inventory. The ItemController script holds the inventory of the object it is attached to, and also has functionality to randomize initially (CreateRandomItemTable()), add (CollectItem()) or drop everything(DropLoot()).


I specified some assets to act as different asset types - stored as a singleton list/component in the GameController prefab. All scene objects that have been tagged as Lootable (or has a parent object tagged Lootable) have a DestroyObjectAction component that is inherited from triggerable action scripts defined before, that allows the player to destroy an object by clicking it until its health is zero. After which, its entire inventory is dropped onto the ground.  
The dropped items have specific behaviour where they drop for some time, float up-and-down for some more time, and then float towards the player. The player can collect it at any point by being close enough to the items. 

The final role was to implement building using blueprints. For this I created another script BlueprintSpecs that holds a dictionary with a list of item types needed per recipe. This is attached to the GameController prefab so it can be accessed as a singleton variable too. The player also has a BlueprintController attached that checks what blueprint is going to be built, checks for enough resources, and mediates the flow of resources from player to blueprint inventory. The blueprint can be pre-selected and built using the BuildZone script that checks if the player is in the collider zone, and is clicking on the designated object; after which it triggers the AppearAction attached on the blueprint.

These three components were successfully designed and integrated into the game smoothly. Main scenes/levels that make use of the inventory/building system are Tutorial 2,3 and Ice Mountain.

## Sub-Roles

### Audio

All of the background audio and some of the sound effects were retrieved from youtube. Here’s the link to each background music:

Outdoor level: https://www.youtube.com/watch?v=wKnS8VPxpHI&t=162s

Indoor level: https://www.youtube.com/watch?v=ZA5EW-DKS6M&t=108s

Snow level: https://www.youtube.com/watch?v=IC4kgqcFEME

Volcano level: https://www.youtube.com/watch?v=sDMoVmrbvT8


Each level that uses background music has a game object called “Background Music” which plays the appropriate soundtrack for the level on a loop. The music that’s played is 2D, meaning the sound volume doesn’t increase or decrease depending on the distance of the player from the actual “Background Music” object.

Other sounds that are played include the teleportation sound, sword swing sounds, GOLD BRICK pick up sound, the default death sound, and enemy damage sound. Those sounds are bound to their appropriate objects and are played when a condition is met. For example, the GOLD BRICK pick up sound is only played when the player collides with the GOLD BRICK.

The sounds for each melee animation are the same audio clip but they play at different times during their animations to sync with their appropriate animation. Each melee animation is associated with an audio clip and when a random animation is played, it’s audio clip is played. 

The walking and jump sounds are default audio clips provided by the LEGO game package.

### Gameplay Testing

As the gameplay tester, you are responsible for having 10 non-team members playtest your game. You fill out the Observation and Playtester Comments form for each of your playtesters and describe the results in the design document (after you share the results with your tea, of course!). For each playtester, fill out an [Observations and Playetester Comments form](https://docs.google.com/document/d/1oW7AulzjpEocDmMikRL0S0PKxlRrOxsEEP7KB-nGg-A/edit?usp=sharing).

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**


### Press Kit and Trailer

https://gameplayproject.wixsite.com/legobadman (Trailer in the presskit website)

I tried using the presskit() but ran into too many problems when trying to make it work so I decided on using Wix to create a similar format to the examples given on the resource document. I chose those specific screenshots for the presskit since they show most of the game's features and they are from angles that look nice, showing off the environments created by our team.
For the trailer, I found the recorder in Unity and decided to use it to record some gameplay to showcase our game. I edited with a bit of Adobe Premiere and mostly photos for Windows. I decided to take footage from all levels and then separate everything into the main features of the game, then decided which parts presented those features the best while keeping the diversity of the levels and including everything.

### Input

Default Input Configuration: `Left Mouse Button` is used to perform melee attacks, the `F` key for interacting with levers, and the `Space` key for jumping and double-jumping. 
The player navigates the level with WASD keys and look around using the mouse. All of the menus are used with mouse clicks and to pause, click `Escape`.

Overall, we just use the mouse and keyboard to navigate through the game. 

Another task I wanted to complete was adding cut scenes before each level to give the player an overview of what to expect in the level. I started this process using Cinemachine and Virtual Cameras in a Timeline animation. Unfortunately, I ran out of time and this will not be showcased in our game. 



### Game Feel

Particle effects: to make the game feel more alive, I added particle effects to various aspects of the game, such as a teleportation effect, death effect, and small ember particles on the fire components. While many of these effects are basic, they help to bring the game to life more.

Player sliding: many areas are meant to be inaccessible to the player based on the slope of the terrain. I was able to modify the PlayerController that was included in the default package that we used to force the player to slide down any slope if the slope is greater than that specified in their PlayerController component. While this is normally meant to restrict the player from climbing steep slopes, it can also be used as a gameplay mechanic with slides or other obstacles that force the player to slide on them.

Camera collision: by default, the included camera only collided with objects on the Environment layer, but I was able to modify it to include all objects that we have, since some of our custom objects are not on the Environment layer.
