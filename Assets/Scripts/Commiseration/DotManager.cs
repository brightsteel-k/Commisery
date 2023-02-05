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
    private static Emotion CURRENT_EMOTION;
    private static DotManager INSTANCE;
    private static List<Dot> ACTIVE_DOTS = new List<Dot>();

    // Start is called before the first frame update
    void Start()
    {
        PREFAB_DOT = Resources.Load<GameObject>("Prefabs/CommiserateDot");
        initializeNodes(serializedNodes);
        initializePaths();
        INSTANCE = GetComponent<DotManager>();
        LeanTween.init(800);
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
        initalizePath(0, new int[] { 0, 1, 2, 34, 37, 38, 39, 19, 9, 10, 11, 12, 13, 14 }); // Chord 0, path A
        initalizePath(1, new int[] { 0, 1, 2, 3, 4, 5, 33, 7, 31, 19, 9, 10, 15, 16, 17, 18 }); // Chord 1, path A
        initalizePath(2, new int[] { 0, 1, 40, 35, 37, 38, 39, 31, 32, 27, 21, 22, 23, 24, 25, 26 }); // Chord 2, path A
        initalizePath(3, new int[] { 0, 1, 40, 35, 37, 38, 39, 31, 7, 8, 20, 21, 27, 28, 29, 30 }); // Chord 3, path A
        initalizePath(4, new int[] { 0, 1, 40, 36, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });// Chord 0, path B
        initalizePath(5, new int[] { 0, 1, 2, 34, 35, 36, 33, 8, 9, 10, 15, 16, 17, 18 }); // Chord 1, path B
        initalizePath(6, new int[] { 0, 1, 40, 36, 33, 7, 31, 19, 20, 22, 23, 24, 25, 26 }); // Chord 2, path B
        initalizePath(7, new int[] { 0, 1, 2, 34, 35, 36, 33, 7, 32, 28, 29, 30 }); // Chord 3, path B
    }

    static void initalizePath(int n, int[] indices)
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
        CURRENT_SEQUENCE = new List<(int, float)>();
        int length = 8;
        float timeThreshold = 2;
        float difficulty = 1;
        for (int k = 0; k < length; k++)
        {
            CURRENT_SEQUENCE.Add((Random.Range(0, 8), Mathf.Pow(Random.Range(timeThreshold / 10f, 1f) * timeThreshold, difficulty)));
        }

        return CURRENT_SEQUENCE;
    }

    IEnumerator spawnDots()
    {
        foreach ((int, float) dotPlan in CURRENT_SEQUENCE)
        {
            INSTANCE.SpawnDot(dotPlan.Item1);
            yield return new WaitForSeconds(dotPlan.Item2);
        }
    }
    
    void SpawnDot(int path)
    {
        Vector2 startPos = ALL_NODES[0];
        Dot d = Instantiate(PREFAB_DOT, startPos, Quaternion.identity, transform).GetComponent<Dot>();
        d.initialize(path, 150, path % 4, CURRENT_EMOTION.ChordColor());
        ACTIVE_DOTS.Add(d);
    }
}
