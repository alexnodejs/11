using UnityEngine;
using System.Collections;
using Global;

public class Neutral : Character
{
    public enum TargetEngaging { All, Heroes, Enemys }
    public TargetEngaging CurTargetEngaging = TargetEngaging.Enemys;

    protected NeutralsController NC;

    protected override void Init()
    {
        base.Init();

        NC = GM.GetNeutralsCtr();
    }

    protected override void SomeColliderAround(Collider col)
    {
        base.SomeColliderAround(col);

        if (col.transform.GetComponent<Character>() != null)
        {
            AttackCharacter(col);
        }
    }

    protected virtual void EngagingOnCharacter(Collider col)
    {
        
    }

    protected virtual void AttackCharacter(Collider col)
    {
        Vector3 direction = col.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < ViewAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, ViewRadius))
            {
                if (hit.transform.GetComponent<Character>() != null)
                {
                    if (col.transform.tag == Tags.hero && (CurTargetEngaging == TargetEngaging.All || CurTargetEngaging == TargetEngaging.Heroes))
                    {
                        Attack(col);
                    }
                    else if (col.transform.tag == Tags.enemy && (CurTargetEngaging == TargetEngaging.All || CurTargetEngaging == TargetEngaging.Enemys))
                    {
                        Attack(col);
                    }
                }
            }
        }
    }

    protected virtual void Attack(Collider col)
    {
        RotateCharacter(col.transform.position);
    }
}
