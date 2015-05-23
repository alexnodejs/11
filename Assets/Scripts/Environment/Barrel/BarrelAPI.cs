using UnityEngine;
using System.Collections;
using Global;

public class BarrelAPI : MonoBehaviour, IDamageable
{
    public float radius = 3f;
    public float power = 1f;
    public GameObject exlosionPrefab;
    public GameObject firePrefab;

    public float lifeLevel = 100f;

    private GameObject fireParticles;

    void FixedUpdate()
    {
        if (lifeLevel < 100f && !fireParticles)
        {
            AddFire();
        }

        if (lifeLevel <= 0f)
        {
            ExplosionBarrel();
        }
        
    }

    private void ExplosionBarrel()
    {
        Instantiate(exlosionPrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f));

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);

        }

        Invoke("DestroyThisBarrel", 0.1f);
    }

    private void AddFire()
    {
        fireParticles = (GameObject)Instantiate(firePrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f));
    }

    private void DestroyThisBarrel()
    {
        Destroy(fireParticles);
        Destroy(gameObject);
    }


    public void TakeDamage(float force)
    {
        lifeLevel -= force;
    }
}
