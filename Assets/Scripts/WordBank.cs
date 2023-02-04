using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordBank : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private Mesh mesh;
    private Vector3[] originalVertices;
    private Vector3[] vertices;
    private float tick = 0;
    private string selectedEmotion = "";

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        mesh = tmp.mesh;
        setWord("");
    }

    // Update is called once per frame
    void Update()
    {
        vertices = mesh.vertices;
        animateWord();
        if (selectedEmotion != "")
            checkStartCommiserate();
    }

    public void setWord(string emotion)
    {
        selectedEmotion = emotion;
        tmp.SetText(emotion);
        tmp.ForceMeshUpdate();
        originalVertices = mesh.vertices;
    }

    private void animateWord()
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

    private Vector2 wobble(float time, float x, float y)
    {
        return new Vector2(Mathf.Sin(time * x) * 2f, Mathf.Cos(time * y) * 2f);
    }

    private void checkStartCommiserate()
    {

    }
}
