using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireWeapon : MonoBehaviour
{

    public GameObject projectilePrefab;
    private Animator playerAnim;
    private float fireRate = 1.0f;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // While shoot button is pressed - reload
        if (Input.GetKey(KeyCode.J) && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);


        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {

            Destroy(other.gameObject);


        }


    }

}

