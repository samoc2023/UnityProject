using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody playerRb;
    private float gravityModifier = 7f;
    public float jumpForce;
    public float speed = 40;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;

    private Animator playerAnim;
    private CharacterController characterController;
    private Vector3 moveDirection;
    


    public bool gameOver;
    public bool isOnGround;
    private bool isLowEnough;

   





    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
       


    }

    // Update is called once per frame
    void Update()
    {

        //get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
        //float magnitude = Mathf.Clamp01(moveDirection.magnitude) * speed;
        movementDirection.Normalize();
        playerRb.MovePosition(transform.position + movementDirection);


        //moveDirection = new Vector3(horizontal, 0, vertical);

        //Animations




        //forwardInput = Input.GetAxis("Vertical");


        //move player forward
        if (movementDirection != Vector3.zero)
        {
            //movementDirection = Vector3.forward * Time.deltaTime * speed;
            playerAnim.SetBool("Static_b", true);
            
        }

        else
            playerAnim.SetBool("Static_b", false);

        


       


        // While space is pressed , float up
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;
            playerAnim.SetBool("Static_b", true);


            playerAnim.SetTrigger("Jump_trig");
        }

        

       




    }

    private void OnCollisionEnter(Collision other)
    {
       
        // if player hits Ground
        if (other.gameObject.CompareTag("Death") && !gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }



       

        





    

}
