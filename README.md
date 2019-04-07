# Simon - Bex Edmondson

## Instructions for Artists
I built the screen manager system with quick flow prototyping in mind, specifically so that artists could start setting up basic flow without having a coder working alongside them. Note: one current limitation is that all screen objects must be inactive in the scene for the game to initialise properly.

### How to Add a Screen
Adding a screen is straightforward process:
1. Add a new GameObject under the UI object.
2. Add a Screen component to that GameObject.
3. Under the right-click menu, create a new ScreenType in the ScreenType folder. Name it something sensible!
4. On the UI object, there is a ScreenManager script. Add one to the length of the screen list.
5. At the bottom of the list, notice the duplicate item that's just appeared. Change the ScreenType parameter to the new screen type you just created, and drag in your new Screen GameObject to the Screen Object slot.

That's it!

### Moving Between Screens
Moving between screens is also straightforward:
1. Add a button to a screen somewhere.
2. On the Button component, add a new slot to the OnClick list.
3. Drag in the UI object (the one with the ScreenManager component) to the empty slot on the left.
4. In the dropdown, select ScreenManager>SwitchToScreen
5. In the new slot that appears, select the ScreenType you'd like to transition to from that button.
6. Press play in the editor and click on the button: the screen should transition in correctly!

### Screen Transition Animations
1. Add an animator controller to the screen you want to transition in or out. 
2. The transition in animation should follow directly from the Entry state. 
3. Add a trigger called TransitionOut, and a state called something similar. 
4. Add a transition between the in and out states, and place the trigger on that transition.

The screen manager should now correctly handle the transition animations.

## Future Improvements
There are lots of improvements I'd like to make, but these are the ones I'd do first!

- I'd primarily like to refactor the screen manager so every screen is a prefab instantiated on boot, to get rid of the rapidly-growing scene hierarchy and to remove the requirement of all the screens being inactive in the scene.

- I'd like to improve the ScreenManager editor more so that adding a screen is even easier - maybe put in an Add button or something like that.

- I definitely want to edge-case-proof the ScreenManager a bit more - it's currently possible to try to transition to two screens at once from a button. I haven't tried it, and I think the code should handle things correctly, but I'd like to make that impossible. There are also possible issues around transitioning between screens during transition animations that I'd like to fix.

- I want to add a volume control button or slider to the Settings menu.

- I'd also like to refactor the DifficultyButton so it inherits from Button instead of just being on the same object as a Button component.

## Attribution
Sounds from FreeSound.org: https://freesound.org/people/neatonk/
Star sprite from OpenGameArt.org: https://opengameart.org/content/sparkles
