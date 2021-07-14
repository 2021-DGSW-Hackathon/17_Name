using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionController : MonoBehaviour
{
    private PlayerController player;
    private Animator animator;
    

    void Start()
    {
        player = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        animator.SetBool("isMove", player.movement.isMove);
        animator.SetFloat("AttackSpeed", player.AtkSpeed);


    }

    public void PlayerAttack(int a)
    {
        if (a == 1)
        {
            animator.SetTrigger("isAttack");
        }
        else if(a == 2)
        {
            animator.SetTrigger("AttackTwo");
        }
        else if (a == 3)
        {
            animator.SetTrigger("AttackThree");
        }
        else
        {
            Debug.LogError("연속공격 버그남 ㅅㄱ");
        }
    }

    
}
