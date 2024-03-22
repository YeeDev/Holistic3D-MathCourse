using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform start;
    public Transform end;
    //Line line;

    void Start()
    {
        //line = new Line(new Coords(start.position), new Coords(end.position), Line.LINETYPE.SEGMENT);
    }

    private void Update()
    {
        transform.position = HolisticMath.Lerp(new Coords(start.position), new Coords(end.position), Time.time * 0.1f).ToVector();
    }
}
