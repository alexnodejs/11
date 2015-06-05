using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Global;

public class Character : MonoBehaviour, IDamageable
{
    private string Name = "Character";
    public GameObject GrabPointGameObject;

    [HideInInspector]
    public float LifeLevel = 100;
    [HideInInspector]
    public float InteractiveRadius = 3f;

    protected bool IsDead;
    protected NavMeshAgent NavAgent;
    protected Animator CharacterAnimator;
    protected GameManager GM;
    protected EnemyController EC;
    protected GameObject ObjInHands;
    protected SpriteRenderer SelectCircle;
    protected float CharacterRotationSpeed = 500f;
    protected float CharacterCurSpeed;

    void Awake()
    {
        SelectCircle = GetComponentInChildren<SpriteRenderer>();
        NavAgent = GetComponent<NavMeshAgent>();
        CharacterAnimator = GetComponent<Animator>();
        GM = GameObject.FindGameObjectWithTag(Tags.gameManager).GetComponent<GameManager>();
        EC = GM.getEnemyCtr();
    }

    void FixedUpdate()
    {
        CharacterCurSpeed = NavAgent.velocity.magnitude;
        CharacterAnimator.SetFloat("Speed", CharacterCurSpeed);

        CharacterUpdate();
    }

    protected virtual void CharacterUpdate()
    {
        
    }

    public virtual void TakeDamage(DamageType damageType, float damage)
    {
        
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
    }

    private void GrabObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        obj.transform.SetParent(GrabPointGameObject.transform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void DropObject(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GrabPointGameObject.transform.DetachChildren();
        ObjInHands = null;
    }

    /// <summary>
    /// Movement:
    /// </summary>
    
    public virtual void SetDistinationPosition(Ray ray)
    {
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
        {
            NavAgent.ResetPath();
            NavAgent.SetDestination(hitInfo.point);
        }
    }

    public void OrientateHero(Ray ray)
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            NavAgent.Stop();
            NavAgent.ResetPath();
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, CharacterRotationSpeed * Time.smoothDeltaTime);
        }
    }
}
