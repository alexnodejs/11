using UnityEngine;
using System.Collections;

public class VisualizationComponent: SkillComponent, IVisualizationComponent
{
    public ParticleSystem particleVisualisation;
    public GameObject VisualizationObject;

    public VisualizationType visualizationType;

    public void ActivateVisualization(GameObject caster, ExecutionTime time)
    {
    }
}
