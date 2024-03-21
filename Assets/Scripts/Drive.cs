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
        float a = HolisticMath.Angle(new Coords(0, 1, 0), new Coords(direction)) * 180f / Mathf.PI;
        Debug.Log("Angle to Fuel: " + a);
    }

    void Update()
    {
        if(HolisticMath.Distance(new Coords(transform.position), new Coords(fuel.transform.position)) > stoppingDistance)
        {
            this.transform.position += direction * speed * Time.deltaTime;
        } 
    }
}