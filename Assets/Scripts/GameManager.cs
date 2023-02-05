using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static List<Emotion> CURRENT_EMOTIONS;

    public static Emotion FAILED_EMOTION;

    public static int COMMISERATE_SUCCESSES;

    public static int ROUNDS;

    private void Awake()
    {
        EventManager.COMMISERATE_WIN += generateNewRoom;
    }

    // Start is called before the first frame update
    void Start()
    {
        ROUNDS = 0;
        COMMISERATE_SUCCESSES = 0;

        CURRENT_EMOTIONS = new List<Emotion>();
        
        nextInterlocutor();
        EventManager.StartRoom();

    }

    public static void generateNewRoom() {
        EventManager.GenerateRoom();
        nextInterlocutor();
    }

    public static void nextInterlocutor()
    {

        CURRENT_EMOTIONS.Clear();

        if (ROUNDS == 0) {

            CURRENT_EMOTIONS.Add(Emotion.Sadness);

        } else if (ROUNDS == 1) {

            CURRENT_EMOTIONS.Add(Emotion.Sadness);
            CURRENT_EMOTIONS.Add(Emotion.Anticipation);

        } else if (ROUNDS == 2) {

            CURRENT_EMOTIONS.Add(Emotion.Anxiety);

        } else {

            for (int i = 0; i < Random.Range(1, 5); i++) {
                CURRENT_EMOTIONS.Add((Emotion) Random.Range(1, 11));
            }

        }

        ROUNDS++;

    }

    public static void tryCommiserateEmotion(Emotion emotion)
    {
        if (CURRENT_EMOTIONS.Contains(emotion))
            EventManager.StartCommiserate(emotion);
        else
            handleIncorrectChoice(emotion);

    }

    public static void handleIncorrectChoice(Emotion e) {

        FAILED_EMOTION = e;
        EventManager.Insanify(0.1f);
        EventManager.CommiserateLose();
    }

}