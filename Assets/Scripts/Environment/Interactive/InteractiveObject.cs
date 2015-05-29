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

    protected GameObject CurHeroGameObject;

    void FixedUpdate()
    {
        OnFixedUpdate();
    }

    public void Interact()
    {
        
    }

    void OnTriggerStay(Collider target)
    {
        if (target.tag == Tags.heroes)
        {
            CurHeroGameObject = target.gameObject;
            _isHeroAround = true;
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == Tags.heroes)
        {
            OnHeroExit();
        }
    }

    protected virtual void OnHeroExit()
    {
        CurHeroGameObject = null;
        _isHeroAround = false;
    }

    protected virtual void OnFixedUpdate()
    {
        canvasUI.SetActive(_isHeroAround);
    }
}
