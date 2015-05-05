using UnityEngine;
using System.Collections;

public class SkillKineticLeap: SkillController
{
    /// <summary>
    /// How far ahead an object can be moved
    /// </summary>
    public float maxDistance = 2f;

    /// <summary>
    // Time it will take object to move, in seconds
    /// </summary>
    public float moveTime = .1f;

    /// <summary>
    // Barrier objects in layers
    /// </summary>
    public LayerMask layerMask;

    /// <summary>
    // Particle for skill effect
    /// </summary>
    public GameObject partice;

    /// <summary>
    // Hero game object
    /// </summary>
    private GameObject hero;
    
    /// <summary>
    // Hero rigidbody component
    /// </summary>
    private Rigidbody rBody;

    /// <summary>
    // Hero collider component
    /// </summary>
    private Collider collider;

    /// <summary>
    // Reference to Hero script
    /// </summary>
    private Hero heroScript;

    /// <summary>
    // How far Hero move on each FixedUpdate cycle
    /// </summary>
    private float distanceByCycle;

    /// <summary>
    // Path length between the start and destination points
    /// </summary>
    private float remainingDistance;

    /// <summary>
    // A point where Hero should move to
    /// </summary>
    private Vector3 destinationPoint;

    /// <summary>
    // When Hero uses the skill its direction shouldn't change from the start and destination points
    /// </summary>
    private Vector3 initialDirection;

    /// <summary>
    // When Hero uses the skill its rotation shouldn't change from the start and destination points
    /// </summary>
    private Vector3 initialRotation;

    /// <summary>
    // Flag for movement process state
    /// </summary>
    private bool movementInProcess = false;

    /// <summary>
    // Reference to skill particle system
    /// </summary>
    private ParticleSystem particleSystem;
    
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag(Global.Tags.heroes);
        rBody = hero.GetComponent<Rigidbody>();
        collider = hero.GetComponent<CapsuleCollider>();
        heroScript = hero.GetComponent<Hero>();

        AttachParticle();
    }

    override public void Update()
    {
        base.Update();

        if (skill.isActive)
        {
            if (CanMoveToDestinationPoint())
            {
                heroScript.movementLocked = true;
                skill.isActive = false;
                movementInProcess = true;

                SaveInitialTransform();
                PrepareMovementPoints();
                ShowPartical();
            }
        }

        if (!movementInProcess)
        {
            heroScript.movementLocked = false;
        }
    }

    void FixedUpdate()
    {
        if (movementInProcess)
        {
            rBody.MovePosition(rBody.position + initialDirection * distanceByCycle);
            rBody.transform.eulerAngles = initialRotation;
            remainingDistance -= distanceByCycle;

            if (remainingDistance < distanceByCycle)
            {
                movementInProcess = false;
            }
        }
    }

    /// <summary>
    /// Check if there is an object in the target direction
    /// </summary>
    private bool CanMoveToDestinationPoint()
    {
        Vector3 start = rBody.position;
        destinationPoint = rBody.position + rBody.transform.forward * maxDistance;
        
        collider.enabled = false;
        bool hit = Physics.Linecast(start, destinationPoint, layerMask.value);
        collider.enabled = true;
        return !hit;
    }

    /// <summary>
    /// Hold on Hero transform information when the skill activates
    /// </summary>
    private void SaveInitialTransform()
    {
        initialDirection = rBody.transform.forward;
        initialRotation = rBody.transform.eulerAngles;
    }

    /// <summary>
    /// Get path points to move Hero object
    /// </summary>
    private void PrepareMovementPoints()
    {
        remainingDistance = (rBody.position - destinationPoint).magnitude;
        float fixedUpdatesCycles = moveTime / Time.fixedDeltaTime;
        distanceByCycle = remainingDistance / fixedUpdatesCycles;
    }

    /// <summary>
    /// Attach particle effect to Hero
    /// </summary>
    private void AttachParticle()
    {
        GameObject gameObject = (GameObject)Instantiate(partice);
        gameObject.transform.SetParent(hero.transform, false);
        particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Show particale effect
    /// </summary>
    private void ShowPartical()
    {
        particleSystem.Play();
    }
}
