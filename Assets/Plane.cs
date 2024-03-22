using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{
    Coords A;
    Coords u;
    Coords v;

    public Plane(Coords A, Coords B, Coords C)
    {
        this.A = A;
        
        v = B - A;
        u = C - A;
    }

    public Plane(Coords A, Vector3 v, Vector3 u)
    {
        this.A = A;

        this.v = new Coords(v);
        this.u = new Coords(u);
    }

    public Coords Lerp(float s, float t)
    {
        return A + v * s + u * t;
    }
}
