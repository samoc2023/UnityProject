using UnityEngine;

public class SimplePlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Mouse0; // Change to the desired input key
    public float dashDistance = 5f; // Adjust the dash distance

    private bool isAttacking = false;

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
        transform.Translate(Vector3.forward * dashDistance);

        // Reset the attacking flag after a short delay
        Invoke("ResetAttackFlag", 0.5f);
    }

    void ResetAttackFlag()
    {
        isAttacking = false;
    }
}
