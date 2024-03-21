using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour
{
    float speed = 5f;
    public GameObject fuel;
    Vector3 direction;
    float stoppingDistance = 0.1f;

    private void Start()
    {
        direction = fuel.transform.position - transform.position;
        Coords dirNormal = HolisticMath.GetNormal(new Coords(direction));
        direction = dirNormal.ToVector();
        float a = HolisticMath.Angle(new Coords(transform.up), new Coords(direction));

        bool clockwise = HolisticMath.Cross(new Coords(transform.up), dirNormal).z < 0;

        Coords newDir = HolisticMath.Rotate(new Coords(transform.up), a, clockwise);
        transform.up = newDir.ToVector();
    }

    void Update()
    {
        if(HolisticMath.Distance(new Coords(transform.position), new Coords(fuel.transform.position)) > stoppingDistance)
        {
            this.transform.position += direction * speed * Time.deltaTime;
        } 
    }
}