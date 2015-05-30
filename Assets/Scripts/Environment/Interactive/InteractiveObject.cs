using UnityEngine;
using System.Collections;
using Global;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    public string Name;

    /// <summary>
    /// Private params:
    /// </summary>
    protected bool IsHeroAround = false;

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
            IsHeroAround = true;
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
        IsHeroAround = false;
    }

    protected virtual void OnFixedUpdate()
    {
        if (InputManager.UseUp())
        {
            OnUseButtonUp();
        }
    }

    protected virtual void OnUseButtonUp()
    {
        
    }
}
