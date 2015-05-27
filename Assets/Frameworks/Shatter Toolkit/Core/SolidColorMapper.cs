// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using System.Collections.Generic;
using UnityEngine;

namespace ShatterToolkit
{
    public class SolidColorMapper : ColorMapper
    {
        /// <summary>
        /// Determines the vertex color to be used for the cut area
        /// </summary>
        public Color32 fillColor = Color.cyan;
        
        public override void Map(IList<Vector3> points, Vector3 planeNormal, out Color32[] colorsA, out Color32[] colorsB)
        {
            Color32[] colors = new Color32[points.Count];
            
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = fillColor;
            }
            
            colorsA = colors;
            colorsB = colors;
        }
    }
}