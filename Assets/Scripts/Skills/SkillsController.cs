using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SkillsController
{
    private Character characterController;

    public SkillsController()
    {
        characterController = GameObject.FindGameObjectWithTag(Global.Tags.heroes).GetComponent<Character>();
    }

    /// <summary>
    /// Event handler.
    /// SkillAdded delegate.
    /// </summary>
    public event EventHandler<SkillEventArgs> SkillAdded;

    /// <summary>
    /// Skills storage.
    /// </summary>
    private List<SkillHero> skillsStorage = new List<SkillHero>();

    /// <summary>
    /// Add a new skill.
    /// </summary>
    public void AddSkill(GameObject skillObject)
    {
        SkillHero skill = skillObject.GetComponent<SkillHero>();
        skillsStorage.Add(skill);
        OnSkillAdded(skill);

        SkillController controller = skill.GetComponent<SkillController>();
        if (controller != null)
        {
            controller.initialize(skill);
            if (characterController != null)
            {
//                controller.SkillActivated += characterController.OnSkillActivated;
            }
        }
    }

    /// <summary>
    /// Publish SkillAdded event.
    /// </summary>
    protected virtual void OnSkillAdded(SkillHero skill)
    {
        if (SkillAdded != null)
        {
            SkillAdded(this, new SkillEventArgs () {SkillHero = skill});
        }
    } 
}
