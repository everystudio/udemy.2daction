using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float move_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float move_x = Input.GetAxis("Horizontal");

        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(
                move_x * move_speed,
                gameObject.GetComponent<Rigidbody2D>().velocity.y
                );


       if(Input.GetButton("Jump"))
		{
            Debug.Log("jump");
		}
        
    }
}
