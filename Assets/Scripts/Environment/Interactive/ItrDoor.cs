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

    public float DoorDetectorRadius = 3f;
    public LockPosition LockPos;
    public Animator Anim;

    private float _autoCloseTime = 3f;
    private float _timeToClose;
    private bool _isDoorDetectorProcessing = false;

    public void DoorOpenClose()
    {
        if (GetIsDoorNotBlock())
            Anim.SetBool("Open", !Anim.GetBool("Open"));
    }

    public bool GetIsDoorOpen()
    {
        return Anim.GetBool("Open");
    }

    public bool GetIsDoorNotBlock()
    {
        return LockPos != LockPosition.Lock;
    }

    public void DoorOpen()
    {
        if (GetIsDoorNotBlock() && GetIsDoorOpen() != true)
        {
            Anim.SetBool("Open", true);
            _timeToClose = Time.time + _autoCloseTime;   
        }
    }

    public void DoorClose()
    {
        if (GetIsDoorNotBlock())
            Anim.SetBool("Open", false);
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (GetIsDoorOpen() && LockPos == LockPosition.Auto)
        {
            if (Time.time > _timeToClose)
            {
                DoorClose();
            }
        }

        if (GetIsDoorNotBlock() && !_isDoorDetectorProcessing)
            CheckIsCharacterAround();
    }

    private void CheckIsCharacterAround()
    {
        _isDoorDetectorProcessing = true;
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, DoorDetectorRadius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].GetComponent<Character>())
            {
                _timeToClose = Time.time + _autoCloseTime;
                DoorOpen();
            }
            i++;
        }
        _isDoorDetectorProcessing = false;
    }
}
