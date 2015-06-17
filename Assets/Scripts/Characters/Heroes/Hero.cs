using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Global;public class Hero : Character{    public Weapon CurWeapon;    [HideInInspector] public bool MovementLocked = false;    public override void TakeDamage(DamageType damageType, float damage)    {        base.TakeDamage(damageType, damage);    }    public override void SetDistinationPosition(Ray ray)    {        if (MovementLocked) return;        base.SetDistinationPosition(ray);    }    protected override void CharacterFixedUpdate()    {        base.CharacterFixedUpdate();        if (MovementLocked)        {                    }    }    public void AttackCharacter()    {        if (CurWeapon)            CurWeapon.Shoot();    }

    private void GrabObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        obj.transform.SetParent(GrabPointGameObject.transform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void SelectHero()
    {
        if (SelectCircle != null)
        {
            SelectCircle.enabled = true;  // show select circle
        }
    }

    public void UnselectHero()
    {
        if (SelectCircle != null)
        {
            SelectCircle.enabled = false;  // hide select circle
        }
    }

    private void DropObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GrabPointGameObject.transform.DetachChildren();
        ObjInHands = null;
    }

    public virtual void TryToInteract()
    {
        if (ObjInHands)
        {
            DropObject(ObjInHands);
        }

        else
        {
            CheckInteractableObjectsAround();
        }
    }

    private void CheckInteractableObjectsAround()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, InteractiveRadius);
        List<InteractiveObject> itrObjects = new List<InteractiveObject>();
        int i = 0;
        while (i < hitColliders.Length)
        {
            InteractiveObject itrObj = hitColliders[i].GetComponent<InteractiveObject>();
            if (itrObj)
            {
                itrObj.Distance = Vector3.Distance(itrObj.transform.position, transform.position);
                itrObjects.Add(itrObj);
            }

            i++;
        }

        var sortedItrObjects = itrObjects.OrderBy(go => go.Distance).ToList();
        sortedItrObjects[0].Interact();

        if (sortedItrObjects[0] is ItrBarrel)
        {
            GameObject barrel = sortedItrObjects[0].Grab();

            if (barrel)
            {
                ObjInHands = barrel;
                GrabObject(ObjInHands);
            }
        }
    }}