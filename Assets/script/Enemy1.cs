using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            -0.5f,
            gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
}
