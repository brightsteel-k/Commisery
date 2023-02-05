using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private GameObject leftPane;
    private GameObject rightPane;

    private GameObject leftCharacter;
    private GameObject rightCharacter;

    private GameObject newCharacter;
    private SpriteRenderer cSpriteRenderer;

    public Sprite[] sprites;

    private int count = 0;

    // Start is called before the first frame update
    private void Start()
    {

        gameObject.transform.position = new Vector3(0, 0, 0);

        leftPane = transform.GetChild(0).gameObject;
        rightPane = transform.GetChild(1).gameObject;
        
        leftCharacter = generateCharacter(leftPane, 0f, 0);
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
            translateNewRoom();

    }



    private GameObject generateCharacter(GameObject appendTo, float xPos, int sIndex) {

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

    public void translateNewRoom() {

        rightCharacter = generateCharacter(rightPane, 20.498f, 1);

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
