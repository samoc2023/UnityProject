<<<<<<< HEAD
using UnityEngine;

public class SimplePlayerAttack : MonoBehaviour
{
    private Rigidbody playerRb;
    public Animator playerAnim;

    public KeyCode attackKey = KeyCode.Mouse0; // Change to the desired input key
    public float dashDistance = 5f; // Adjust the dash distance

    private bool isAttacking = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

    }

    void Update()
    {
        // Check for user input to perform an attack
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            isAttacking = true;
            DashForward();
        }
    }

    void DashForward()
    {
        // Move the player forward
        playerRb.transform.Translate(Vector3.forward * dashDistance);

        // Reset the attacking flag after a short delay
        Invoke("ResetAttackFlag", 0.5f);
    }

    void ResetAttackFlag()
    {
        isAttacking = false;
    }
}
=======
using UnityEngine;

public class SimplePlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Mouse0; // Change to the desired input key
    public float dashForce = 5f; // Adjust the dash distance

    private bool isAttacking = false;
    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody component

    void Start()
    {
        // Ensure a Rigidbody component is attached to the player
        playerRigidbody = GetComponent<Rigidbody>();

        if (playerRigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on the player GameObject.");
        }
        else
        {
            Debug.Log("Rigidbody component found.");
        }
    }

    void Update()
    {
        // Check for user input to perform an attack
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            isAttacking = true;
            DashForward();
        }
    }

    void DashForward()
    {
        if (playerRigidbody != null)
        {
            // Calculate the new position based on the dash distance
            Vector3 newPosition = transform.position + transform.forward * dashForce;

            // Move the player using Rigidbody position
            playerRigidbody.MovePosition(newPosition);

            Debug.Log("Dashing forward. New position: " + newPosition);
        }

        // Reset the attacking flag after a short delay
        Invoke("ResetAttackFlag", 0.5f);
    }


    void ResetAttackFlag()
    {
        isAttacking = false;
    }
}
>>>>>>> 993d1051cb7680c02e22dbb861cfc4f2df4ab603
