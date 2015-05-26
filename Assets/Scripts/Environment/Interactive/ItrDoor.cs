using UnityEngine;
using System.Collections;

public class ItrDoor : InteractiveObject 
{
    public void DoorOpenClose()
    {
        Anim.SetBool("Open", !Anim.GetBool("Open"));
    }
}
