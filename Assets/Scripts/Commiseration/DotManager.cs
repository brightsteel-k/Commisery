using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class DotManager : MonoBehaviour
{
    [SerializeField] TextAsset serializedNodes;
    private GameObject PREFAB_DOT;
    private static List<(int, float)> CURRENT_SEQUENCE;
    private static Vector2[] ALL_NODES;
    public static Emotion CURRENT_EMOTION;
    private static DotManager INSTANCE;
    private static List<Dot> ACTIVE_DOTS = new List<Dot>();
    public static float DELTA_TIME;

    // Start is called before the first frame update
    void Start()
    {
        PREFAB_DOT = Resources.Load<GameObject>("Prefabs/CommiserateDot");
        initializeNodes(serializedNodes);
        initializePaths();
        INSTANCE = GetComponent<DotManager>();
        LeanTween.init(800);
    }

    private void Update()
    {
        if (CURRENT_EMOTION == Emotion.Pessimism)
            DELTA_TIME += Time.deltaTime;
    }

    static void initializeNodes(TextAsset t)
    {
        float[][] nodeRecords = JsonConvert.DeserializeObject<float[][]>(t.text);

        ALL_NODES = new Vector2[nodeRecords.Length];
        for (int k = 0; k < nodeRecords.Length; k++)
        {
            ALL_NODES[k] = new Vector2(nodeRecords[k][0], nodeRecords[k][1]);
        }
    }

    static void initializePaths()
    {
        // Regular paths
        initializePath(0, new int[] { 0, 1, 2, 34, 37, 38, 39, 19, 9, 10, 11, 12, 13, 14 }); // Chord 0, path A
        initializePath(1, new int[] { 0, 1, 2, 3, 4, 5, 33, 7, 31, 19, 9, 10, 15, 16, 17, 18 }); // Chord 1, path A
        initializePath(2, new int[] { 0, 1, 40, 35, 37, 38, 39, 31, 32, 27, 21, 22, 23, 24, 25, 26 }); // Chord 2, path A
        initializePath(3, new int[] { 0, 1, 40, 35, 37, 38, 39, 31, 7, 8, 20, 21, 27, 28, 29, 30 }); // Chord 3, path A
        initializePath(4, new int[] { 0, 1, 40, 36, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }); // Chord 0, path B
        initializePath(5, new int[] { 0, 1, 2, 34, 35, 36, 33, 8, 9, 10, 15, 16, 17, 18 }); // Chord 1, path B
        initializePath(6, new int[] { 0, 1, 40, 36, 33, 7, 31, 19, 20, 22, 23, 24, 25, 26 }); // Chord 2, path B
        initializePath(7, new int[] { 0, 1, 2, 34, 35, 36, 33, 7, 32, 28, 29, 30 }); // Chord 3, path B

        // Anxiety paths
        initializePath(8, new int[] { 0, 1, 2, 34, 35, 36, 33, 8, 19, 31, 6, 5, 33, 8, 9, 10, 11, 12, 13, 14 }); // Chord 0, path X
        initializePath(9, new int[] { 0, 1, 40, 36, 5, 6, 7, 8, 9, 10, 11, 12, 13, 12, 11, 15, 16, 12, 17, 18 }); // Chord 1, path X
        initializePath(10, new int[] { 0, 1, 40, 35, 37, 38, 39, 31, 32, 28, 29, 28, 27, 21, 22, 23, 24, 25, 26 }); // Chord 2, path X
        initializePath(11, new int[] { 0, 1, 2, 34, 35, 36, 5, 4, 3, 34, 37, 38, 39, 19, 8, 7, 32, 28, 29, 30 }); // Chord 3, path X
    }

    static void initializePath(int n, int[] indices)
    {
        List<Vector2> v = new List<Vector2>();
        foreach (int i in indices)
        {
            v.Add(ALL_NODES[i]);
        }
        Dot.ALL_PATHS[n] = v.ToArray();
    }

    public static void startCommiserate(Emotion emotion)
    {
        CURRENT_EMOTION = emotion;
        generateSequence();
        INSTANCE.StartCoroutine("spawnDots");
    }

    static List<(int, float)> generateSequence()
    {
        DELTA_TIME = 0f;
        CURRENT_SEQUENCE = new List<(int, float)>();
        int length = 8;
        float timeThreshold = 2;
        float difficulty = 1;
        int pathIndices = CURRENT_EMOTION == Emotion.Anxiety ? 12 : 8;
        if (CURRENT_EMOTION == Emotion.Envy)
        {
            int index = Random.Range(0, 4);
            length *= 2;
            for (int k = 0; k < length; k++)
            {
                CURRENT_SEQUENCE.Add((index * Random.Range(1, 3), Mathf.Pow(Random.Range(timeThreshold / 10f, 1f) / 1.5f, difficulty)));
            }
        }
        else
        {
            for (int k = 0; k < length; k++)
            {
                CURRENT_SEQUENCE.Add((Random.Range(0, pathIndices), Mathf.Pow(Random.Range(timeThreshold / 10f, 1f) * timeThreshold, difficulty)));
            }
        }

        return CURRENT_SEQUENCE;
    }

    IEnumerator spawnDots()
    {
        foreach ((int, float) dotPlan in CURRENT_SEQUENCE)
        {
            INSTANCE.spawnDot(dotPlan.Item1);
            yield return new WaitForSeconds(dotPlan.Item2);
        }
    }
    
    void spawnDot(int path)
    {
        Vector2 startPos = ALL_NODES[0];
        Dot d = Instantiate(PREFAB_DOT, startPos, Quaternion.identity, transform).GetComponent<Dot>();
        d.initialize(path, 150, path % 4, CURRENT_EMOTION);
        ACTIVE_DOTS.Add(d);
    }

    public static void removeDot(Dot d)
    {
        ACTIVE_DOTS.Remove(d);
    }
}
