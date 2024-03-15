using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    int doorType = AttributeManager.MAGIC;

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent<AttributeManager>().attributes & doorType) != 0)
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
