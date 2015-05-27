using UnityEngine;
using System.Collections;
using Global;

public class ItrDoor : InteractiveObject
{
    public bool IsBlock = true;
    public Animator Anim;

    public void DoorOpenClose()
    {
        if (!IsBlock)
            Anim.SetBool("Open", !Anim.GetBool("Open"));
    }
}
