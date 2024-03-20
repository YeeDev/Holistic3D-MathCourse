using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject tank;
    public GameObject fuel;
    public Text tankPosition;
    public Text fuelPosition;
    public Text energyAmount;

    public void AddEnergy(string amount)
    {
        int n;
        if (int.TryParse(amount, out n))
        {
            energyAmount.text = n + "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tankPosition.text = tank.transform.position + "";
        fuelPosition.text = fuel.GetComponent<ObjectManager>().objPosition + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
