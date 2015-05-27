using UnityEngine;
using System.Collections;
using Global;

public interface IDamageable
{
    void TakeDamage(DamageType damageType, float damage);
}
