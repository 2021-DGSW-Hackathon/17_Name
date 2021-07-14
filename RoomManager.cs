using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public int maxZombieCount = 0;
    public GameObject door;

    [HideInInspector]
    static public bool fight = false;

    void Update()
	{
        if (fight){
		    if(transform.childCount > 5){
                door.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                fight = false;
            }
		}
	}

	public void fightCommand()
    {

        for (int i = 0; i < maxZombieCount; i++)
        {
            Vector2 pos = new Vector2(Random.Range(gameObject.transform.GetChild(0).transform.position.x, gameObject.transform.GetChild(1).transform.position.x), Random.Range(gameObject.transform.GetChild(0).transform.position.y, gameObject.transform.GetChild(1).transform.position.y));
            GameObject.Instantiate(Zombies.zombies[Random.Range(0, Zombies.zombies.Length)].gameObject, pos, Quaternion.identity).transform.parent = gameObject.transform;
        }

        for (int i = 5; i < transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<EnemyController>().fight = fight;
        }
    }
}
