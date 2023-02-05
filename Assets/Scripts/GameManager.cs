using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Emotion> CURRENT_EMOTIONS;

    public static Emotion FAILED_EMOTION;

    private static int ROUNDS;

    // Start is called before the first frame update
    void Start()
    {
        ROUNDS = 0;

        CURRENT_EMOTIONS = new List<Emotion>();

        nextInterlocutor();
        EventManager.StartRoom();

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.H))
            EventManager.CommiserateLose();

    }

    public void generateNewRoom() {
        EventManager.GenerateRoom();
        nextInterlocutor();
    }

    public static void nextInterlocutor()
    {

        CURRENT_EMOTIONS.Clear();

        if (ROUNDS == 0) {

            CURRENT_EMOTIONS.Add(Emotion.Envy);
            CURRENT_EMOTIONS.Add(Emotion.Anxiety);
            CURRENT_EMOTIONS.Add(Emotion.Powerless);

        } else if (ROUNDS == 1) {

            CURRENT_EMOTIONS.Add(Emotion.Sadness);
            CURRENT_EMOTIONS.Add(Emotion.Anticipation);

        } else if (ROUNDS == 2) {

            CURRENT_EMOTIONS.Add(Emotion.Anxiety);

        } else {

            CURRENT_EMOTIONS.Add((Emotion) Random.Range(1, 11));
            CURRENT_EMOTIONS.Add((Emotion) Random.Range(1, 11));
            CURRENT_EMOTIONS.Add((Emotion) Random.Range(1, 11));

        }

        ROUNDS++;

    }

    public static void tryCommiserateEmotion(Emotion emotion)
    {
        if (CURRENT_EMOTIONS.Contains(emotion))
            EventManager.StartCommiserate(emotion);
        else
            EventManager.CommiserateLose();
    }

}