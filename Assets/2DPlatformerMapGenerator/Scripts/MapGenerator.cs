using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsi.PlatformerMapGenerator {

public class MapGenerator : MonoBehaviour {

	[Header("Generation")]

	[Tooltip("The parent object for each rendered tile")]
	public Transform parentObject;

	[Tooltip("Proximity for each RBG value for a match")]
	[Range(0.001f, 0.1f)]
	public float colorMatchThreshold = 0.01f;

	[Tooltip("The alpha threshold to ignore a pixel")]
	[Range(0f, 1f)]
	public float ignorePixelAlphaThreshold = 0f;

	[Header("Render")]

	[Tooltip("Layer to apply to all tiles")]
	[Layer]
	public int tileLayer;
	[Tooltip("Prefab to render if a pixel has no tile mapping")]
	public GameObject missingTilePrefab;
	[Space]
	public TileInfo[] tileInfo;

	[Header("Map")]

	public Texture2D mapToGenerate;

	
	void Awake() {
		
		GenerateMap();
	}

	public void GenerateMap() {
		// loop through each xy coordinate in texture and generate a tile for each pixel
		for(int x = 0; x < mapToGenerate.width; x++) {
			for(int y = 0; y < mapToGenerate.height; y++) {
				GenerateTile(x, y);
			}
		}
	}

	void GenerateTile(int x, int y) {

		// get the pixel for the coordinate
		var pixelColor = mapToGenerate.GetPixel(x, y);

		// if pixel is transparent, ignore it
		if(pixelColor.a <= ignorePixelAlphaThreshold) {
			return;
		}

		// look for a matching tile for this pixel color
		var mapping = Array.Find(tileInfo, m => ColorsAreEqual(m.pixelColor, pixelColor));
		// if not found, there's an issue
		if(mapping == null) {
			Debug.LogWarning("No tile mapping found at x" + x + "y" + y + " for color " + pixelColor);
			return;
		}

		// render the tile, or a missing tile if it's not available
		var tile = mapping.tilePrefab == null
			? missingTilePrefab
			: mapping.tilePrefab;
		RenderTile(tile, new Vector2(x, y));
		return;
	}

	void RenderTile(GameObject tilePrefab, Vector3 position) {
		if(tilePrefab == null) {
			Debug.LogWarning("No tile prefab found for position " + position);
			return;
		}

		// render at xy position without rotation
		// and add a child to the parent transform
		var tile = Instantiate(tilePrefab, position, Quaternion.identity, parentObject);
		tile.layer = tileLayer;
	}

	bool ColorsAreEqual(Color a, Color b) {

		// if no threshold, must be exact
		if(colorMatchThreshold == 0f) {
			return a.Equals(b);
		} 

		// compare each RGB color based on a threshold
		// because I've found that some colors tend to be very slightly
		// differnt on occassion
		return Math.Abs(a.r - b.r) <= colorMatchThreshold
			&& Math.Abs(a.g - b.g) <= colorMatchThreshold
			&& Math.Abs(a.b - b.b) <= colorMatchThreshold;
	}
}
}
