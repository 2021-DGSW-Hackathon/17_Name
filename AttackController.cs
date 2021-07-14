using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private PlayerController player;
    public bool inputReiceve;
    private bool canInput;
    public bool isAttack;

    public Vector2 attackSize;

    public Vector2 attackSize2;

    public AudioSource attackSound;



    // Start is called before the first frame update
    void Start()
    {
        attackSound = GetComponent<AudioSource>();
        player = GetComponent<PlayerController>();
        isAttack = false;

        attackSize = new Vector2(1.9f, 1);
        attackSize2 = new Vector2(2.8f, 1);

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputReiceve = true;
            if (!isAttack)
            {
                player.animetion.PlayerAttack(1);
            }
        }
        else
        {
            inputReiceve = false;
        }
    }

    public void FirstAttackCast()
    {
        Collider2D[] hit;

        if (!player.movement.isflip)
        {
            hit = Physics2D.OverlapBoxAll(new Vector2(player.transform.position.x + 1, player.transform.position.y), attackSize, 0);
        }
        else
        {
            hit = Physics2D.OverlapBoxAll(new Vector2(player.transform.position.x - 1, player.transform.position.y), attackSize, 0);
        }

        foreach (Collider2D enemy in hit)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyController>().Damage(player.damage, player.transform.position.x, 1f);
                player.cShake.CameraShaking(4f, 0.05f);
                attackSound.Play();

          
            }
            else
            {

            }
        }
             
    }

    public void SecondAttackCast()
    {
        Collider2D[] hit;

        if (!player.movement.isflip)
        {
            hit = Physics2D.OverlapBoxAll(new Vector2(player.transform.position.x + 1, player.transform.position.y), attackSize, 0);
        }
        else
        {
            hit = Physics2D.OverlapBoxAll(new Vector2(player.transform.position.x - 1, player.transform.position.y), attackSize, 0);
        }

        foreach (Collider2D enemy in hit)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyController>().Damage(player.damage,player.transform.position.x, 2.5f);
                player.cShake.CameraShaking(6f, 0.05f);
                attackSound.Play();
            }
            else
            {

            }
        }

    }

    private void OnDrawGizmos()
    {
        
    }




}
