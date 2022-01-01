# Project 1

### Student Info

-   Name: Max O'Malley
-   Section: 05S2

### Description

My project utilizes a number of different types of random generation to create a scene featuring a terrain with a randomly generated horde of creatures on top of it.  It features uses of pure random, non uniform random, and gaussian random each to generate a different type of object each.  Crates are used for the pure random generation, being peppered around the map.  The warriors are used to represent the non uniform horde, with a majority of them being randomly generated towards the front of the horde.  Finally, the skeletons all have scale values which are randomly generated using Gaussian values.

### User Responsibilities

In this program, the user will be able to examine the randomly generated terrain from multiple camera angles.  These camera angles can be swapped by clicking on the buttons in the upper left hand corner of the screen, each of which changes you to a different camera angle, examining the terrain and the objects on it in different ways.  The first camera is notable as it is a First Person View, allowing the user to move around the terrain and examine the objects on it as they see fit using the WASD keys to move around, Space to jump, shift to sprint, and the mouse to look around.  

### Known Issues

There are two main errors that are notable.  First, the webGL version on the website, unlike the version in the unity editor, doesn't allow you to look up and down when using the first person controller.  I do know this was mentioned on Slack as being an issue with the FPS controller, but I did want to note it.  Aside from this, occasionally some of the camera views can clip under the terrain depending on how the terrain generates, as the terrain generation is random and I haven't changed my camera's view point to change based on the terrain's height. This only happens occasionally, and mostly only with the horde object mid view, but I did want to note it as an issue. 

### Requirements not completed

_If you did not complete a project requirement, notate that here_

### Sources

-   _List all project sources here –models, textures, sound clips, assets, etc._
-   _If an asset is from the Unity store, include a link to the page and the author’s name_

Unity Assets
Low Poly Crates by PULSAR BYTES: https://assetstore.unity.com/packages/3d/props/low-poly-crates-80037
Low Poly Skeleton by asoliddev: https://assetstore.unity.com/packages/3d/characters/low-poly-skeleton-162347
Low Poly Fantasy Warrior by asoliddev: https://assetstore.unity.com/packages/3d/characters/humanoids/low-poly-fantasy-warrior-127775

Textures
Sand Texture: https://motionarray.com/stock-photos/sand-texture-410743/
