using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void OnDrawGizmos()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        
    }

    // FOR DEBUG PURPOSES ONLY
    void debugSetLabels()
    {
        GameObject g = new GameObject();
        g.transform.position = transform.position;
        TextMeshProUGUI tmp = g.AddComponent<TextMeshProUGUI>();
        tmp.SetText(id.ToString());
        tmp.fontSize = 25;
        tmp.horizontalAlignment = HorizontalAlignmentOptions.Center;
        tmp.verticalAlignment = VerticalAlignmentOptions.Middle;
        tmp.color = Color.black;
        g.transform.parent = transform;
    }
}
