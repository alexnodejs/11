using UnityEngine;
using System.Collections;
using Global;

public class WallAPI : MonoBehaviour 
{
    public GameObject exlosionPrefab;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("AddForce", 3f);
    }

    public void WallDamage()
    {
        Invoke("DestroyThisWall", 0.1f);
        Instantiate(exlosionPrefab, transform.position, new Quaternion(0f, 0f, 0f, 90f));  
    }

    private void DestroyThisWall()
    {
        Destroy(gameObject);
    }

    private void AddForce()
    {
        Instantiate(exlosionPrefab, transform.position, new Quaternion(0f, 0f, 0f, 90f));  
        rb.AddForce(Vector3.forward * 50f, ForceMode.Impulse);
    }
}
