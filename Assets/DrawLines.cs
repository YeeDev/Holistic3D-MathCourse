using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    //Coords point = new Coords(10, 20);

    Coords startPointXAxis = new Coords(160, 0);
    Coords endPointXAxis = new Coords(-160, 0);
    Coords startPointYAxis = new Coords(0, 100);
    Coords endPointYAxis = new Coords(0, -100);

    Coords[] capricorn = {  new Coords(0, 15),
                            new Coords(3, 18),
                            new Coords(9, 22),
                            new Coords(15, 23),
                            new Coords(39, 35),
                            new Coords(40, 30),
                            new Coords(41, 25),
                            new Coords(7, 12),
                            new Coords(14, 9),
                            new Coords(42, 9) };

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(point.ToString());
        //Coords.DrawPoint(point, 2, Color.green);

        //x axis
        Coords.DrawLine(startPointXAxis, endPointXAxis, 1f, Color.red);
        //y axis
        Coords.DrawLine(startPointYAxis, endPointYAxis, 1f, Color.green);

        foreach (Coords coord in capricorn)
        {
            Coords.DrawPoint(coord, 1, Color.cyan);
        }

        Coords.DrawLine(capricorn[0], capricorn[1], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[1], capricorn[2], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[2], capricorn[3], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[3], capricorn[6], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[4], capricorn[5], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[5], capricorn[6], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[6], capricorn[9], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[0], capricorn[7], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[7], capricorn[8], 0.4f, Color.yellow);
        Coords.DrawLine(capricorn[8], capricorn[9], 0.4f, Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
