using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    public static Vector2[][] ALL_PATHS = new Vector2[16][];
    private Vector2[] path;
    private int pathIndex = 0;
    private int chordIndex;
    private RawImage image;
    [SerializeField] private float speed;
    private bool clickable = false;
    private bool pessimistic = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y <= 289 && !clickable)
        {
            DotManager.DOTS_IN_RANGE[chordIndex].Add(this);
            clickable = true;
        }

        if (pessimistic)
            image.color = new Color(Emotions.PESSIMISM_FLASH.r, Emotions.PESSIMISM_FLASH.g, Emotions.PESSIMISM_FLASH.b, pessimistAlpha());
    }

    void nextNode()
    {
        float distance = Vector2.Distance(path[pathIndex], path[pathIndex + 1]);
        LeanTween.moveLocal(gameObject, path[pathIndex + 1], distance / speed)
            .setOnComplete(reachNode);
    }

    void reachNode()
    {
        pathIndex++;
        if (pathIndex == path.Length - 1)
            finishPath();
        else
            nextNode();
    }

    void finishPath()
    {
        ChordManager.chordFailure(chordIndex);
        CommiserateTree.failChord(chordIndex, DotManager.CURRENT_EMOTION == Emotion.Despair);
        DestroySelf();
    }

    public void initialize(int pathIndex, float speedIn, int chordIn, Emotion emotion)
    {
        image = GetComponent<RawImage>();
        path = ALL_PATHS[pathIndex];
        chordIndex = chordIn;
        speed = speedIn;
        image.color = emotion.ChordColor();
        pessimistic = emotion == Emotion.Pessimism;
        
        nextNode();
    }

    public void DestroySelf()
    {
        DotManager.removeDot(this);
        if (clickable)
            DotManager.DOTS_IN_RANGE[chordIndex].Remove(this);
        Destroy(gameObject);
    }

    public void GetDestroyed()
    {
        DotManager.removeDot(this);
        Destroy(gameObject);
    }

    private float pessimistAlpha()
    {
        return Mathf.Sin(DotManager.DELTA_TIME * 6f) / 2f + 0.5f;
    }
}
