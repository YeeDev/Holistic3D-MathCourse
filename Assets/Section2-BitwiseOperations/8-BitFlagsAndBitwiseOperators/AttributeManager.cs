using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeManager : MonoBehaviour
{
    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    public Text attributeDisplay;
    int attributes = 0;

    //You can add attributes by using bit flags, in this case, using the bitwise operator OR (|) 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MAGIC")) { attributes |= MAGIC; }
        else if (other.CompareTag("INTELLIGENCE")) { attributes |= INTELLIGENCE; }
        else if (other.CompareTag("CHARISMA")) { attributes |= CHARISMA; }
        else if (other.CompareTag("FLY")) { attributes |= FLY; }
        else if (other.CompareTag("INVISIBLE")) { attributes |= INVISIBLE; }
        else if (other.CompareTag("ANTIMAGIC")) { attributes &= ~MAGIC; }
        else if (other.CompareTag("THREE")) { attributes |= INTELLIGENCE | MAGIC | CHARISMA; }
        else if (other.CompareTag("ANTITWO")) { attributes &= ~(INTELLIGENCE | MAGIC); }
        else if (other.CompareTag("RESET")) { attributes = 0; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
       
}
