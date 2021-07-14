using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float HP;
   
    [HideInInspector]
    public int MaxHP;
    public int damage;
    public float Speed;
    public float AtkSpeed;

    public Image HPbar;

    public AnimetionController animetion;
    public MovementController movement;
    public AttackController attack;
    public CamerShake cShake;

	void Awake()
	{
        SetUp();
    }

	void Start()
    {
        
        animetion = GetComponent<AnimetionController>();
        movement = GetComponent<MovementController>();
        attack = GetComponent<AttackController>();
        cShake = GameObject.FindObjectOfType<CamerShake>().GetComponent<CamerShake>();

    }

    
    void Update()
    {
        HPbar.fillAmount = HP / MaxHP;
        if (HP <= 0)
        {
            //게임 오버
        }
    }
    

    void SetUp()
    {
        MaxHP = 50;
        HP = MaxHP;
        
        damage = 1;
        Speed = 7;
        AtkSpeed = 1f;
    }

    public void SpeedUp(int value)
    {
        Speed += Speed * value/100;
    }

    public void Heal(int value)
    {
       
        if (HP + value >= MaxHP)
        {
            HP = MaxHP;
        }
        else
        {
            HP = HP + value;
        }
    }

    public void Damage(int value)
    {
        if(HP - value <= 0)
        {
            HP = 0;
        }
        else
        {
            HP = HP - value;
        }
    }


    


}
