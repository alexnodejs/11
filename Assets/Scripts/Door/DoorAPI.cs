using UnityEngine;
using System.Collections;

public class DoorAPI : MonoBehaviour 
{
    /// <summary>
    /// Public params:
    /// </summary>
    public GameObject doorDamage;
    public GameObject doorNormal;

    /// <summary>
    /// Private params:
    /// </summary>
    private Animator anim;

	void Awake()
    {
        anim = GetComponent<Animator>();
        doorDamage.SetActive(false);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Boom!"))
        {
            DoorBoom();
        }

        if (GUI.Button(new Rect(100, 70, 80, 30), "Open/Close"))
        {
            DoorOpenClose();
        }
    }

    public void DoorBoom()
    {
        doorDamage.SetActive(true);
        doorNormal.SetActive(false);
        anim.SetBool("Boom", true);
    }

    public void DoorOpenClose()
    {
        
        anim.SetBool("Open", !anim.GetBool("Open"));
    }
}
