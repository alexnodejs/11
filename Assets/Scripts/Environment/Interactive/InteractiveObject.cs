using UnityEngine;
using System.Collections;
using Global;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    public string Name;

    protected GameObject CurHeroGameObject;

    void FixedUpdate()
    {
        OnFixedUpdate();
    }

    public virtual void Interact()
    {
        
    }

    protected virtual void OnFixedUpdate()
    {

    }
}
