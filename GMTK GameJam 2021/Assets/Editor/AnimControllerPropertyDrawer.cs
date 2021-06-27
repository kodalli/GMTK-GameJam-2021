using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Player.AnimController))]
public class AnimControllerPropertyDrawer  : PropertyDrawer {
    private static class Styles {
        public static readonly GUIContent RemoveIcon = EditorGUIUtility.IconContent("d_tab_next");
        public static readonly GUIStyle IconButton = new GUIStyle("IconButton");
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        var type = property.FindPropertyRelative("type");
        return EditorGUI.GetPropertyHeight(type);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);

        var type = property.FindPropertyRelative("type");
        var controller = property.FindPropertyRelative("controller");

        float width = (position.width - 20) / 2;

        position.width = width;
        EditorGUI.PropertyField(position, type, GUIContent.none);
        position.x += width + 2;
        position.width = 10;
        EditorGUI.LabelField(position, Styles.RemoveIcon, Styles.IconButton);
        position.x += 18;
        position.width = width;
        EditorGUI.PropertyField(position, controller, GUIContent.none);

        EditorGUI.EndProperty();
    }
}