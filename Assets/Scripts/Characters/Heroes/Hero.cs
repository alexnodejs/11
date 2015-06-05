using UnityEngine;
using System.Collections;
using Global;

public class Hero : Character
{
    [HideInInspector]
    public bool MovementLocked = false;

    public override void TakeDamage(DamageType damageType, float damage)
    {
        base.TakeDamage(damageType, damage);
    }

    public override void SetDistinationPosition(Ray ray)
    {
        if (MovementLocked) return;

        base.SetDistinationPosition(ray);
    }

    protected override void CharacterFixedUpdate()
    {
        base.CharacterFixedUpdate();

        if (MovementLocked)
        {
            StopNavAgent();
        }
    }
}
