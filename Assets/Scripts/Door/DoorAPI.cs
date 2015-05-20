using UnityEngine;
using System.Collections;

public class DoorAPI : MonoBehaviour 
{
    /// <summary>
    /// Public params:
    /// </summary>
    public GameObject exlosionPrefab;
    public GameObject doorDamage;
    public GameObject doorNormal;

    public bool isHeroAround;

    /// <summary>
    /// Private params:
    /// </summary>
    private Animator anim;

	void Awake()
    {
        anim = GetComponent<Animator>();
        doorDamage.SetActive(false);
    }

    public void DoorBoom()
    {
        Invoke("HideDoorParts", 0.7f);
        doorDamage.SetActive(true);
        doorNormal.SetActive(false);
        anim.SetBool("Boom", true);
        Instantiate(exlosionPrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f));        
    }

    public void DoorOpenClose()
    {        
        anim.SetBool("Open", !anim.GetBool("Open"));
    }

    public void DoorOpen()
    {
        if (!anim.GetBool("Open"))
            anim.SetBool("Open", true);
    }

    private void HideDoorParts()
    {
        doorDamage.SetActive(false);
    }

    void OnTriggerStay(Collider target)
    {
        if (target.tag == Global.Tags.heroes)
        {
            isHeroAround = true;
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == Global.Tags.heroes)
        {
            isHeroAround = false;
        }
    }
}
