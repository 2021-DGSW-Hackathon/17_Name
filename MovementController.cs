using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rigid;
    private Collider2D Collider2D;
    private SpriteRenderer sprite;
    
    private int XmoveInput;
    private int YmoveInput;
    public bool isflip;

    public bool isMove;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (XmoveInput != 0 || YmoveInput != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        if (player.attack.isAttack)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        flipCheck();

    }

    void FixedUpdate()
    {
        Move();
    }

    void MoveInput()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            XmoveInput = 1;
           
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            XmoveInput = -1;
        }
        else
        {
            XmoveInput = 0;
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            YmoveInput = 1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            YmoveInput = -1;
        }
        else
        {
            YmoveInput = 0;
        }

    }

    private void Move()
    {
        MoveInput();
        if (canMove)
        {
            
            rigid.position += new Vector2(XmoveInput, YmoveInput).normalized
                * player.Speed * Time.deltaTime;
        }
        else
        {

        }

        if (isflip)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    private void flipCheck()
    {
        if(XmoveInput == 1)
        {
            isflip = false;
        }
        else if (XmoveInput == -1)
        {
            isflip = true;
        }

    }
 
}
