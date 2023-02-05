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
            case Emotion.Anger:
                return new Color32(255, 52, 52, 255);
            case Emotion.Sadness:
                return new Color32(0, 111, 242, 255);
            case Emotion.Anticipation:
                return new Color32(255, 255, 134, 255);
            case Emotion.Fear:
                return new Color32(139, 244, 55, 255);
            case Emotion.Aggression:
                return new Color32(255, 115, 14, 255);
            case Emotion.Pessimism:
                return new Color32(114, 158, 175, 255);
            case Emotion.Envy:
                return new Color32(202, 41, 133, 255);
            case Emotion.Anxiety:
                return new Color32(225, 255, 26, 255);
            case Emotion.Despair:
                return new Color32(0, 208, 208, 255);
            case Emotion.Powerless:
                return new Color32(165, 38, 17, 255);
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
            case Emotion.Anger:
                return new Color32(255, 73, 73, 255);
            case Emotion.Sadness:
                return new Color32(40, 112, 199, 255);
            case Emotion.Anticipation:
                return new Color32(255, 238, 128, 255);
            case Emotion.Fear:
                return new Color32(131, 194, 82, 255);
            case Emotion.Aggression:
                return new Color32(251, 104, 59, 255);
            case Emotion.Pessimism:
                return new Color32(128, 163, 164, 255);
            case Emotion.Envy:
                return new Color32(167, 72, 126, 255);
            case Emotion.Anxiety:
                return new Color32(188, 213, 56, 255);
            case Emotion.Despair:
                return new Color32(0, 177, 177, 255);
            case Emotion.Powerless:
                return new Color32(155, 69, 56, 255);
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
