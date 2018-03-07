using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace jsi.PlatformerMapGenerator {

public class GenerateMapMenu : Editor {

	[MenuItem("2DPlatformerMapGenerator/Generate Map")]
	private static void GenerateMap() {
		// clear the map first
		ClearMap();

		// generate map using MapGenerator in scene
		var mg = Editor.FindObjectOfType<MapGenerator>();
		if(mg == null) {
			Debug.Log("No MapGenerator script found in scene");
			return;
		}
		mg.GenerateMap();
	}

	[MenuItem("2DPlatformerMapGenerator/Clear Map")]
	private static void ClearMap() {
		var mg = Editor.FindObjectOfType<MapGenerator>();
		if(mg == null) {
			Debug.Log("No MapGenerator script found in scene");
			return;
		}

		// destroy all of the children (without enumeration)
		while(mg.parentObject.childCount > 0) {
			DestroyImmediate(mg.parentObject.GetChild(0).gameObject);
		}
	}

}
}
