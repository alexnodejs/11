using UnityEngine;
using System.Collections;
using Global;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    public GameObject canvasUI;
    public Animator Anim;

    /// <summary>
    /// Private params:
    /// </summary>
    private bool _isHeroAround = false;

    public void Interact()
    {
        
    }

    void OnMouseEnter()
    {
        if (_isHeroAround)
            canvasUI.SetActive(true);
    }

    void OnMouseExit()
    {
        if (_isHeroAround)
            canvasUI.SetActive(false);
    }

    void OnTriggerStay(Collider target)
    {
        if (target.tag == Tags.heroes)
        {
            _isHeroAround = true;
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == Tags.heroes)
        {
            _isHeroAround = false;
        }
    }
}
