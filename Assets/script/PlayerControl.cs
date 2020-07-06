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

        // 移動量に応じてアニメーションさせる
        gameObject.GetComponent<Animator>().SetFloat("move" , Mathf.Abs(move_x));

        if (move_x != 0.0f)
        {
            float chara_dir = 1.0f;
            if( move_x < 0.0f)
            {
                chara_dir = -1.0f;
            }
            gameObject.transform.localScale = new Vector3(
                chara_dir,
                1.0f,
                1.0f
                );
        }


        // ジャンプ処理
        if(Input.GetButton("Jump"))
		{
            Debug.Log("jump");
		}
        
    }
}
