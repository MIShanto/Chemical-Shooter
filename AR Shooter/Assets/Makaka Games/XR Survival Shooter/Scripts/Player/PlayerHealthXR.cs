using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthXR : MonoBehaviour
{
    public int startingHealth = 3;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    
    

    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    
    public GameObject playerDamageZone;                         // Static Collider is for the player to take damage.
    
    public UnityEvent OnDeath;

    Animator anim;                                              // Reference to the Animator component.
   
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    //PlayerMovement playerMovement;                              // Reference to the player's movement.
   public PlayerShootingXR playerShooting;                              // Reference to the PlayerShooting script.
   
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    
    private Color defaultColour; 

    void Awake ()
    {
        // Setting up the references.
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();

        // Set the initial health of the player.
        currentHealth = startingHealth;

        defaultColour = damageImage.color;
    }


    void Update ()
    {
        // If the player has just been damaged...
        if(damaged)
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp (damageImage.color, flashColour, flashSpeed * Time.deltaTime);
        }
        // Otherwise...
        else
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = defaultColour;
        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        UpdateUI();

        // Play the hurt sound effect.
        playerAudio.Play ();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if(currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death ();
        }
    }
    private void UpdateUI()
    {
        GameManager.instance.hudManager.UpdateHealthUI(startingHealth, currentHealth);
    }

    void Death ()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        playerShooting.DisableEffects ();

        // Tell the animator that the player is dead.
        anim.SetTrigger ("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play ();

        // Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    //event is embeded in player's Death Animation 
    public void RestartLevel ()
    {
        OnDeath.Invoke();
    }
}
