using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraph : MonoBehaviour
{
    [SerializeField] int size = 20;
    [SerializeField] int xMaxSize;
    [SerializeField] int yMaxSize;

    //My solution
    private void Start()
    {
        int yOffset = (int)(yMaxSize / (float)size);
        for (int y = -yOffset * size; y <= yOffset * size; y += size)
        {
            Color colour = y == 0 ? Color.red : Color.white;
            Coords.DrawLine(new Coords(xMaxSize, y), new Coords(-xMaxSize, y), 1f, colour);
        }

        int xOffset = (int)(xMaxSize / (float)size);
        for (int x = -xOffset * size; x <= xOffset * size; x += size)
        {
            Color colour = x == 0 ? Color.green : Color.white;
            Coords.DrawLine(new Coords(x, yMaxSize), new Coords(x, -yMaxSize), 1f, colour);
        }
    }

    #region Penny's Solution
    //Coords startPointXAxis = new Coords(160, 0);
    //Coords endPointXAxis = new Coords(-160, 0);

    //Coords startPointYAxis = new Coords(0, 100);
    //Coords endPointYAxis = new Coords(0, -100);

    //private void Start()
    //{
    //    Coords.DrawLine(startPointXAxis, endPointXAxis, 1, Color.red);
    //    Coords.DrawLine(startPointYAxis, endPointYAxis, 1, Color.green);

    //    for (int x = -160; x <= 160; x += size)
    //    {
    //        Coords.DrawLine(new Coords(x, -100), new Coords(x, 100), 1, Color.white);
    //    }

    //    for (int y = -100; y <= 100; y += size)
    //    {
    //        Coords.DrawLine(new Coords(-160, y), new Coords(160, y), 1, Color.white);
    //    }
    //}
    #endregion
}
