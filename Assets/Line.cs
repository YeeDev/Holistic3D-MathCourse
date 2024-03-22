using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    Coords A;
    Coords B;
    Coords v;

    public Line(Coords A, Coords B)
    {
        this.A = A;
        this.B = B;
        v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
    }

    public Coords GetPointAt(float t)
    {
        //Coords tCoord = new Coords(A.ToVector() + v.ToVector() * t); Done like a normal human being
        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new Coords(xt, yt, zt);
    }
}
