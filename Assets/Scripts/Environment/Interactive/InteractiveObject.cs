using UnityEngine;
using System.Collections;
using Global;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    public GameObject canvasUI;
    public string Name;

    /// <summary>
    /// Private params:
    /// </summary>
    private bool _isHeroAround = false;

    void FixedUpdate()
    {
        canvasUI.SetActive(_isHeroAround);
    }

    public void Interact()
    {
        
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
            OnHeroExit();
        }
    }

    protected virtual void OnHeroExit()
    {
        
    }
}
