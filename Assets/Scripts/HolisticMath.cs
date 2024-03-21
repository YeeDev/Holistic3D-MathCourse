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

    static public float Dot(Coords vector1, Coords vector2)
    {
        return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2) / (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide); //This is radians. For degrees * 180/PI;
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.ToVector() - position.ToVector());
        float angle = HolisticMath.Angle(forwardVector, direction);

        bool clockwise = HolisticMath.Cross(forwardVector, direction).z < 0;

        return HolisticMath.Rotate(forwardVector, angle, clockwise);
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise) //In radians
    {
        if (clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }

    static public Coords Cross(Coords vector1, Coords vector2)
    {
        float xMult = vector1.y * vector2.z - vector1.z * vector2.y;
        float yMult = vector1.z * vector2.x - vector1.x * vector2.z;
        float zMult = vector1.x * vector2.y - vector1.y * vector2.x;
        return new Coords(xMult, yMult, zMult);
    }
}
