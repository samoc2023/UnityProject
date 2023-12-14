using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    private Rigidbody playerRb;
    public float gravityModifier;

    public float jumpForce;
    public float speed;
    private Animator playerAnim;
    public bool gameOver;
    public bool isOnGround;
    public bool hasPowerup;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
 
        playerAnim = GetComponent<Animator>();
        



    }

    // Update is called once per frame
    void Update()
    {

       
        //get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput * speed, 0);
       
        playerRb.MovePosition(transform.position + movementDirection);


        //moveDirection = new Vector3(horizontal, 0, vertical);

        //Animations




        //forwardInput = Input.GetAxis("Vertical");


        //move player forward
        if (movementDirection != Vector3.zero && isOnGround)
        {
            //movementDirection = Vector3.forward * Time.deltaTime * speed;
            playerAnim.SetBool("Static_b", true);

        }

        else if (movementDirection == Vector3.zero)
        {
            playerAnim.SetBool("Static_b", false);
        }




        // While space is pressed - Jump
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            movementDirection = Vector3.zero;
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce * gravityModifier, ForceMode.Impulse);


            playerAnim.SetTrigger("Jump_trig");
            playerAnim.SetBool("Static_b", false);



        }



        // While shoot button is pressed - reload
        if (Input.GetKey(KeyCode.J))
        {
            playerAnim.SetTrigger("Shoot_trig");


        }


    }





    private void OnCollisionEnter(Collision collision)
    {
        //DETECTS IF PLAYER IS ON GROUND
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;



        }
        else if (collision.gameObject.tag != "Ground")
        {
            isOnGround = false;
           
        }
        /*
                if (collision.gameObject.tag != "Ground")
                {
                    isOnGround = false;
                    playerRb.AddForce(Vector3.down  * jumpGravity, ForceMode.Impulse);

                }
        */

        if (!isOnGround)
        {
            playerAnim.SetBool("Static_b", false);

        }


        // if player hits Ground
        else if (collision.gameObject.CompareTag("Death"))
        {
            playerAnim.SetBool("Death_b", true);
            gameOver = true;
            Debug.Log("Game Over!");
            transform.position = new Vector3(transform.position.x, 40, transform.position.z);
        }

        else if (collision.gameObject.CompareTag("powerup"))
        {
            hasPowerup = true;
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.CompareTag("endIsland")) { OnEndIsland(); }

    }
    private void OnTriggerEnter(Collider other)
    {



    }


    private static void OnEndIsland()
    {
        SceneManager.LoadScene(2);
    }




}
