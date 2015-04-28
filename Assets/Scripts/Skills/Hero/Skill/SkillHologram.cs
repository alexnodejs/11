using UnityEngine;
using System.Collections;

public class SkillHologram : SkillController
{
    public GameObject source;

    protected GameObject hero;
    protected GameObject hologram;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag(Global.Tags.heroes).gameObject;
    }

    override public void Update()
    {
        base.Update();

        if (skill.isActive)
        {
            AddHologram();
        }
        else
        {
            RemoveHologram();
        }
    }

    protected void AddHologram()
    {
        if (hologram != null) return;

        hologram = new GameObject("Hero Hologram");
        hologram.transform.position = hero.transform.position;
        hologram.transform.rotation = hero.transform.rotation;

        GameObject sourceObject = Instantiate(source, Vector3.zero, Quaternion.identity) as GameObject;
        sourceObject.transform.SetParent(hologram.transform, false);
    }

    protected void RemoveHologram()
    {
        Destroy(hologram);
    }
}
