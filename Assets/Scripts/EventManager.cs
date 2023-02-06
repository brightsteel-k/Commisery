using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EventManager
{
    public static event Action<Emotion> START_COMMISERATE;
    public static event Action COMMISERATE_WIN;
    public static event Action COMMISERATE_LOSE;
    public static event Action GENERATE_ROOM;
    public static event Action START_ROOM;
    public static event Action<float> INSANIFY;
    public static event Action END_GAME;

    public static bool COMMISERATING = false;
    public static bool TRANSITION_COMPLETED = true;
    
    public static void StartCommiserate(Emotion e)
    {
        COMMISERATING = true;
        START_COMMISERATE?.Invoke(e);
    }

    public static void CommiserateWin()
    {
        COMMISERATING = false;
        COMMISERATE_WIN?.Invoke();
    }
    public static void CommiserateLose()
    {
        COMMISERATING = false;
        COMMISERATE_LOSE?.Invoke();
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
    public static void EndGame() {
        SceneManager.LoadScene(6);
    }
    public static void ResetEvents()
    {
        START_COMMISERATE = null;
        COMMISERATE_WIN = null;
        COMMISERATE_LOSE = null;
        GENERATE_ROOM = null;
        START_ROOM = null;
        INSANIFY = null;
        END_GAME = null;

        COMMISERATING = false;
        TRANSITION_COMPLETED = true;
}
}
