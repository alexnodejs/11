// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using UnityEngine;

namespace ShatterToolkit
{
    public interface IHull
    {
        bool IsEmpty
        {
            get;
        }
        
        Mesh GetMesh();
        
        void Split(Vector3 localPointOnPlane, Vector3 localPlaneNormal, bool fillCut, UvMapper uvMapper, ColorMapper colorMapper, out IHull resultA, out IHull resultB);
    }
}