using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody playerRb;
    public float gravityModifier = 1.5f;
    public float jumpGravity;
    public float jumpForce;
    public float speed;
    private Animator playerAnim;
    //public CharacterController characterController;
    private Vector3 moveDirection;
    public bool gameOver;
    private bool isOnGround;

   





    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        Physics.gravity *= jumpGravity;
        playerAnim = GetComponent<Animator>();
        //characterController = GetComponent<CharacterController>();
       


    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.z > -20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -21);
        }
        */

        //get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput * speed * Time.deltaTime, 0);
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

        else if (movementDirection == Vector3.zero) { playerAnim.SetBool("Static_b", false); }
           
        

         // While space is pressed , float up
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            moveDirection = Vector3.zero;
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce * jumpGravity, ForceMode.Impulse);
           

            playerAnim.SetTrigger("Jump_trig");
            

        }

        if (Input.GetKey(KeyCode.J))
        {
         
      


        }


    }


    

    private static void OnEndIsland()
    {
        SceneManager.LoadScene(2);
    }



    private void OnCollisionEnter(Collision collision)
    {
        //DETECTS IF PLAYER IS ON GROUND
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }



        // if player hits Ground
         if (collision.gameObject.CompareTag("Death"))
        {
            playerAnim.SetBool("Death_b", true);
            gameOver = true;
            Debug.Log("Game Over!");


        }

        if (collision.gameObject.CompareTag("endIsland"))
        {
            OnEndIsland();
        }
    }



       

        





    

}
