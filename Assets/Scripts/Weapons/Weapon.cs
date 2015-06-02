using UnityEngine;
using System.Collections;

using Global;

public class Weapon : MonoBehaviour 
{
	public enum WeaponType {Revolver, Shotgun};
	public GameObject shotOutPoint;
	public float shotDamage = 10f;
	public int ammoCount = 10;
	public int ammoInStack = 5;
	public float timeBetweenBullets = 1f;
	public float range = 100f;
	public float timerBetweenReload = 5f;
	
	float timer;
	float reloadTimer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.05f;

    private GameObject _shotGunObj;

	protected WeaponBehavior weaponBehavior;
	protected int unitAmmoCount = 0;

	// Use this for initialization
	void Awake () {
		shootableMask = LayerMask.GetMask (Layers.heroes);
		
		// Set up the references.
		gunParticles = shotOutPoint.GetComponent<ParticleSystem> ();
		gunAudio = shotOutPoint.GetComponent<AudioSource> ();
		gunLight = shotOutPoint.GetComponent<Light> ();

		timer = timeBetweenBullets;
		reloadTimer = timerBetweenReload;
	}

	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		reloadTimer += Time.deltaTime;
		
		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if(timer >= effectsDisplayTime)
		{
			// ... disable the effects.
			DisableEffects ();
		}
	}
	
	protected void DisableEffects()
	{
		gunLight.enabled = false;
	}

	protected void PlayEffects()
	{
		// Play the gun shot audioclip.
		gunAudio.Play ();

		// Enable the light.
		gunLight.enabled = true;

		// Stop the particles from playing if they were, then start the particles.
		gunParticles.Stop ();
		gunParticles.Play ();
	}

	protected void Reloading()
	{
		if ((ammoCount - ammoInStack) > 0)
		{
			unitAmmoCount = ammoInStack;
			ammoCount -= ammoInStack;
		}
		else
		{
			unitAmmoCount = ammoCount;
			ammoCount = 0;
		}
	}

	public void Shoot()
	{
		if (timer >= timeBetweenBullets && weaponBehavior.CanIShoot()) 
		{
			if (unitAmmoCount > 0)
			{
				unitAmmoCount--;

				timer = 0f;
				reloadTimer = 0;

				// Enable gunLine, gunLight and Play gunAudio.
				PlayEffects();
                
			}
			else if (reloadTimer >= timerBetweenReload)
			{
				Reloading();
			}
		}
	}
}
