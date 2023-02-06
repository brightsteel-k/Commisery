using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static List<Emotion> CURRENT_EMOTIONS;

    /** Variables spanning the entire game */
    public static int TOTAL_SUCCESSES;
    public static int ROUNDS;

    /** Variables per mini-game round */
    public static Emotion FAILED_EMOTION;
    public static int STRIKES;

    private void Awake()
    {
        EventManager.COMMISERATE_LOSE += handleCommiserateFail;
    }

    void Start()
    {

        TOTAL_SUCCESSES = 0;
        ROUNDS = 0;
        STRIKES = 0;

        CURRENT_EMOTIONS = new List<Emotion>();
        
        nextInterlocutor();
        EventManager.StartRoom();

    }


    /**
    * Runs the sequence of shifting to a new room.
    */
    public static void generateNewRoom() {
        EventManager.GenerateRoom();
        nextInterlocutor();
    }


    /**
    * As player shifts to a new room, there are a new set of emotions to deal with.
    */
    public static void nextInterlocutor()
    {

        CURRENT_EMOTIONS.Clear();
        STRIKES = 0;

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


    /**
    * Checks if player chose the correct emotion.
    */
    public static void tryCommiserateEmotion(Emotion emotion)
    {
        if (CURRENT_EMOTIONS.Contains(emotion))
            EventManager.StartCommiserate(emotion);
        else
            handleIncorrectChoice(emotion);

    }


    private static void handleIncorrectChoice(Emotion e) {

        FAILED_EMOTION = CURRENT_EMOTIONS[Random.Range(0, CURRENT_EMOTIONS.Count-1)];
        EventManager.Insanify(0.1f);
        EventManager.CommiserateLose();
    }


    public static void handleCommiserateFail()
    {
        ThoughtBoard.playHurtSound();
        STRIKES++;
        if (STRIKES >= 3)
        {
            generateNewRoom();
        }
    }

    public static void handleCommiserateWin()
    {
        if (CURRENT_EMOTIONS.Count <= 0)
            generateNewRoom();
    }


}