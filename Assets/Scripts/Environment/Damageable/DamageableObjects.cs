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
    public GameObject SplintersPrefabGameObject;

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
        Instantiate(SplintersPrefabGameObject, transform.position, new Quaternion(0f, 0f, 0f, 0f));

        Invoke("DestroyThis", 0.1f);
    }

    public virtual void TakeDamage(DamageType damageType, float damage)
    {
        LifeLevel -= DamageHelper.CalculateDamage(damageType, damage, CurObjMaterial);

        if (LifeLevel <= 0f && !_isDemolition)
        {
            _isDemolition = true;
            Demolition();
        }
    }

    protected virtual void DestroyThis()
    {
        Destroy(gameObject);
    }
}
