using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpirteofCars : MonoBehaviour
{
    public Sprite[] BlueSprites;
    public Sprite[] OrangeSprites;
    public GameObject blue;
    public GameObject orange; 
    // Start is called before the first frame update
    void Start()
    {
        foreach(var item in BlueSprites)
        {
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        var spriteofblue = blue.GetComponent<SpriteRenderer>();
        spriteofblue.sprite = BlueSprites[PlayerMove.priorityofBlue];
        var spriteoforange = orange.GetComponent<SpriteRenderer>();
        spriteoforange.sprite = OrangeSprites[PlayerMove.priorityofOrange];
    }
}
