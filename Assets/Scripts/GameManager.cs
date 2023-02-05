using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Emotion> CURRENT_EMOTIONS;

    // Start is called before the first frame update
    void Start()
    {
        nextInterlocutor();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
            EventManager.GenerateRoom();
        
    }

    public static void nextInterlocutor()
    {
        CURRENT_EMOTIONS = new List<Emotion>();
        CURRENT_EMOTIONS.Add(Emotion.Sadness);
        CURRENT_EMOTIONS.Add(Emotion.Envy);
    }

    public static void tryCommiserateEmotion(Emotion emotion)
    {
        if (CURRENT_EMOTIONS.Contains(emotion))
            EventManager.StartCommiserate(emotion);
        else
            EventManager.FailCommiserate();
    }

}