using UnityEngine;
using System.Collections;

using Global;

public class GuardEnemy : Enemy
{
	GuardEnemy()
	{
		enemyBehavior = new EnemyBehavior(new GuardBehavior());
	}

	public override void RuntimeAnimation()
	{
		anim.SetFloat("Speed", speed * 0.3f);
	}

    protected override void MeleeAttack()
    {
        base.MeleeAttack();
        anim.SetBool("MeleeAttack", true);
    }
}
