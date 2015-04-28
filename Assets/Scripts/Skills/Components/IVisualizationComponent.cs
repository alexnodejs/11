using UnityEngine;
using System;

public enum VisualizationType : int
{
    ParticleSystem,
    Mesh,
    GetObjectsByScript
}

public enum ExecutionTime : int
{
    Start,
    Collision
}

public interface IVisualizationComponent
{
    void ActivateVisualization(GameObject caster, ExecutionTime executeAt);
}
