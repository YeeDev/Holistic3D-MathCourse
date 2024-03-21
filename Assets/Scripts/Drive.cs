using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour
{
    float speed = 0.01f;
    public GameObject fuel;
    Vector3 direction;
    float stoppingDistance = 0.1f;

    private void Start()
    {
        direction = fuel.transform.position - transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, fuel.transform.position) > stoppingDistance)
        {
            this.transform.position += direction * speed;
        } 
    }
}