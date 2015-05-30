using UnityEngine;
using System.Collections;
using Global;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    public string Name;
    public float InterfaceWorkDistance = 2.5f;
    public float Distance;

    protected GameObject CurHeroGameObject;

    void FixedUpdate()
    {
        OnFixedUpdate();
    }

    public virtual void Interact()
    {
        //Debug.Log(Name + ": " + Distance);
    }

    protected virtual void OnFixedUpdate()
    {

    }
}
