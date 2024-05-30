// using System. Collections;
// using System. Collections. Generic;
// using UnityEngine;
// public class MakeTerrain : MonoBehaviour {
//     void Start()
//     {
//         Mesh mesh = this.
//         GetComponent<MeshFilter>().mesh;
//         Vector3[] vertices = mesh.vertices;

//         for (int v = 0; v < vertices. Length; v++)
//         {
//         vertices[v].y = Mathf. Sin(vertices[v].x * 10);
//         }


//         mesh.vertices = vertices;
//         mesh. RecalculateBounds();
//         mesh. RecalculateNormals();

//         this.gameObject. AddComponent<MeshCollider>();
//     }
// }


using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
using UnityEngine;

public class MakeTerrain : MonoBehaviour
{

    void Start()
    {
        Perlin surface = new Perlin();
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for (int v = 0; v < vertices.Length; v++)
        {
            float x = vertices[v].x + 0.1365143f;
            float z = vertices[v].z + 1.21688f;
            vertices[v].y = surface.Noise(x, z) * 3;

            if (vertices[v].y < 0)
            {
                vertices[v].y = 0;
            }
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        this.gameObject.AddComponent<MeshCollider>();
    }
}