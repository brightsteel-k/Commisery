using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    public static bool COMMISERATING = false;

    public static event Action<Emotion> START_COMMISERATE;
    public static event Action COMMISERATE_MISTAKE;

    public static bool TRANSITION_COMPLETED = true;

    public static event Action GENERATE_ROOM;
    public static event Action START_ROOM;

    public static void StartCommiserate(Emotion e)
    {
        COMMISERATING = true;
        START_COMMISERATE?.Invoke(e);
    }

    public static void FailCommiserate()
    {
        COMMISERATE_MISTAKE?.Invoke();
    }

    public static void GenerateRoom() 
    {
        TRANSITION_COMPLETED = false;
        GENERATE_ROOM?.Invoke();
    }

    public static void StartRoom()
    {
        TRANSITION_COMPLETED = true;
        START_ROOM?.Invoke();
    }

}
