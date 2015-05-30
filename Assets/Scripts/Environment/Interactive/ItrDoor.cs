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

    private bool _someBodyAround = false;

    public void DoorOpenClose()
    {
        if (lockPos != LockPosition.Lock && IsHeroAround)
            Anim.SetBool("Open", !Anim.GetBool("Open"));
    }

    public bool GetIsDoorOpen()
    {
        return Anim.GetBool("Open");
    }

    public void DoorOpen()
    {
        if (lockPos != LockPosition.Lock)
            Anim.SetBool("Open", true);
    }

    public void DoorClose()
    {
        if (lockPos != LockPosition.Lock)
            Anim.SetBool("Open", false);
    }

    protected override void OnUseButtonUp()
    {
        base.OnUseButtonUp();

        DoorOpenClose();
    }
}
