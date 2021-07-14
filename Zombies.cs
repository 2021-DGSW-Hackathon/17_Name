using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    public static Transform[] zombies;
    void Awake()
    {
        zombies = new Transform[transform.childCount];
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i] = transform.GetChild(i);
        }
        this.gameObject.SetActive(false);
    }
}
