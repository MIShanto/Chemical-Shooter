using UnityEngine;

public class PlayerShootingXR : MonoBehaviour
{

    public GameManager.ChemicalType chemicalType;

    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.
    public PlayerMovementXR playerMovement;    

    float timer;                                    // A timer to determine when to fire.
    Ray shootRay = new Ray();                       // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    public ParticleSystem gunParticles;                    // Reference to the particle system.
    public LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    public Light faceLight;								// Duh
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
    bool canShoot = false;


    void Awake ()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask ("Shootable");

        // Set up the references.
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        //faceLight = GetComponentInChildren<Light> ();
    }


    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

#if !MOBILE_INPUT
        // If the Fire1 button is being press and it's time to fire...
        if(canShoot && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            // ... shoot the gun.
            Shoot ();
        }

#else
        // If there is input on the shoot direction stick and it's time to fire...
        if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
        {
            // ... shoot the gun
            Shoot();
            playerMovement.Animate(true);
            }
            else
            {
                playerMovement.Animate(false);
            }
#endif
        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects ();
        }
    }
    public void OnShootPress()
    {
        canShoot = true;
    }
    public void OnShootRelease()
    {
        canShoot = false;
    }

    public void DisableEffects ()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        // Reset the timer.
        timer = 0f;

        // Play the gun shot audioclip.
        gunAudio.Play ();

        // Enable the lights.
        gunLight.enabled = true;
        faceLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        gunParticles.Stop ();
        gunParticles.Play ();

        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealthXR enemyHealth = shootHit.collider.GetComponent <EnemyHealthXR> ();
            // If the EnemyHealth component exist...
            if(enemyHealth != null && chemicalType != enemyHealth.chemicalType)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition (1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
