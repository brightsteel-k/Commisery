using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public static Vector2[][] ALL_PATHS = new Vector2[][] { null, null, null, null, null, null, null, null };
    private Vector2[] path;
    private int pathIndex = 0;
    [SerializeField] private float speed;
    private Color32 colour;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextNode()
    {
        float distance = Vector2.Distance(path[pathIndex], path[pathIndex + 1]);
        LeanTween.move(gameObject, path[pathIndex + 1], distance / speed)
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

    }


    public void setPath(int p)
    {
        path = ALL_PATHS[p];
        nextNode();
    }
}
