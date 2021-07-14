using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Zombie Data", menuName = "Scriptable Object/Zombie Data", order = int.MaxValue)]
public class ZombieData : ScriptableObject 
{   
    [SerializeField] private string zombieName;
    public string ZombieName { get { return zombieName; } }

    [SerializeField] private int hp; 
    public int Hp { get { return hp; } }

    [SerializeField] private int damage; 
    public int Damage { get { return damage; } }

    [SerializeField] private float speed;
    public float Speed { get { return speed; } }

    [SerializeField] private float attackSpeed; 
    public float AttackSpeed { get { return attackSpeed; } } 
    
    [SerializeField] private int maxDistance; 
    public int MaxDistance { get { return maxDistance; } } 
}


