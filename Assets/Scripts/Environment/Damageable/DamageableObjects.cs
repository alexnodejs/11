using UnityEngine;
using System.Collections;
using Global;

public class DamageableObjects : MonoBehaviour, IDamageable
{
    /// <summary>
    /// Public params:
    /// </summary>
    public float LifeLevel = 100f;
    public ObjMaterials CurObjMaterial = ObjMaterials.Other;

    /// <summary>
    /// Private params:
    /// </summary>
    protected float SatrtLifeLevel;

    private bool _isDemolition = false;

    void Awake()
    {
        SatrtLifeLevel = LifeLevel;
    }

    void FixedUpdate()
    {
        OnFixedUpdate();
    }

    protected virtual void OnFixedUpdate()
    {
        
    }

    protected virtual void Demolition()
    {
        DestroyThis();
    }

    public virtual void TakeDamage(DamageType damageType, float damage)
    {
        LifeLevel -= DamageHelper.CalculateDamage(damageType, damage, CurObjMaterial);

        if (!(LifeLevel <= 0f) || _isDemolition) return;
        _isDemolition = true;
        Demolition();
    }
    
    protected void DestroyThis()
    {
        Destroy(gameObject);
    }
}
