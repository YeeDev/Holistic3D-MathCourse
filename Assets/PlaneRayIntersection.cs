using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRayIntersection : MonoBehaviour
{
    public GameObject sheep;
    public GameObject quad;
    public GameObject[] fences;

    Plane mPlane;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] vertices = quad.GetComponent<MeshFilter>().mesh.vertices;
        mPlane = new Plane(quad.transform.TransformPoint(vertices[0]) + new Vector3(0, 0.3f, 0),
                            quad.transform.TransformPoint(vertices[1]) + new Vector3(0, 0.3f, 0),
                            quad.transform.TransformPoint(vertices[2]) + new Vector3(0, 0.3f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float t = 0.0f;

            if (mPlane.Raycast(ray, out t))
            {
                Vector3 hitPoint = ray.GetPoint(t);

                GameObject fence = GetClosestFence(hitPoint);
                Vector3[] vertices = fence.GetComponent<MeshFilter>().sharedMesh.vertices;
                Vector3 u = fence.transform.TransformPoint(vertices[1]) - fence.transform.TransformPoint(vertices[0]);
                Vector3 v = fence.transform.TransformPoint(vertices[2]) - fence.transform.TransformPoint(vertices[0]);
                Vector3 normal = Vector3.Cross(u, v);
                Vector3 c = fence.transform.position - hitPoint;

                Debug.DrawLine(fence.transform.position, normal, Color.red);
                Debug.DrawRay(hitPoint, c);
                Debug.Log(Vector3.Dot(normal, c));
                if(Vector3.Dot(normal, c) >= 0)
                    sheep.transform.position = hitPoint;
            }
        }
    }

    GameObject GetClosestFence(Vector3 hitPoint)
    {
        GameObject closestFence = null;
        float distance = Mathf.Infinity;
        foreach (GameObject fence in fences)
        {
            float distanceToCheck = Vector3.Distance(hitPoint, fence.transform.position);
            if (distanceToCheck < distance)
            {
                distance = distanceToCheck;
                closestFence = fence;
            }
        }

        return closestFence;
    }
}
