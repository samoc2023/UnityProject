using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullets : MonoBehaviour
{
    private Rigidbody bulletRB;

    private float speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.tag = "bullet";

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed);
        //transform.position = new Vector3(transform.position.x, 40, transform.position.z);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {


            print(" hit cow");
            Destroy(gameObject);

        }
    }


}
