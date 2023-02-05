using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nebula : MonoBehaviour
{

    GameObject current;
    SpriteRenderer sr;

    [SerializeField] Sprite orbSprite;

    int orbCount = 0;
    List<GameObject> orbs;

    float scale;

    void Awake()
    {

        orbs = new List<GameObject>();

        EventManager.GENERATE_ROOM += disableNebula;
        EventManager.START_ROOM += enableNebula;
        
    }

    void spawnOrbs() {

        float divisions = 2f * Mathf.PI / GameManager.CURRENT_EMOTIONS.Count;
        
        for (int i = 1; i <= GameManager.CURRENT_EMOTIONS.Count; i++) {

            current = new GameObject();
            current.name = "orb" + orbCount;
            orbCount++;

            Image img = current.AddComponent<Image>();
            img.sprite = orbSprite;
            img.color = Emotions.MainColor(GameManager.CURRENT_EMOTIONS[i-1]);

            scale = Random.Range(2f, 5f);

            current.transform.localScale = new Vector3(scale, scale, scale);

            current.transform.parent = transform;
            current.transform.SetSiblingIndex(Random.Range(0, GameManager.CURRENT_EMOTIONS.Count));

            current.transform.position = transform.Find("Veins").position 
                    + new Vector3(Mathf.Cos(i * divisions) *  60, Mathf.Sin(i * divisions) * 60, 0);

            orbs.Add(current);

        }

        transform.Find("Veins").SetSiblingIndex(GameManager.CURRENT_EMOTIONS.Count + 1);
        transform.Find("Gradient").SetSiblingIndex(0);

    }

    public void disableNebula() {

        print(orbs);
        foreach(GameObject o in orbs) {

            Destroy(o);

        }

        transform.Find("Gradient").gameObject.GetComponent<Image>().color = new Color(29f/255f, 29f/255f, 29f/255f, 255f);
        transform.Find("Veins").gameObject.GetComponent<Image>().color = new Color(29f/255f, 29f/255f, 29f/255f, 255f);

    }

    public void enableNebula() {

        transform.Find("Gradient").gameObject.GetComponent<Image>().color = Color.white;
        transform.Find("Veins").gameObject.GetComponent<Image>().color = Color.white;

        spawnOrbs();

    }

}
