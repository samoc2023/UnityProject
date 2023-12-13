using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject user;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - user.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = user.transform.position + offset;
    }
}
