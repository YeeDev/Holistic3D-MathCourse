using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] ATTRIBUTES doorType;

    AttributeManager player;

    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject.GetComponent<AttributeManager>();

        if ((player.attributes & (int)doorType) != 0)
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().isTrigger = false;

        //player?.RemoveAttribute(doorType);
    }
}

public enum ATTRIBUTES
{
    ALL = 31,
    MAGIC = 16,
    INTELLIGENCE = 8,
    CHARISMA = 4,
    FLY = 2,
    INVISIBLE = 1
}