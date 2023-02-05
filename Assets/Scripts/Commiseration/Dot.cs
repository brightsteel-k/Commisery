using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    static Color32[] PESSIMIST_COLORS = new Color32[] {
        new Color32(229, 233, 233, 255),
        new Color32(112, 138, 140, 255)
    };
    public static Vector2[][] ALL_PATHS = new Vector2[][] { null, null, null, null, null, null, null, null };
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
        if (transform.localPosition.y <= 288 && !clickable)
            clickable = true;

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
    }

    void checkClicked()
    {
        if (!clickable)
            return;

        DestroySelf();
    }

    public void initialize(int pathIndex, float speedIn, int chordIn, Emotion emotion)
    {
        image = GetComponent<RawImage>();
        ChordManager.CHORD_STRUMMED[chordIndex] += checkClicked;
        path = ALL_PATHS[pathIndex];
        chordIndex = chordIn;
        speed = speedIn;
        image.color = emotion.ChordColor();
        pessimistic = emotion == Emotion.Pessimism;
        
        nextNode();
    }

    void DestroySelf()
    {
        ChordManager.CHORD_STRUMMED[chordIndex] -= checkClicked;
        DotManager.removeDot(this);
        Destroy(gameObject);
    }
}
