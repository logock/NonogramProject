using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHandler : MonoBehaviour
{
    SpriteRenderer spriteRenderer;  // Need this to change colours
    public GameObject cross;    // The "X" that happens when you want to cross the square out.. will either be enabled or disabled
    public GridHandler grid;    // Reference to our grid

    int state = 0; // 0... white, 1... black  .... 0 is default for now with squares starting off white. this will be expanded with colours in the future

    bool colourChanged = false;     // Check if the colour of the square was changed while mouse is being held..
                                    // colourChanged == true means that the square was clicked on and the left mouse button is being held

    void Start()
    {
        // Get the squares spriterender and the cross isn't enabled by default
        spriteRenderer = GetComponent<SpriteRenderer>();
        cross.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If left click isn't being held, no colour is being changed actively
        if (grid.leftClicked == false)
        {
            colourChanged = false;
        }
    }

    /* So we want to check if left mouse is being clicked/held and also if this square's colour has been changed
    colourChanged == true means that the square was clicked on and the left mouse button is currently being held
    
    If we're clicking/holding left mouse and haven't changed this square's colour yet, we want its colour to change
    */
    void OnMouseOver()  // If our mouse is on the square this function gets called
    {
        if (grid.leftClicked == true && colourChanged == false)
        {
            if (grid.colourBeingChanged == true && grid.colourChangedTo == state)
            {
                // To avoid inverse colouring:
                // Do nothing if squares in the grid are being changed to a certain colour and that colour corresponds with the same colour of this square
            }
            else
            {
                // If above isn't the case, we want to change our square's colours to the selected state and signal that colours are currently being changed in the grid
                changeState(grid.selectedState);
                colourChanged = true;
                grid.colourBeingChanged = true;
            }
        }
        // insert right click stuff here
    }

    void changeState(int toState)   // Change colours of the square
    {
        if (toState == state)   // If the colour is currently the same as the selected one, it will inverse itself into white again
        {
            state = 0;
            spriteRenderer.color = grid.states[0];
            grid.colourChangedTo = 0;
        }
        else    // Change to another colour otherwise; take colour from grid's state dictionary and notify grid which colour we are changing to
        {
            state = toState;
            spriteRenderer.color = grid.states[toState];
            grid.colourChangedTo = toState;
        }
    }
}

