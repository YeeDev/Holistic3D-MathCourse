using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath
{
    static public Coords GetNormal(Coords vector)
    {
        float magnitude = Distance(new Coords(0,0,0), vector);
        vector.x /= magnitude;
        vector.y /= magnitude;
        vector.z /= magnitude;

        return vector;
    }

    static public float Distance(Coords point1, Coords point2)
    {
        float diffSquare = Square(point1.x - point2.x) +
                            Square(point1.y - point2.y) +
                            Square(point1.z - point2.z);

        float squareRoot = Mathf.Sqrt(diffSquare);

        return squareRoot;
    }

    static public float Square(float value) => value * value;
}
