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

        Init();
    }

    void FixedUpdate()
    {
        CharacterCurSpeed = NavAgent.velocity.magnitude;
        CharacterAnimator.SetFloat("Speed", CharacterCurSpeed);

        CharacterFixedUpdate();
    }

    protected virtual void Init()
    {
        
    }

    protected virtual void CharacterFixedUpdate()
    {
        CheckPerimeterAround();
    }

    public virtual void TakeDamage(DamageType damageType, float damage)
    {
        
    }

    protected void RotateCharacter(Vector3 targetPoint)
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, CharacterRotationSpeed * Time.smoothDeltaTime);

        
    }

    protected void SetCharacterDestination(Vector3 point)
    {
        NavAgent.ResetPath();
        NavAgent.SetDestination(point);
    }

    protected void StopNavAgent()
    {
        NavAgent.Stop();
        NavAgent.ResetPath();
    }

    private void CheckPerimeterAround()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, InteractiveRadius);

        int i = 0;
        while (i < hitColliders.Length)
        {


            i++;
        }
    }

    protected virtual void SomeColliderAround(Collider col)
    {
        
    }

    /// <summary>
    /// Movement:
    /// </summary>
    
    public virtual void SetDistinationPosition(Ray ray)
    {
        SetCharacterDestination(HelperTrans.pointByRay(ray));
    }

    public virtual void OrientateHero(Ray ray)
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            StopNavAgent();
            Vector3 targetPoint = ray.GetPoint(hitdist);
            RotateCharacter(targetPoint);
        }
    }
}
