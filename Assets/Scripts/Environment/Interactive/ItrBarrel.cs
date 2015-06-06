using UnityEngine;
using System.Collections;
using Global;

public class ItrBarrel : InteractiveObject
{
    public override GameObject Grab()
    {
        return gameObject.transform.parent.gameObject;
    }
}
