using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{

    public static event Action<Emotion> START_COMMISERATE;
    public static event Action COMMISERATE_WIN;
    public static event Action COMMISERATE_LOSE;
    public static event Action GENERATE_ROOM;
    public static event Action START_ROOM;
    public static event Action<float> INSANIFY;

    public static bool COMMISERATING = false;
    public static bool TRANSITION_COMPLETED = true;
    
    public static void StartCommiserate(Emotion e)
    {
        COMMISERATING = true;
        START_COMMISERATE?.Invoke(e);
    }

    public static void CommiserateWin()
    {
        COMMISERATE_WIN?.Invoke();
    }
    public static void CommiserateLose()
    {
        GameManager.FAILED_EMOTION = Emotion.Despair;
        EventManager.Insanify(0.1f);
        COMMISERATE_LOSE?.Invoke();
        GenerateRoom();
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
    public static void Insanify(float amount)
    {
        INSANIFY?.Invoke(amount);
    }
}
