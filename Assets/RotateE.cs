using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateE : MonoBehaviour
{
    public Vector3 eulerAngles;
    Matrix rotationMatrix;
    float angle;
    Coords axis;

    private void Start()
    {
        Vector3 radians = eulerAngles * Mathf.Deg2Rad;
        rotationMatrix = HolisticMath.GetRotationMatrix(radians.x, false, radians.y, false, radians.z, false);
        angle = HolisticMath.GetRotationAxisAngle(rotationMatrix);
        axis = HolisticMath.GetRotationAxis(rotationMatrix, angle);
    }

    void Update()
    {
        //this.transform.forward = HolisticMath.Rotate(new Coords(this.transform.forward, 0),
        //                                            1 * Mathf.Deg2Rad, false,
        //                                            1 * Mathf.Deg2Rad, false,
        //                                            1 * Mathf.Deg2Rad, false).ToVector();

        Coords quaternion = HolisticMath.Quaternion(axis, angle);
        transform.rotation *= new Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
    }
}
