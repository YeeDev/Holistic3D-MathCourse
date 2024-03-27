using System.Collections.Generic;
using UnityEngine;

public class PlaneRayIntersection : MonoBehaviour
{
    public GameObject sheep;
    public GameObject quad;
    public GameObject[] fences;

    Plane mPlane;
    Dictionary<GameObject, Vector3> normals = new Dictionary<GameObject, Vector3>();

    private void Awake()
    {
        Vector3[] vertices = quad.GetComponent<MeshFilter>().mesh.vertices;
        mPlane = new Plane(quad.transform.TransformPoint(vertices[0]) + new Vector3(0, 0.3f, 0),
                            quad.transform.TransformPoint(vertices[1]) + new Vector3(0, 0.3f, 0),
                            quad.transform.TransformPoint(vertices[2]) + new Vector3(0, 0.3f, 0));

        foreach (GameObject fence in fences)
        {
            vertices = fence.GetComponent<MeshFilter>().sharedMesh.vertices;
            Vector3 u = fence.transform.TransformPoint(vertices[1]) - fence.transform.TransformPoint(vertices[0]);
            Vector3 v = fence.transform.TransformPoint(vertices[2]) - fence.transform.TransformPoint(vertices[0]);
            Vector3 normal = Vector3.Cross(u, v);

            normals.Add(fence, normal);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float t = 0.0f;

            if (mPlane.Raycast(ray, out t))
            {
                Vector3 hitPoint = ray.GetPoint(t);

                GameObject fence = GetClosestFence(hitPoint);
                Vector3 normal = normals[fence];
                Vector3 c = fence.transform.position - hitPoint;

                if (Vector3.Dot(normal, c) > 0) { sheep.transform.position = hitPoint; }
            }
        }
    }

    private GameObject GetClosestFence(Vector3 hitPoint)
    {
        GameObject closestFence = null;
        float distance = Mathf.Infinity;
        foreach (GameObject fence in fences)
        {
            float distanceToCheck = Vector3.SqrMagnitude(fence.transform.position - hitPoint);
            if (distanceToCheck < distance)
            {
                distance = distanceToCheck;
                closestFence = fence;
            }
        }

        return closestFence;
    }
}
