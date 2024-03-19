using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    public Text attributeDisplay;
    public int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MAGIC") { attributes |= (int)ATTRIBUTES.MAGIC; }
        else if (other.gameObject.tag == "INTELLIGENCE") { attributes |= (int)ATTRIBUTES.INTELLIGENCE; }
        else if (other.gameObject.tag == "CHARISMA") { attributes |= (int)ATTRIBUTES.CHARISMA; }
        else if (other.gameObject.tag == "FLY") { attributes |= (int)ATTRIBUTES.FLY; }
        else if (other.gameObject.tag == "INVISIBLE") { attributes |= (int)ATTRIBUTES.INVISIBLE; }
        else if (other.gameObject.tag == "GOLDEN") { attributes |= (int)ATTRIBUTES.ALL; }

        if (!other.gameObject.CompareTag("DOOR")) { Destroy(other.gameObject); }
    }

    public void RemoveAttribute(ATTRIBUTES toRemove) => attributes &= ~(int)ATTRIBUTES.MAGIC;

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
       
}
