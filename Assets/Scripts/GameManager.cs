using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Emotion> CURRENT_EMOTIONS;
    public static Emotion FAILED_EMOTION;
    public static int SUCCESSES;
    public static int ROUNDS;
    public static int FAILS;

    private void Awake()
    {
        EventManager.COMMISERATE_LOSE += handleCommiserateFail;
    }

    // Start is called before the first frame update
    void Start()
    {

        ROUNDS = 0;
        SUCCESSES = 0;
        FAILED_EMOTION = Emotion.None;
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
        FAILS = 0;

        if (ROUNDS == 0) {

            CURRENT_EMOTIONS.Add((Emotion) Random.Range(0, 4));

        } else if (ROUNDS == 1) {

            CURRENT_EMOTIONS.Add((Emotion)Random.Range(0, 4));
            CURRENT_EMOTIONS.Add((Emotion)Random.Range(0, 4));

        } else if (ROUNDS == 2) {

            CURRENT_EMOTIONS.Add(Emotion.Envy);

        } else {

            for (int i = 0; i < Random.Range(2, 6); i++) {
                CURRENT_EMOTIONS.Add((Emotion) Random.Range(0, 10));
            }

        }

        ROUNDS++;

    }

    public static void tryCommiserateEmotion(Emotion emotion)
    {
        if (emotion == Emotion.None)
            return;

        if (CURRENT_EMOTIONS.Contains(emotion))
            EventManager.StartCommiserate(emotion);
        else
            handleIncorrectChoice(emotion);

    }

    public static void handleIncorrectChoice(Emotion e) {

        FAILED_EMOTION = CURRENT_EMOTIONS[Random.Range(0, CURRENT_EMOTIONS.Count)];
        EventManager.Insanify(0.1f);
        EventManager.CommiserateLose();
    }

    public static void handleCommiserateFail()
    {
        ThoughtBoard.playHurtSound();
        FAILS++;
        if (FAILS >= 3)
        {
            generateNewRoom();
        }
    }

    public static void handleCommiserateWin()
    {
        if (CURRENT_EMOTIONS.Count <= 0) {

            SUCCESSES++;
            generateNewRoom();

        }
    }
}