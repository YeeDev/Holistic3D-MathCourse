using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    public Transform start;
    public Transform end1;
    public Transform end2;
    Plane plane;


    private void Start()
    {
        plane = new Plane(new Coords(start.position), new Coords(end1.position), new Coords(end2.position));

        for (float s = 0; s < 1; s += 0.1f)
        {
            for (float t = 0; t < 1; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
            }
        }
    }
}
