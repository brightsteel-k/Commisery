using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    public static bool COMMISERATING;

    public static event Action<Emotion> START_COMMISERATE;
    public static event Action FAIL_COMMISERATE;

    public static void StartCommiserate(Emotion e)
    {
        START_COMMISERATE?.Invoke(e);
    }

    public static void FailCommiserate()
    {
        FAIL_COMMISERATE?.Invoke();
    }
}
