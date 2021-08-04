using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    public GameObject square;   // Square prefab... how all squares should look and act like
    SquareHandler squareHandler;
    public int rows = 5;
    public int cols = 5;

    public Vector2 startPosition = new Vector2(-6, 4);  // From where the squares start being generated.. hopefully can change this later

    public bool leftClicked = false;    // Check if left mouse button is being held/clicked

    public bool rightClicked = false;   // Check if right mouse button is being held/clicked

    public IDictionary<int, Color> states = new Dictionary<int, Color>();   // Dictionary of all possible "states" aka colours the squares can be in the current game
    public int selectedState = 1; // 0... white, 1... black  .... Will start with black colour selected as default
    public bool colourBeingChanged = false;     // Check if colour is currently being changed in the grid, to avoid inversing colours (e.g: black to white AND white to black)
    public int colourChangedTo = 0;     // Which colour the colours are being changed to.. necessary for some checks (should i explain more thoroughly?)



    // Start is called before the first frame update
    void Start()
    {
        // Add states/colours manually atm, will be generated per level in the future
        states.Add(0, Color.white);
        states.Add(1, Color.black);
        states.Add(2, Color.red);
        states.Add(3, Color.green);

        // Get the squarehandler script from our square prefab and give it our grid
        squareHandler = square.GetComponent<SquareHandler>();
        squareHandler.grid = this;

        // Generate rows * columns of squares, will need to add them into an array later probably  
        Vector2 pos = startPosition;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Instantiate(square, pos, Quaternion.identity);
                pos.x = pos.x + 1.2f;
            }
            pos.x = startPosition.x;
            pos.y = pos.y - 1.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if left mouse button is being clicked/held
        if (Input.GetMouseButton(0) == true && Input.GetMouseButton(1) == false)
        {
            leftClicked = true;
        }

        // Don't want to deal with bugs when people hold both mouse buttons, so right click only works when you aren't left clicking, might rework later
        if (Input.GetMouseButton(0) == false && Input.GetMouseButton(1) == true)
        {
            rightClicked = true;
        }

        if (Input.GetMouseButton(0) == false && Input.GetMouseButton(1) == false)
        {
            leftClicked = false;
            rightClicked = false;
            colourBeingChanged = false;
        }
        for (int i = 1; i < states.Count; i++)
        {
            if (Input.GetKeyDown((KeyCode)(48 + i)))
            {
                ChangeSelectedState(i);
            }
        }

    }

    public void ChangeSelectedState(int toState)
    {
        selectedState = toState;
        Debug.Log("Selected state: " + selectedState);
    }
}
