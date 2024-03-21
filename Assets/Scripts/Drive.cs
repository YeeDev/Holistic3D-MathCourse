using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow)) { Move(new Vector2(0, -1)); }
        else if (Input.GetKey(KeyCode.UpArrow)) { Move(new Vector2(0, 1)); }
        if (Input.GetKey(KeyCode.LeftArrow)) { Move(new Vector2(-1, 0)); }
        else if (Input.GetKey(KeyCode.RightArrow)) { Move(new Vector2(1, 0)); }


    }

    private void Move(Vector2 direction)
    {
        Vector3 position = this.transform.position;
        position.x += direction.x * speed;
        position.y += direction.y *  speed;

        this.transform.position = position;
    }
}