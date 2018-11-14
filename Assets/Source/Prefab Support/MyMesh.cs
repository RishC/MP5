using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MyMesh : MonoBehaviour
{

    public int M = 2;
    public int N = 2;

    // Use this for initialization
    void Start () {
        Mesh theMesh = GetComponent<MeshFilter>().mesh;   // get the mesh component
        theMesh.Clear();    // delete whatever is there!!

        int vertNum = (M + 1) * (N + 1);
        int triangNum = (2 * M * N * 3);

        Vector3[] v = new Vector3[vertNum];   // 2x2 mesh needs 3x3 vertices
        int[] t = new int[triangNum];         // Number of triangles: 2x2 mesh and 2x triangles on each mesh-unit
        Vector3[] n = new Vector3[vertNum];   // MUST be the same as number of vertices

        int z = 0;
        for (int i = 0; i < (M + 1); i++)
        {
            for (int j = 0; j < (N + 1); j++)
            {
                v[z] = new Vector3(j - 1, 0, i - 1);
                z++;
            }
        }

        for (int i = 0; i < vertNum; i++)
        {
            n[i] = new Vector3(0, 1, 0);
        }

        z = 0;
        int b = 0; //base value
        for (int i = 0; i < (M); i++)
        {
            for (int j = 0; j < (N); j++)
            {

                //bottom triangle
                t[z] = b;
                t[z + 1] = b + N + 1;
                t[z + 2] = t[z + 1] + 1;

                //top triangle
                t[z + 3] = b;
                t[z + 4] = t[z + 2];
                t[z + 5] = b + 1;

                z += 6;
                b++;
            }
            b++;
        }

        theMesh.vertices = v; //  new Vector3[3];
        theMesh.triangles = t; //  new int[3];
        theMesh.normals = n;

        InitControllers(v);
    }

    void Update()
    {         Mesh theMesh = GetComponent<MeshFilter>().mesh;         Vector3[] v = theMesh.vertices;         for (int i = 0; i < mControllers.Length; i++)         {             v[i] = mControllers[i].transform.localPosition;         }          theMesh.vertices = v;
    }
}
 