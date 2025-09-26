# Simple Puzzle Game - Gustavo Boni

## Sprites Importing

Importing Size PPU 100

Assuming Target Resolution: 1080 x 1920

Previews are imported just to use as a reference when building UI

## Code Formatting

- private attributes uses the notation: \_camelCase
- public attributes uses PascalCase
- protected uses PascalCase;

## Architecture

SimplePuzzleGameManager handles all game initialization. It initializes the views and the Grid using dependency injection.
GameViews are updated through UnityEvents
GridController controls the Unity Grid and create the Blocks.
BlockData is a ScriptableObject and holds a BlockDefinition. Each BlockData has a reference to a BlockColor which will be used to check if a matches existis. You can in the future easily add special blocks that matches more than one Block just by adding a new BlockColor in the array.

Important Note: inside custom grid folder you can find a tentative of implementation of a custom grid. However i notice it was going to take longer so decided to swith back to Unity's grid and it cost me some precious time.

## Missing

- Block handles input
- Check Matches
- Fill empty spaces
