using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace jsi.PlatformerMapGenerator {

[CustomPropertyDrawer(typeof(LayerAttribute))]
class LayerAttributeEditor : PropertyDrawer
{

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// One line of  oxygen free code.
		property.intValue = EditorGUI.LayerField(position, label,  property.intValue);
	}
}
}