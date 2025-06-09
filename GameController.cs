using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class GameController : MonoBehaviour
{
    public Text winMessageText;      
    public Text deathMessageText;    
    public AudioClip winSound;      
    public AudioClip deathSound;      
    private AudioSource audioSource; 
    public Transform respawnPoint;   
    public float respawnDelay = 2f;  
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Hide 
        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);
        }
        
        if (deathMessageText != null)
        {
            deathMessageText.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)  
    {
        if (collision.gameObject.CompareTag("EndFloor"))
        {
            HandleWin();
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            HandleDeath();
        }
    }

    void HandleWin()
    {
        //  win message  
        if (winMessageText != null)
        {
            winMessageText.text = "You Won!";
            winMessageText.gameObject.SetActive(true);   
        }

        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound); 
        }

        // hide
        if (deathMessageText != null)
        {
            deathMessageText.gameObject.SetActive(false);
        }
    }

    void HandleDeath()
    {
        if (deathMessageText != null)
        {
            deathMessageText.text = "You Died!";
            deathMessageText.gameObject.SetActive(true);   
        }

        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);  
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);
        }

        Invoke("RespawnPlayer", respawnDelay);
    }

    void RespawnPlayer()
    {
        if (respawnPoint != null)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.position = respawnPoint.position;

            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.linearVelocity = Vector3.zero;  
            }
        }

        if (deathMessageText != null)
        {
            deathMessageText.gameObject.SetActive(false);
        }
    }
}
