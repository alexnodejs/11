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

    public virtual GameObject Interact()
    {
        //Debug.Log(Name + ": " + Distance);
        return null;
    }

    protected virtual void OnFixedUpdate()
    {

    }
}
