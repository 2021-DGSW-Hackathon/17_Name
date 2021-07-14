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
        
        //플레이어가 특정 문에 가까이 갈 시 방을 찾아서 RoomManager.fightCommand(true); 실행
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
