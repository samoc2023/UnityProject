using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullets : MonoBehaviour
{
    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed);
        //transform.position = new Vector3(transform.position.x, 40, transform.position.z);

    }
}
