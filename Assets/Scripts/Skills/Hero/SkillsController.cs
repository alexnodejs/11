using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SkillsController
{
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
    public void AddSkill(SkillHero skill)
    {
        skillsStorage.Add(skill);
        OnSkillAdded(skill);
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
