using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordBank : MonoBehaviour
{
    TextMeshProUGUI tmp;
    Mesh mesh;
    Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        mesh = tmp.mesh;
    }

    // Update is called once per frame
    void Update()
    {
        vertices = mesh.vertices;
        animateWord();
    }

    public void setWord(string emotion)
    {
        tmp.SetText(emotion);
    }

    void animateWord()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = wobble(Time.time + i, 10f, 9f);
            vertices[i] = vertices[i] + offset;
        }

        mesh.vertices = vertices;
        tmp.canvasRenderer.SetMesh(mesh);
    }

    Vector2 wobble(float time, float x, float y)
    {
        return new Vector2(Mathf.Sin(time * x), Mathf.Cos(time * y));
    }
}
