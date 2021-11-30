using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;
    public float jumpForce = 1000;
    public float gravityModifier = 1;
    public bool isOnTheGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticleSystem;
    public ParticleSystem dirtParticleSystem;
    public AudioClip jumpClip;
    public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticleSystem.Stop();
            playerAudioSource.PlayOneShot(jumpClip, 1);

           
            isOnTheGround = false;
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {

            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                isOnTheGround = true;
                dirtParticleSystem.Play();
            }

            else if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log(message: "GAME OVER");
                // int randomRangeType = Random.Range(1, 3);
                playerAnimator.SetBool("Death_b", true);
                // playerAnimator.SetInteger("DeathType_int", randomRangeType);
                playerAnimator.SetInteger("DeathType_int", 1);

                //Activa la explosion
                explosionParticleSystem.Play();
                dirtParticleSystem.Stop();
                playerAudioSource.PlayOneShot(explosionClip, 1);
                cameraAudioSource.Stop();


                gameOver = true;
            }
        }
    }
}
