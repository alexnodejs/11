using UnityEngine;
using System.Collections;
using RAIN.Entities;

public class SkillSteals: SkillController
{
    private GameObject hero;
    private GameObject heroBody;
    private EntityRig aiEntity;
    private Material inactiveSkillBodyShader;
    private Material activeSkillBodyShader;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag(Global.Tags.heroes);

        heroBody = hero.transform.FindChild("Body_01").gameObject;
        aiEntity = hero.GetComponentInChildren<EntityRig>();

        inactiveSkillBodyShader = heroBody.GetComponent<Renderer>().material;

        activeSkillBodyShader = new Material(Shader.Find("Projector/Light"));
    }

    override public void Update()
    {
        base.Update();

        if (skill.isActive)
        {
            aiEntity.Entity.IsActive = false;
            heroBody.GetComponent<Renderer>().material = activeSkillBodyShader;
        }
        else
        {
            aiEntity.Entity.IsActive = true;
            heroBody.GetComponent<Renderer>().material = inactiveSkillBodyShader;
        }
    }
}
