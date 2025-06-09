using UnityEngine;
using UnityEngine.UI; 

public class JumpCounter : MonoBehaviour
{
    public Text jumpCounterText;    
    public AudioClip jumpSound;    // super mario sound
    public KeyCode jumpKey = KeyCode.Space;  

    private Rigidbody playerRigidbody;
    private AudioSource audioSource;
    private int jumpCount = 0;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

         if (playerRigidbody == null)
        {
            Debug.LogWarning("playerRigidbody is null");
        }

        if (audioSource == null)
        {
            Debug.LogWarning("audio is null");
        }

        if (jumpCounterText != null)
        {
            jumpCounterText.text = "Jumps: " + jumpCount;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && playerRigidbody.linearVelocity.y == 0)
        {
            Jump();
        }
    }

    void Jump()
    {
        jumpCount++;

        if (jumpCounterText != null)
        {
            jumpCounterText.text = "Jumps: " + jumpCount;
        }

        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
