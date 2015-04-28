using UnityEngine;
using System.Collections;

public class SkillSteals: SkillController
{
    public Mesh Mesh;
    private VisualizationComponent visualization;

    void Start()
    {
        visualization = new VisualizationComponent();
    }
}
