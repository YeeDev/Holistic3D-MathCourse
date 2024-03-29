using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateE : MonoBehaviour
{

    float angle;
    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        this.transform.forward = HolisticMath.QRotate(new Coords(transform.position), new Coords(Vector3.up), angle).ToVector();
    }
}
