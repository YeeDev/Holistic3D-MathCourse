using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float speed = 1.0f;

    void Update()
    {
        float rotationX = Input.GetAxis("Vertical") * rotationSpeed;
        float rotationY = Input.GetAxis("Horizontal") * rotationSpeed;
        float rotationZ = Input.GetAxis("HorizontalZ") * rotationSpeed;

        transform.Rotate(rotationX, 0, 0);
        transform.Rotate(0, rotationY, 0);
        transform.Rotate(0, 0, rotationZ);

        float translateZ = Input.GetAxis("VerticalY") * speed;
        transform.Translate(0, 0, translateZ);
    }
}
