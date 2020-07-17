using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float move_speed;
    public bool is_goal;
    public bool is_dead;
    public bool is_ground;      // true:接地 false:浮いている


    public float jump_power = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask layer_mask = LayerMask.GetMask("ground");

        RaycastHit2D hit_ground = Physics2D.CircleCast(
            new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),
            0.5f,
            new Vector2(0.0f, -1.0f),
            0.52f,
            layer_mask);

        if( hit_ground.collider != null)
        {
            is_ground = true;
        }
        else
        {
            is_ground = false;
        }

        float move_x = Input.GetAxis("Horizontal");
        if (is_goal == true) {
            move_x = 0.0f;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(
                move_x * move_speed,
                gameObject.GetComponent<Rigidbody2D>().velocity.y
                );

        // 移動量に応じてアニメーションさせる
        gameObject.GetComponent<Animator>().SetFloat("move" , Mathf.Abs(move_x));
        gameObject.GetComponent<Animator>().SetBool("goal", is_goal);

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
        if (Input.GetButtonDown("Jump") && is_ground)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(0.0f, 7.0f),
                ForceMode2D.Impulse);
        }

        if (gameObject.transform.position.y < -7.0f && is_dead == false)
        {
            GameObject.Find("GameMain").SendMessage("OnHitEnemy");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string layer_name = LayerMask.LayerToName(collision.gameObject.layer);
        if (layer_name == "goal")
        {
            Debug.Log("goal!!!");
            GameObject.Find("GameMain").SendMessage("OnGoal");
        }
        else if( layer_name == "enemy")
        {
            Debug.Log("hit enemy");
            GameObject.Find("GameMain").SendMessage("OnHitEnemy");
        }
    }





}
