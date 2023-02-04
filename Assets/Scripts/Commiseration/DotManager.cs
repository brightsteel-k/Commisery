using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManager : MonoBehaviour
{
    private GameObject PREFAB_DOT;

    [SerializeField] private int[] path0;
    [SerializeField] private int[] path1;
    [SerializeField] private int[] path2;
    [SerializeField] private int[] path3;
    [SerializeField] private int[] path4;
    [SerializeField] private int[] path5;
    [SerializeField] private int[] path6;
    [SerializeField] private int[] path7;
    [SerializeField] private int[] path8;

    // Start is called before the first frame update
    void Start()
    {
        PREFAB_DOT = Resources.Load<GameObject>("Prefabs/CommiserateDot");
        initializePaths();
        LeanTween.init(800);
        Instantiate(PREFAB_DOT, Vector3.zero, Quaternion.identity, transform).GetComponent<Dot>().setPath(0);
    }

    void initializePaths()
    {
        initalizePath(path0, 0);
    }

    void initalizePath(int[] indices, int n)
    {
        List<Vector2> v = new List<Vector2>();
        foreach (int i in indices)
        {
            v.Add(Node.ALL_NODES[i]);
        }
        Dot.ALL_PATHS[n] = v.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
