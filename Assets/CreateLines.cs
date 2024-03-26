using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLines : MonoBehaviour
{
    Line L1;
    Line L2;

    private void Start()
    {
        L1 = new Line(new Coords(-100, 0, 0), new Coords(200, 150, 0));
        L1.Draw(1, Color.green);
        L2 = new Line(new Coords(-100, 10, 0), new Coords(200, 150, 0));
        L2.Draw(1, Color.red);

        float intersectT = L1.IntersectsAt(L2);
        float intersectS = L2.IntersectsAt(L1);

        if (intersectT == intersectT && intersectS == intersectS) // Checks if it's NaN
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = L1.Lerp(intersectT).ToVector();
        }
    }
}
