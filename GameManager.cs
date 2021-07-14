using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Transform startPoint;

    private Vector2 lobby;
    private GameObject room;

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
	}
    
    void Update()
    {
        
        //�÷��̾ Ư�� ���� ������ �� �� ���� ã�Ƽ� RoomManager.fightCommand(true); ����
    }

    public void moveToRoom(int roomNumber)
    {
        lobby = player.transform.position;
        room = Rooms.rooms[roomNumber].gameObject;
        Debug.Log(room.name);
        RoomManager.fight = true;
        room.GetComponent<RoomManager>().fightCommand();
        startPoint = room.transform.GetChild(2);
        player.transform.position = startPoint.position;
    }

    public void backToLobby()
    {
        player.transform.position = lobby;
        room.SetActive(false);
    }
}
