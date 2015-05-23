using UnityEngine;
using System.Collections;
using Global;

public class DamageHelper
{
    public static float CalculateDamage(DamageType damageType, float damage, ObjMaterials objMaterial)
    {
        var curDamage = 0f;

        curDamage = damage;

        return curDamage;
    }

    public static void MakeDamage(GameObject obj, DamageType damageType, float damage)
    {
        IDamageable[] list = obj.gameObject.GetComponents<IDamageable>();
        foreach (IDamageable dmg in list)
        {
            if (dmg is IDamageable)
            {
                IDamageable damageable = (IDamageable)dmg;
                damageable.TakeDamage(damageType, damage);
            }
        }
    }
}
