using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour
{
    public GameObject[] points;
    public float angle;
    public Vector3 translation;
    public Vector3 scaling;
    public GameObject centre;
     
    private void Start()
    {
        Vector3 c = centre.transform.position;
        foreach (GameObject p in points)
        {
            Coords position = new Coords(p.transform.position, 1);

            position = HolisticMath.Translate(position, new Coords(-c, 0));
            position = HolisticMath.Scale(position, scaling.x, scaling.y, scaling.z);
            p.transform.position = HolisticMath.Translate(position, new Coords(c, 0)).ToVector();
        }
       
    }
}
