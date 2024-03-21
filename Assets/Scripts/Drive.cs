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
    }

    void Update()
    {
        if(HolisticMath.Distance(new Coords(transform.position), new Coords(fuel.transform.position)) > stoppingDistance)
        {
            this.transform.position += direction * speed * Time.deltaTime;
        } 
    }
}