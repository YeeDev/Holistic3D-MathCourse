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
    public Vector3 shear;

    private void Start()
    {
        Vector3 c = centre.transform.position;
        //angles = angles * Mathf.Deg2Rad;

        foreach (GameObject p in points)
        {
            Coords position = new Coords(p.transform.position, 1);

            //position = HolisticMath.Translate(position, new Coords(-c, 0));
            p.transform.position = HolisticMath.ReflectX(position).ToVector();
            //p.transform.position = HolisticMath.Translate(position, new Coords(c, 0)).ToVector();

            //position = HolisticMath.Scale(position, scaling.x, scaling.y, scaling.z);
            //p.transform.position = HolisticMath.Translate(position, new Coords(c, 0)).ToVector();
        }
        DrawLines();
    }

    private void DrawLines()
    {
        Line line = new Line(new Coords(points[0].transform.position), new Coords(points[1].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[3].transform.position), new Coords(points[2].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[0].transform.position), new Coords(points[2].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[1].transform.position), new Coords(points[3].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[0].transform.position), new Coords(points[4].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[1].transform.position), new Coords(points[6].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[4].transform.position), new Coords(points[6].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[4].transform.position), new Coords(points[5].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[5].transform.position), new Coords(points[7].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[6].transform.position), new Coords(points[7].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[2].transform.position), new Coords(points[5].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[3].transform.position), new Coords(points[7].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[4].transform.position), new Coords(points[9].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[6].transform.position), new Coords(points[9].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[5].transform.position), new Coords(points[8].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[7].transform.position), new Coords(points[8].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
        line = new Line(new Coords(points[9].transform.position), new Coords(points[8].transform.position), Line.LINETYPE.RAY);
        line.Draw(0.02f, Color.yellow);
    }
}
