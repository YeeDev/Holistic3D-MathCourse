using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour
{
    public GameObject[] points;
    public Vector3 translation;
    public Vector3 scaling;
    public GameObject centre;
    public Vector3 angles;
     
    private void Start()
    {
        Vector3 c = centre.transform.position;
        angles = angles * Mathf.Deg2Rad;

        foreach (GameObject p in points)
        {
            Coords position = new Coords(p.transform.position, 1);

            position = HolisticMath.Translate(position, new Coords(-c, 0));
            position = HolisticMath.Rotate(position, angles.x, true, angles.y, true, angles.z, true);
            p.transform.position = HolisticMath.Translate(position, new Coords(c, 0)).ToVector();

            //position = HolisticMath.Scale(position, scaling.x, scaling.y, scaling.z);
            //p.transform.position = HolisticMath.Translate(position, new Coords(c, 0)).ToVector();
        }
       
    }
}
