using UnityEngine;
using System.Collections;
using Global;

public class ItrDoor : InteractiveObject
{
    public enum LockPosition
    {
        Auto = 0,
        UnLock,
        Lock
    }

    public LockPosition lockPos;
    public Animator Anim;

    public void DoorOpenClose()
    {
        if (lockPos != LockPosition.Lock)
            Anim.SetBool("Open", !Anim.GetBool("Open"));
    }
}
