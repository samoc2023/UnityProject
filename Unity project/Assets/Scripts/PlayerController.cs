using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody playerRb;
    public float gravityModifier = 1.5f;
    public float jumpForce;
    //public float forwardInput;

    public float speed;

    private Animator playerAnim;
    //public CharacterController characterController;
    public Vector3 moveDirection;
    


    public bool gameOver;
    public bool isOnGround = true;

   





    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        //characterController = GetComponent<CharacterController>();
       


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > -20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -21);
        }

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


            playerAnim.SetBool("Static_b", true);


            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;

        }









    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;


        // if player hits Ground
        if (collision.gameObject.CompareTag("Death") && gameOver)
        {
            gameOver = true;
            Destroy(gameObject);
            Debug.Log("Game Over!");

        }
    }



       

        





    

}
