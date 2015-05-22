using UnityEngine;
using System.Collections;
using Global;

public class WallAPI : MonoBehaviour 
{
    public GameObject exlosionPrefab;

    void Awake()
    {
        Invoke("WallDamage", 2.7f);
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
}
