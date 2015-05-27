// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using UnityEngine;

using ShatterToolkit.Helpers;

namespace ShatterToolkit.Examples
{
    public class SceneGUI : MonoBehaviour
    {
        protected int toolbarSelection = 0;
        protected System.String[] toolbarLabels = { "Basic scene", "UvMapping scene", "Wall scene" };
        
        public void Awake()
        {
            toolbarSelection = Application.loadedLevel;
        }
        
        public void OnGUI()
        {
            toolbarSelection = GUI.Toolbar(new Rect(10, Screen.height - 30, Screen.width - 20, 20), toolbarSelection, toolbarLabels);
            
            if (GUI.changed)
            {
                Application.LoadLevel(toolbarSelection);
            }
        }
    }
}