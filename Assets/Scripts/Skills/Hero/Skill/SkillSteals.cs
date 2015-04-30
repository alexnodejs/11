using UnityEngine;
using System.Collections;
using RAIN.Entities;

public class SkillSteals: SkillController
{
    private GameObject hero;
    private Renderer heroRenderer;
    private EntityRig aiEntity;
    private Material inactiveSkillMaterial;
    private Material activeSkillMaterial;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag(Global.Tags.heroes);

        heroRenderer = hero.transform.FindChild("Body_01").GetComponent<Renderer>();
        aiEntity = hero.GetComponentInChildren<EntityRig>();
        inactiveSkillMaterial = heroRenderer.material;

        activeSkillMaterial = new Material(Shader.Find("Projector/Light"));
    }

    override public void Update()
    {
        base.Update();

        if (skill.isActive)
        {
            aiEntity.Entity.IsActive = false;
            heroRenderer.material = activeSkillMaterial;
        }
        else
        {
            aiEntity.Entity.IsActive = true;
            heroRenderer.material = inactiveSkillMaterial;
        }
    }
}
