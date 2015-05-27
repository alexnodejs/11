using UnityEngine;
using System;

public class CollisionEventArgs: EventArgs
{
    public Collision Collision { get; set; }
}