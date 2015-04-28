using UnityEngine;
using System;
using System.Collections;

public class SkillController : MonoBehaviour
{
    protected SkillHero skill;
    protected float timeSinceLastExecuted = 0.0f;

    public event EventHandler<SkillEventArgs> SkillActivated;

    public virtual void initialize(SkillHero skill)
    {
        this.skill = skill;
        timeSinceLastExecuted = skill.interval + Time.deltaTime;
    }

    public virtual void Update()
    {
        if (skill == null) return;

        if (Input.GetKey(skill.keyCode))
        {
            if (timeSinceLastExecuted > skill.interval)
            {
                timeSinceLastExecuted = 0.0f;
                OnSkillActivated();
            }
        }
        
        timeSinceLastExecuted += Time.deltaTime;
    }

    protected virtual void OnSkillActivated()
    {
        if (SkillActivated != null)
        {
            SkillActivated(this, new SkillEventArgs () {SkillHero = skill});
        }
    }
}
