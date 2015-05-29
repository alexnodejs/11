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
        if (lockPos != LockPosition.Lock)
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

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        //CheckIsAnybodyAround();
    }

    private void CheckIsAnybodyAround()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);



        foreach (var hitCol in hitColliders)
        {
            if (hitCol.GetComponent<Hero>())
            {
                DoorOpen();
            }

            else
            {
                DoorClose();
            }
        }
    }
}
