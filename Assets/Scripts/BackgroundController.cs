using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    GameObject leftPane;
    GameObject rightPane;

    GameObject firstCharacter;

    GameObject newCharacter;
    SpriteRenderer cSpriteRenderer;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.transform.position = new Vector3(0, 0, 0);

        leftPane = transform.GetChild(0).gameObject;
        rightPane = transform.GetChild(1).gameObject;
        
        generateCharacter(leftPane, 0f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G)) {

            generateCharacter(rightPane, 17.76f, 1);

            translateNewRoom();

        }

    }

    void generateCharacter(GameObject appendTo, float xPos, int sIndex) {

        newCharacter = new GameObject();

        newCharacter.name = "Character";
        newCharacter.transform.localScale = new Vector3(7.4f, 7.4f, 1f);
        newCharacter.transform.position = new Vector3(xPos, 0f, -0.1f);

        cSpriteRenderer = newCharacter.AddComponent<SpriteRenderer>();
        cSpriteRenderer.sprite = sprites[sIndex];

        newCharacter.transform.parent = appendTo.transform;

    }

    void translateNewRoom() {

        gameObject.transform.position = new Vector3(0, 0, 0);
        LeanTween.moveX(gameObject, -17.76f, 4.0f).setEase(LeanTweenType.easeInOutCubic);;

    }

}
