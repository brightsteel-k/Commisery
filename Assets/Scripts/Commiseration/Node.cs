using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Dictionary<int, Vector2> ALL_NODES = new Dictionary<int, Vector2>();
    [SerializeField] int id;

    private void Awake()
    {
        ALL_NODES.Add(id, transform.position);
        Debug.Log("Added id: " + id);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
