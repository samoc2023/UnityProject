using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpamount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpamount, ForceMode.Impulse);
        }
    }
}
