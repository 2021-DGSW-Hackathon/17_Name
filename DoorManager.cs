using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    public int roomCode;
    public Text roomName;
    public string clearMessege = "(Å¬¸®¾î!)";
    public bool clear = false;

    public GameObject player;

    [HideInInspector]
    public Transform cnvas;

    void Awake()
    {
        cnvas = transform.GetChild(0);
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(!RoomManager.fight){
            showRoomName();
		}
    }

    private void showRoomName()
    {
        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) <= 2f)
        {
            cnvas.gameObject.SetActive(true);
            if(!clear){
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (roomCode >= 0)
                    {
                        GameObject.Find("GameManager").GetComponent<GameManager>().moveToRoom(roomCode);
                        clear = true;
                        roomName.text = roomName.text + clearMessege;
                    }
                    else
                    {
                        GameObject.Find("GameManager").GetComponent<GameManager>().backToLobby();
                    }
                }
			}
        }
        else
        {
            cnvas.gameObject.SetActive(false);
        }
    }
}