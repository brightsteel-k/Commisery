using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordBank : MonoBehaviour
{
    TextMeshProUGUI tmp;
    Mesh mesh;
    Vector3[] originalVertices;
    Vector3[] vertices;
    float tick = 0;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        mesh = tmp.mesh;
        setWord("Anger");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mesh.vertices.Length);
        vertices = mesh.vertices;
        animateWord();
    }

    public void setWord(string emotion)
    {
        tmp.SetText(emotion);
        tmp.ForceMeshUpdate();
        originalVertices = mesh.vertices;
        Debug.Log(originalVertices.Length);
    }

    void animateWord()
    {
        tick += Time.deltaTime;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = wobble(tick + i, 8f, 6f);
            vertices[i] = originalVertices[i] + offset;
        }

        mesh.vertices = vertices;
        tmp.canvasRenderer.SetMesh(mesh);
    }

    Vector2 wobble(float time, float x, float y)
    {
        return new Vector2(Mathf.Sin(time * x) * 2f, Mathf.Cos(time * y) * 2f);
    }
}
