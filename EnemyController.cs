using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    PlayerController player;
    GameObject playerLocation;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    SimpleFlash flash;
    Animator animator;
    public ZombieData Data;

    public Image hpbar;

    public Vector2 attackSize;

    float HP;
    float MaxHP;
    int damage;
    float Speed;
    float AttackSpeed;
    int maxDistance;

    public bool canAttack;

    [HideInInspector]
    public bool fight;

    void Awake()
	{
        
        SetUP();
    }

	// Start is called before the first frame update
	void Start()
    {
        playerLocation = GameObject.FindWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        flash = GetComponent<SimpleFlash>();
        MaxHP = HP;
    }

    void Update()
    {
        hpbar.fillAmount = HP / MaxHP;
        
        Move();
        
    }


        // Update is called once per frame
    void FixedUpdate()
    {
       
        LayerChange();
        Dead();
    }
    private void SetUP()
    {
        HP = Data.Hp;
        damage = Data.Damage;
        Speed = Data.Speed;
        AttackSpeed = Data.AttackSpeed;
        maxDistance = Data.MaxDistance;
        canAttack = true;
        attackSize = new Vector2(1.4f, 1f);
    }

    public void Damage(int value, float Xpos, float knockback)
    {
        HP -= value;
        flash.Flash();


        if(Xpos < this.gameObject.transform.position.x)
        {
            rigid.AddForce(Vector2.right * knockback, ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(Vector2.left * knockback, ForceMode2D.Impulse);
        }
        animator.SetTrigger("Hit");
        
    }
    void Move()
    {

        if (Vector2.Distance(transform.position, playerLocation.transform.position) <= maxDistance + 0.5f)
        {
            if (canAttack)
            {
                animator.SetTrigger("Attack");
            }
            else
            {

            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.transform.position, Time.deltaTime * Speed);
        }

        if(playerLocation.transform.position.x < this.gameObject.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        animator.SetBool("isMove",true);
    }

    private void LayerChange()
    {
        if(player.transform.position.y > this.gameObject.transform.position.y)
        {
            sprite.sortingLayerName = "HighEnemy";
        }
        else
        {
            sprite.sortingLayerName = "Enemy";
        }
       
    }


    private void Dead()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {

        }
    }

    private void Attack()
    {

        Collider2D[] hit;

        if (!sprite.flipX)
        {
            hit = Physics2D.OverlapBoxAll(new Vector2(this.gameObject.transform.position.x + 1, this.gameObject.transform.position.y), attackSize, 0);
        }
        else
        {
            hit = Physics2D.OverlapBoxAll(new Vector2(this.gameObject.transform.position.x - 1, this.gameObject.transform.position.y), attackSize, 0);
        }

        foreach (Collider2D player in hit)
        {
            if (player.CompareTag("Player"))
            {
                player.GetComponent<PlayerController>().Damage(damage);
                this.player.cShake.CameraShaking(2f, 0.05f);


            }
            else
            {

            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector2(this.gameObject.transform.position.x +1, this.gameObject.transform.position.y), attackSize);
    }






}
