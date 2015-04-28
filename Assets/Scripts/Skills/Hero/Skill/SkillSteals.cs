using UnityEngine;
using System.Collections;

public class SkillSteals: SkillController
{
    public Mesh Mesh;
    private VisualizationComponent visualization;
    private GameObject heroBody;
    private Material inactiveSkillBodyShader;
    private Material activeSkillBodyShader;

    void Start()
    {
        visualization = new VisualizationComponent();
        heroBody = GameObject.FindGameObjectWithTag(Global.Tags.heroes).transform.FindChild("Body_01").gameObject;
        inactiveSkillBodyShader = heroBody.GetComponent<Renderer>().material;

        activeSkillBodyShader = new Material(Shader.Find("Projector/Light"));
    }

    override public void Update()
    {
        base.Update();

        if (skill.isActive)
        {
            heroBody.GetComponent<Renderer>().material = activeSkillBodyShader;
        }
        else
        {
            heroBody.GetComponent<Renderer>().material = inactiveSkillBodyShader;
        }
    }
}
