using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform start;
    public Transform end;
    Line line;

    void Start()
    {
        line = new Line(new Coords(start.position), new Coords(end.position));
    }

    private void Update()
    {
        transform.position = line.GetPointAt(Time.time).ToVector();
    }
}
