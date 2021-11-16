using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    public float jumpForce = 1000;
    public float gravityModifier = 1;
    public bool isOnTheGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
           
            isOnTheGround = false;
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
        
        else if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(message: "GAME OVER");
            playerAnimator.SetBool("Death_b", true);
            gameOver = true;
        }
    }
}
