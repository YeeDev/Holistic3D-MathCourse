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
        type = LINETYPE.SEGMENT;
    }

    public float IntersectsAt(Line l)
    {
        if (HolisticMath.Dot(Coords.Perp(l.v), v) == 0) { return float.NaN; }

        Coords c = l.A - A;
        Coords uPerp = Coords.Perp(l.v);
        float t = HolisticMath.Dot(uPerp, c) / HolisticMath.Dot(uPerp, v);

        if ((t < 0 || t > 1) && type == LINETYPE.SEGMENT)
        {
            return float.NaN;
        }

        return t;
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
