using UnityEngine;
using System.Collections;

public class DoorAPI : MonoBehaviour 
{
    /// <summary>
    /// Public params:
    /// </summary>
    public GameObject exlosionPrefab;
    public GameObject doorNormal;

    public bool isHeroAround;

    /// <summary>
    /// Private params:
    /// </summary>
    private Animator anim;

	void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void DoorBoom()
    {
        Invoke("HideDoorParts", 0.7f);
        doorNormal.SetActive(false);
        anim.SetBool("Boom", true);
        Instantiate(exlosionPrefab, transform.position, new Quaternion(0f, 90f, 0f, 90f));        
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
