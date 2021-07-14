using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{

    public static Transform[] rooms;
    // Start is called before the first frame update
    void Awake()
    {
        rooms = new Transform[transform.childCount];
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i] = transform.GetChild(i);
        }
    }
}
