using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotate : MonoBehaviour
{
    public GameObject[] points;
    public Vector3 angle;

    private void Start()
    {
        angle = angle * Mathf.Deg2Rad;
        foreach (GameObject p in points)
        {
            Coords position = new Coords(p.transform.position, 1);
            p.transform.position = HolisticMath.Rotate(position, angle.x, true, angle.y, true, angle.z, true).ToVector();
        }

        Matrix rot = HolisticMath.GetRotationMatrix(angle.x, true, angle.y, true, angle.z, true);
        float rotationAngle = HolisticMath.GetRotationAxisAngle(rot);
        Coords rotAxis = HolisticMath.GetRotationAxis(rot, rotationAngle);

        Debug.Log(rotationAngle * Mathf.Rad2Deg + " about" + rotAxis.ToString());
        Coords.DrawLine(new Coords(0, 0, 0), rotAxis * 5, 0.1f, Color.yellow);
    }

    private void Update()
    {
        
    }
}
