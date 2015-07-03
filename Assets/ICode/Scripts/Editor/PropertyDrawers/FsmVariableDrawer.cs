using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using ICode;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(FsmVariable))]
	public class FsmVariableDrawer : PropertyDrawer {
		public override void OnGUI (SerializedProperty property, GUIContent label)
		{
			if (property.objectReferenceValue == null) {
				CreateVariable(property);
			}
			if (property.objectReferenceValue == null) {
				return;			
			} 
			SerializedObject serializedObject = new SerializedObject (property.objectReferenceValue);
			serializedObject.Update ();
			GUILayout.BeginHorizontal ();
			
			SerializedProperty nameProperty = serializedObject.FindProperty ("name");
			SerializedProperty valueProperty = serializedObject.FindProperty ("value");
			SerializedProperty sharedProperty = serializedObject.FindProperty ("isShared");
			
			if (EditorUtility.IsPersistent (property.objectReferenceValue) && fieldInfo.HasAttribute (typeof(SharedPersistentAttribute)) || fieldInfo.FieldType == typeof(FsmArray)) {
				sharedProperty.boolValue = true;
			}

			Color color = GUI.backgroundColor;
			if (ErrorChecker.HasErrors(property.objectReferenceValue)){
				GUI.backgroundColor = Color.red;
			}
			
			if (sharedProperty.boolValue) {
				DrawSharedVariable (label, nameProperty);
			}else {
				OnPropertyField(valueProperty,label);
			}
			GUI.backgroundColor = color;
		
			if (DoSharedToggle(property)) {
				DrawSharedToggle (sharedProperty);
			}
			GUILayout.EndHorizontal ();
			serializedObject.ApplyModifiedProperties ();
		}

		public virtual void OnPropertyField(SerializedProperty property,GUIContent label){
			if(property != null)
			EditorGUILayout.PropertyField (property, label);	
		}

		public bool DoSharedToggle(SerializedProperty property){
			if(fieldInfo.HasAttribute (typeof(SharedAttribute)) || EditorUtility.IsPersistent(property.objectReferenceValue) && fieldInfo.HasAttribute(typeof(SharedPersistentAttribute)) || property.objectReferenceValue is FsmArray){ //|| !property.objectReferenceValue.GetType().GetProperty("Value").PropertyType.IsSerializable){
				return false;
			}		
			return true;	
		}
		
		public void DrawSharedVariable(GUIContent content, SerializedProperty property){
			EditorGUI.BeginChangeCheck ();
			string[] names=null;
			int variablesOfType = GetVariablesOfType(property.serializedObject.targetObject as FsmVariable, out names);
			variablesOfType = EditorGUILayout.Popup(content,variablesOfType, names.ToGUIContent());
			if (EditorGUI.EndChangeCheck ()) {
				property.stringValue = names[variablesOfType];
			}
		//	Debug.Log (content.text+": "+property.stringValue);
		}
		
		public void DrawSharedToggle(SerializedProperty property){
			EditorGUI.BeginChangeCheck ();
			bool value=EditorGUILayout.Toggle (property.boolValue, EditorStyles.radioButton,GUILayout.Width(15f));
			if (EditorGUI.EndChangeCheck ()) {
				property.boolValue = value;
			}
		}

		public int GetVariablesOfType(FsmVariable variable,out string[] names){
			if (FsmEditor.Root == null) {
				names= new string[0];
				return 0;
			}
			FsmVariable[] variables = FsmEditor.Root.Variables;
			variables = ArrayUtility.AddRange<FsmVariable> (variables, GlobalVariables.GetVariables ());
			int count = 0;
			List<string> strs = new List<string> (){
				"None"
			};
			
			for (int i = 0; i < variables.Length; i++)
			{
				Type propertyType = variables[i].GetType().GetProperty("Value").PropertyType;
				if (variable == null || propertyType.Equals(variable.GetType().GetProperty("Value").PropertyType))
				{
					strs.Add(variables[i].Name);
					if (variable != null  && variables[i].Name.Equals(variable.Name))
					{
						count = strs.Count - 1;
					}
				}
			}
			names = strs.ToArray();
			return count;
		}

		public virtual void CreateVariable(SerializedProperty property){
			FsmVariable variable = ScriptableObject.CreateInstance (fieldInfo.FieldType) as FsmVariable;
			variable.hideFlags = HideFlags.HideInHierarchy;
			DefaultValueAttribute defaultAttribute=fieldInfo.GetAttribute<DefaultValueAttribute>();
			if(defaultAttribute != null){
				variable.SetValue(defaultAttribute.DefaultValue);
			}

			if (EditorUtility.IsPersistent (property.serializedObject.targetObject)) {
				AssetDatabase.AddObjectToAsset (variable, property.serializedObject.targetObject);
				AssetDatabase.SaveAssets ();
			}
			variable.IsShared = fieldInfo.HasAttribute (typeof(SharedAttribute)) || EditorUtility.IsPersistent (variable) && fieldInfo.HasAttribute (typeof(SharedPersistentAttribute)) || fieldInfo.FieldType == typeof(FsmArray);
			property.objectReferenceValue = variable;
			property.serializedObject.ApplyModifiedProperties ();
			ErrorChecker.CheckForErrors();
		}
	}
}