using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Emotions
{
    public static Color32 MainColor(this Emotion emotion)
    {
        switch (emotion)
        {
            case Emotion.Happiness:
                return Color.yellow;
            default:
                return Color.white;
        }
    }

    public static Color32 ChordColor(this Emotion emotion)
    {
        switch (emotion)
        {
            case Emotion.Happiness:
                return Color.yellow;
            default:
                return Color.white;
        }
    }
}
public enum Emotion
{
    Happiness,
    Sadness,
    Anger,
    Fear,
    Anticipation,
    Envy,
    Pessimism,
    Anxiety,
    Aggression,
    Despair,
    Powerless,
    None
}
