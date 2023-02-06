using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nebula : MonoBehaviour
{
    public static List<GameObject> ACTIVE_ORBS;
    GameObject current;
    SpriteRenderer sr;

    [SerializeField] Sprite orbSprite;

    int orbCount = 0;

    float scale;

    void Awake()
    {
        EventManager.GENERATE_ROOM += disableNebula;
        EventManager.START_ROOM += enableNebula;
    }

    void spawnOrbs() {

        ACTIVE_ORBS = new List<GameObject>();
        float divisions = 2f * Mathf.PI / GameManager.CURRENT_EMOTIONS.Count;
        
        for (int i = 1; i <= GameManager.CURRENT_EMOTIONS.Count; i++) {

            current = new GameObject();
            current.name = GameManager.CURRENT_EMOTIONS[i - 1].ToString();
            orbCount++;

            Image img = current.AddComponent<Image>();
            img.sprite = orbSprite;
            img.color = Emotions.MainColor(GameManager.CURRENT_EMOTIONS[i-1]);

            scale = Random.Range(2f, 5f);

            current.transform.localScale = new Vector3(scale, scale, scale);

            current.transform.parent = transform;
            current.transform.SetSiblingIndex(Random.Range(0, GameManager.CURRENT_EMOTIONS.Count));

            if (GameManager.CURRENT_EMOTIONS.Count == 1) {

                current.transform.position = transform.Find("Veins").position;

            } else {

                current.transform.position = transform.Find("Veins").position 
                    + new Vector3(Mathf.Cos(i * divisions) *  60, Mathf.Sin(i * divisions) * 60, 0);
                
            }


            ACTIVE_ORBS.Add(current);

        }

        transform.Find("Veins").SetSiblingIndex(GameManager.CURRENT_EMOTIONS.Count + 1);
        transform.Find("Gradient").SetSiblingIndex(0);

    }

    public void disableNebula() {

        foreach(GameObject o in ACTIVE_ORBS) {

            Destroy(o);

        }

        ACTIVE_ORBS.Clear();

        transform.Find("Gradient").gameObject.GetComponent<Image>().color = new Color(29f/255f, 29f/255f, 29f/255f, 255f);
        transform.Find("Veins").gameObject.GetComponent<Image>().color = new Color(29f/255f, 29f/255f, 29f/255f, 255f);

    }

    public void enableNebula() {

        transform.Find("Gradient").gameObject.GetComponent<Image>().color = Color.white;
        transform.Find("Veins").gameObject.GetComponent<Image>().color = Color.white;

        spawnOrbs();

    }

    public static void removeEmotion(Emotion emotion)
    {
        GameObject g = null;
        foreach (GameObject x in ACTIVE_ORBS)
        {
            if (x.name == emotion.ToString())
            {
                g = x;
                break;
            }
        }

        g.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        LeanTween.moveLocalY(g, g.transform.localPosition.y + 200f, 1.2f)
            .setEaseOutSine()
            .setOnComplete(e => {
                Destroy(g);
                ChordManager.enableInteraction();
                GameManager.handleCommiserateWin();
            });

        ACTIVE_ORBS.Remove(g);
    }
}
