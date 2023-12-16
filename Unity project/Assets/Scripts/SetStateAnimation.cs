using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStateAnimation : MonoBehaviour
{
    public GameObject cow1, cow2, enemy;
    public Button btn1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setIdle()
    {
        cow1.GetComponent<Animator>().SetInteger("State", 0);
        cow2.GetComponent<Animator>().SetInteger("State", 0);
        enemy.GetComponent<Animator>().SetInteger("State", 0);
    }

    public void setWalk()
    {
        cow1.GetComponent<Animator>().SetInteger("State", 1);
        cow2.GetComponent<Animator>().SetInteger("State", 1);
        enemy.GetComponent<Animator>().SetInteger("State", 1);
    }

    public void setRun()
    {
        cow1.GetComponent<Animator>().SetInteger("State", 2);
        cow2.GetComponent<Animator>().SetInteger("State", 2);
        enemy.GetComponent<Animator>().SetInteger("State", 2);
    }

    public void setAttack()
    {
        // Assuming attack state is 3, adjust it based on your animator configuration
        cow1.GetComponent<Animator>().SetInteger("State", 3);
        cow2.GetComponent<Animator>().SetInteger("State", 3);
        enemy.GetComponent<Animator>().SetInteger("State", 3);
    }
}
