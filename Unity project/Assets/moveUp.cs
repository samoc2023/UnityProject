using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUp : MonoBehaviour
{
    public float speed = 10;
    public float yRange;
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
        if (transform.position.y > yRange)
        {
            move = false;
        }
        if (move == true)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (move == false)
        {
            transform.Translate(new Vector3(0, 0, 0) * speed * Time.deltaTime);


        }
    }

}
