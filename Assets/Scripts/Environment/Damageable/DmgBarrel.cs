using System;
using UnityEngine;
using System.Collections;
using Global;

public class DmgBarrel : DamageableObjects 
{
    // Explosion params:
    public float ExplosionRadius = 3f;
    public float ExplosionPower = 2000f;
    public GameObject ExlosionPrefab;
    public GameObject FirePrefab;

    private GameObject _fireParticlesGameObject;

    protected override void Demolition()
    {
        Explosion();
    }

    private void Explosion()
    {
        Instantiate(ExlosionPrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f));

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, ExplosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb == null) continue;
            rb.AddExplosionForce(ExplosionPower, explosionPos, ExplosionRadius, 5.0f);

            float distance = Vector3.Distance(hit.transform.position, transform.position);

            if (distance < ExplosionRadius)
            {
                float curDamage = DamageValues.Explosion - ((DamageValues.Explosion / ExplosionRadius) * distance);

                // Try to make Damage:
                DamageHelper.MakeDamage(hit.gameObject, DamageType.Explosion, curDamage);
            }
        }

        Invoke("DestroyThis", 0.1f);
    }
}
