using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectManager : MonoBehaviour
{
    public GameObject objPrefab;
    public Vector3 objPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(objPrefab,
                                        new Vector3(Random.Range(-100, 100),
                                                    Random.Range(-100, 100),
                                                    objPrefab.transform.position.z),
                                        Quaternion.identity);

        Debug.Log($"Fuel location: {obj.transform.position}");
        objPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
