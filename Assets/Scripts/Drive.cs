using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    Vector2 Up = new Vector2(0, 1);
    Vector2 Right = new Vector2(1, 0);
    float speed = 0.2f;

    void Update()
    {
        Vector3 position = this.transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.x += Up.x * speed;
            position.y += Up.y * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            position.x += -Up.x * speed;
            position.y += -Up.y * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x += -Right.x * speed;
            position.y += -Right.y * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += Right.x * speed;
            position.y += Right.y * speed;
        }

        transform.position = position;
    }

    #region My Solution

    //[SerializeField] float speed;

    //void Update()
    //{

    //    if (Input.GetKey(KeyCode.DownArrow)) { Move(new Vector2(0, -1)); }
    //    else if (Input.GetKey(KeyCode.UpArrow)) { Move(new Vector2(0, 1)); }
    //    if (Input.GetKey(KeyCode.LeftArrow)) { Move(new Vector2(-1, 0)); }
    //    else if (Input.GetKey(KeyCode.RightArrow)) { Move(new Vector2(1, 0)); }
    //}

    //private void Move(Vector2 direction)
    //{
    //    Vector3 position = this.transform.position;
    //    position.x += direction.x * speed;
    //    position.y += direction.y *  speed;

    //    this.transform.position = position;
    //}
    #endregion
}