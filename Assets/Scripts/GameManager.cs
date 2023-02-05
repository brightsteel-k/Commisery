using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Emotion> CURRENT_EMOTIONS;

    // Start is called before the first frame update
    void Start()
    {

        CURRENT_EMOTIONS = new List<Emotion>();
        nextInterlocutor();

        EventManager.StartRoom();
        nextInterlocutor();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateNewRoom() {
        EventManager.GenerateRoom();

    }

    public static void nextInterlocutor()
    {
        CURRENT_EMOTIONS.Clear();
        CURRENT_EMOTIONS.Add((Emotion) Random.Range(1, 11));
        CURRENT_EMOTIONS.Add((Emotion) Random.Range(1, 11));
        CURRENT_EMOTIONS.Add((Emotion) Random.Range(1, 11));
    }

    public static void tryCommiserateEmotion(Emotion emotion)
    {
        if (CURRENT_EMOTIONS.Contains(emotion))
            EventManager.StartCommiserate(emotion);
        else
            EventManager.CommiserateLose();
    }

}