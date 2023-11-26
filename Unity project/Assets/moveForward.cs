using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    public float speed = 13;
    public float xRange;
    public bool move = true;
    // Start is called before the first frame update
    private Animator enemyAnim;
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        OnAnimatorMove();

    }

    private void OnAnimatorMove()
    {
        if(transform.position.x < xRange)
        {
            move = false;
        }
        if (move == true) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (move == false)
        {
         transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
          

            }
    }

}