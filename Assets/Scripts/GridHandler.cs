using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    public int rows = 5;
    public int cols = 5;

    public Vector2 startPosition = new Vector2(-6, 4);
    void Start()
    {
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

    }
}
