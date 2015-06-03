// Shatter Toolkit
// Copyright 2015 Gustav Olsson
using System.Collections.Generic;
using UnityEngine;

namespace ShatterToolkit
{
    public abstract class UvMapper : MonoBehaviour
    {
        public abstract void Map(IList<Vector3> points, Vector3 planeNormal, out Vector4[] tangentsA, out Vector4[] tangentsB, out Vector2[] uvsA, out Vector2[] uvsB);
    }
}