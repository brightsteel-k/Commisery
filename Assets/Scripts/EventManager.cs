using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    public static bool COMMISERATING = false;

    public static event Action<Emotion> START_COMMISERATE;
    public static event Action FAIL_COMMISERATE;

    public static bool TRANSITION_COMPLETED;

    public static event Action GENERATE_ROOM;

    public static void StartCommiserate(Emotion e)
    {
        COMMISERATING = true;
        START_COMMISERATE?.Invoke(e);
    }

    public static void FailCommiserate()
    {
        FAIL_COMMISERATE?.Invoke();
    }

    public static void GenerateRoom() 
    {
        TRANSITION_COMPLETED = false;
        GENERATE_ROOM?.Invoke();
    }

}
