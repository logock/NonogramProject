using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHandler : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject cross;
    bool ctrlHeld = false;
    bool pressedLeft = false;
    bool isCrossed = false;

    public int state; // STATES: 1: WHITE  2: BLACK    3: CROSSED  ***NOT IMPLEMENTED***
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cross.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)))
        {
            ctrlHeld = true;
        }
        else
        {
            ctrlHeld = false;
        }
        if (Input.GetMouseButton(0) == true)
        {
            pressedLeft = true;
        }
        else
        {
            pressedLeft = false;
        }
    }



    void OnMouseEnter()
    {
        if (pressedLeft == true && ctrlHeld == false)
        {
            ChangeColor();
        }
        else if (pressedLeft == true && ctrlHeld == true)
        {
            if (isCrossed == false)
            {
                spriteRenderer.color = Color.white;
                cross.SetActive(true);
                isCrossed = true;
            }
            else
            {
                spriteRenderer.color = Color.white;
                cross.SetActive(false);
                isCrossed = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (ctrlHeld == true)
        {
            if (isCrossed == false)
            {
                spriteRenderer.color = Color.white;
                cross.SetActive(true);
                isCrossed = true;
            }
            else
            {
                spriteRenderer.color = Color.white;
                cross.SetActive(false);
                isCrossed = false;
            }
        }
        else
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        if (spriteRenderer.color == Color.white)
        {
            spriteRenderer.color = Color.black;
            cross.SetActive(false);
            isCrossed = false;
        }
        else if (spriteRenderer.color == Color.black)
        {
            spriteRenderer.color = Color.white;
            cross.SetActive(false);
            isCrossed = false;
        }
    }
}
