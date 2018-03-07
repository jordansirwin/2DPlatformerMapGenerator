# 2D Platformer Map Generator

Creates a 2D Platformer style map by generating tiles for each pixel on a texture.


## Quick Start

Import the package into your Unity project to get a preconfigured Scene with an example map and tiles ready to go. All assets for this package will be imported into a folder called "2DPlatformerMapGenerator".

Once imported, load the scene "2DPlatformerMapGeneratorExample" and hit play. You'll see an example map load using the included "map01.png" texture and various included tiles.


## Details

You really only need the following scripts to use this package:

* MapGenerator.cs
* TileInfo.cs

Attach MapGenerator to a GameObject in the scene, then configure it as neccessary:

**Parent Object**

All of the generated map tiles will be added to the scene as a child of this object.

**Color Match Threshold**

I found reading pixels from textures to not always be 100% accurate due to occassional rounding errors in the float conversion. Since each tile will be rendered based on a pixel color match, I introduced this threshold to allow for minor variation in colors to still match. Typically, setting this to a low value such as **0.01f** is more than enough to compesate. If you want 100% match requirements, simply set this value to **0**.

**Ignore Pixel Alpha Threshold**

Any pixels with an alpha setting equal or below this value will be ignored. 

**Tile Layer**

The layer to add all generated tiles too.

**Missing Tile Prefab**

If a pixel is assigned to a tile, but the prefab is null (unassigned), this prefab will be used instead. Typically I set this to a hot pink colored asset so it's obvious in the scene.

**Tile Info**

This array maps pixel colors to a tile to render. Each element has the following attributes:

*Pixel Color*: When this pixel color is found the the map, it will render the corresponding tile.
*Tile Prefab*: The tile to render when the pixel color is matched.

**Map To Generate**

The texture representing the map you want to generate tiles for. Every pixel will be scanned and compared for a Tile Info mapping (or skipped if within the Alpha Threshold) and a GameObject will be instantiated based on the assigned tile prefab.

When importing an image for the map be sure to set the following attributes on the texture:

* Filter Mode: Point (no filter)
* Compression: None
* Read/Write Enabled: True


## Editor Options

When in the Editor, there is a custom Menu called "2DPlatformerMapGenerator" with two options:

**Generate Map**

Will generate the map so you can see it during editing the scene.

**Clear Map**

Will clear all of the generated map tiles. It is IMPORTANT to do this, otherwise they'll become permanant members of your scene :D


## Attributions

The sprites used for tiles are from the **Platformer Art Deluxe** pack on **OpenGameArt.Org**:
https://opengameart.org/content/platformer-art-deluxe



