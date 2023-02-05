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

    private void Awake()
    {
        EventManager.GENERATE_ROOM += generateNewRoom;
        EventManager.COMMISERATE_LOSE += reactCharacter;
    }

    // Start is called before the first frame update
    private void Start()
    {

        gameObject.transform.position = new Vector3(0, 0, 0);

        leftPane = transform.GetChild(0).gameObject;
        rightPane = transform.GetChild(1).gameObject;
        
        leftCharacter = generateCharacter(leftPane, 0f, 0);

    }


    public void generateNewRoom() {

        rightCharacter = generateCharacter(rightPane, 20.498f, 1);

        translatePanes();

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


    private void translatePanes() {

        gameObject.transform.position = new Vector3(0, 0, 0);
        
        LeanTween.moveX(gameObject, -20.498f, 4.0f)
                 .setEase(LeanTweenType.easeInOutCubic)
                 .setOnComplete(() => { 

                    Destroy(leftCharacter);

                    gameObject.transform.position = new Vector3(0, 0, 0);

                    rightCharacter.transform.parent = leftPane.transform;
                    rightCharacter.transform.position = new Vector3(0f, 0f, -0.1f);

                    leftCharacter = rightCharacter;

                    EventManager.StartRoom();

                 });

    }


    void reactCharacter() {

        Vector3 initialLoc = leftCharacter.transform.position;
        
        LeanTween.moveX(leftCharacter, 0.3f, 0.2f)
                 .setEase(LeanTweenType.easeShake)
                 .setOnComplete(() => {

                    LeanTween.moveX(leftCharacter, 0.2f, 0.2f)
                        .setEase(LeanTweenType.easeShake);

                 });

    }


}
