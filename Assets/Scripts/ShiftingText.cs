using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShiftingText : MonoBehaviour
{
    protected float tick = 0;
    protected TextMeshProUGUI tmp;
    protected Mesh mesh;
    protected Vector3[] originalVertices;
    protected Vector3[] vertices;
    [SerializeField] float wobbleAmount;

    // Start is called before the first frame update
    public virtual void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        mesh = tmp.mesh;
        tmp.ForceMeshUpdate();
        originalVertices = mesh.vertices;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        animateWord();
    }

    public virtual void SetText(string text)
    {
        tmp.SetText(text);
        tmp.ForceMeshUpdate();
        originalVertices = mesh.vertices;
    }


    protected void animateWord()
    {
        tick += Time.deltaTime;
        vertices = mesh.vertices;
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
        return new Vector2(Mathf.Sin(time * x) * wobbleAmount, Mathf.Cos(time * y) * wobbleAmount);
    }
}
