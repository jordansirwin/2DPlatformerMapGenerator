using System;
using UnityEngine;

namespace jsi.PlatformerMapGenerator {
    
[Serializable]
public class TileInfo {
    [Tooltip("Pixel color on image to look for")]
    public Color pixelColor;
    [Tooltip("Tile to render when pixel color is found")]
    public GameObject tilePrefab;
}
}