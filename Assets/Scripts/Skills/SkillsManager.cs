using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillsManager : MonoBehaviour
{

    public List<GameObject> SkillsList = new List<GameObject>();
    /// <summary>
    /// Event handler.
    /// Skills Controller instance.
    /// </summary>
    private SkillsController skillsController;

    /// <summary>
    /// Action Bar script refference.
    /// </summary>
    private ActionBar actionBar;

    public void Start()
    {
        skillsController = new SkillsController();
        actionBar = GameObject.FindGameObjectWithTag(Global.Tags.actionBar).GetComponent<ActionBar>();
        skillsController.SkillAdded += actionBar.OnSkillAdded;

        LoadSkills();
    }

    /// <summary>
    /// Load stub skills.
    /// </summary>
    private void LoadSkills()
    {
        foreach(GameObject prefabSkill in SkillsList)
        {
            GameObject skill = Instantiate(prefabSkill) as GameObject;
            skill.transform.SetParent(this.gameObject.transform, false);

            skillsController.AddSkill(skill);
        }
    }
}
