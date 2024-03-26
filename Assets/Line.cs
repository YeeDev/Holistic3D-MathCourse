using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    Coords A;
    Coords B;
    Coords v;

    public enum LINETYPE { LINE, SEGMENT, RAY }
    LINETYPE type;

    public Line(Coords A, Coords B, LINETYPE type)
    {
        this.type = type;
        this.A = A;
        this.B = B;
        v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
    }

    public Line(Coords A, Coords v)
    {
        this.A = A;
        B = A + v;
        this.v = v;
    }

    public float IntersectsAt(Line l)
    {
        Coords c = l.A - A;
        Coords uPerp = Coords.Perp(l.v);
        return HolisticMath.Dot(uPerp, c) / HolisticMath.Dot(uPerp, v);
    }

    public void Draw(float width, Color col)
    {
        Coords.DrawLine(A, B, width, col);
    }

    public Coords Lerp(float t)
    {
        t = type == LINETYPE.SEGMENT ? Mathf.Clamp(t, 0, 1) :
            type == LINETYPE.RAY && t < 0 ? 0 : t;

        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new Coords(xt, yt, zt);
    }
}
