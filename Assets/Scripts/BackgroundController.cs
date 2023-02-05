using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    GameObject leftPane;
    GameObject rightPane;

    GameObject leftCharacter;
    GameObject rightCharacter;

    GameObject newCharacter;
    SpriteRenderer cSpriteRenderer;

    public Sprite[] sprites;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.transform.position = new Vector3(0, 0, 0);

        leftPane = transform.GetChild(0).gameObject;
        rightPane = transform.GetChild(1).gameObject;
        
        leftCharacter = generateCharacter(leftPane, 0f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G)) {

            rightCharacter = generateCharacter(rightPane, 20.498f, 1);

            translateNewRoom();

        }

    }

    GameObject generateCharacter(GameObject appendTo, float xPos, int sIndex) {

        newCharacter = new GameObject();
        newCharacter.name = "Character" + count;
        count++;

        newCharacter.transform.localScale = new Vector3(7.4f, 7.4f, 1f);
        newCharacter.transform.position = new Vector3(xPos, 0f, -0.1f);

        cSpriteRenderer = newCharacter.AddComponent<SpriteRenderer>();
        cSpriteRenderer.sprite = sprites[sIndex];

        newCharacter.transform.parent = appendTo.transform;

        return newCharacter;

    }

    void translateNewRoom() {

        gameObject.transform.position = new Vector3(0, 0, 0);
        LeanTween.moveX(gameObject, -20.498f, 4.0f)
                 .setEase(LeanTweenType.easeInOutCubic)
                 .setOnComplete(() => { 

                    Destroy(leftCharacter);

                    gameObject.transform.position = new Vector3(0, 0, 0);

                    rightCharacter.transform.parent = leftPane.transform;
                    rightCharacter.transform.position = new Vector3(0f, 0f, -0.1f);

                    leftCharacter = rightCharacter;


                 });

    }

}
