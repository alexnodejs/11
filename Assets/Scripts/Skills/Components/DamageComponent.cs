using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DamageComponent: SkillComponent
{
    public int damage;
    public event EventHandler DamageDealt;

    public virtual void InflictDamage(List<GameObject> targets)
    {
        foreach(GameObject target in targets)
        {
            if (DamageDealt != null)
            {
                DamageDealt(target, EventArgs.Empty);
            }
        }
    }
}
