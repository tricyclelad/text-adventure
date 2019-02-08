using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    private GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        foreach (var exit in currentRoom.exits)
        {
            exitDictionary.Add(exit.keyString, exit.valueRoom);
            controller.interactionDescriptionsInRoom.Add(exit.exitDescription);
        }
    }

    public void AttemptToChangeRooms(string direction)
    {
        if (exitDictionary.ContainsKey(direction))
        {
            currentRoom = exitDictionary[direction];
            controller.LogStringWithReturn("You go " + direction);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("There is no path " + direction);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
