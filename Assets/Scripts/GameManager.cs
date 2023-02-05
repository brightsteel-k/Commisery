using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Emotion> CURRENT_EMOTIONS;

    public static bool TRANSITION_COND_1;
    public static bool TRANSITION_COND_2;

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

        if (TRANSITION_COND_1 == true && TRANSITION_COND_2 == true)
            EventManager.TRANSITION_COMPLETED = false;
        
    }

    public void generateNewRoom() {

        TRANSITION_COND_1 = false;
        TRANSITION_COND_2 = false;
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