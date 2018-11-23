using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MyCylinder : MonoBehaviour
{

    float length = 2f; //width of mesh
    float width = 2f; //height of mesh
    int N = 4;
    int M = 4;
    float Rotation = 360f;
    float radius = 1f;

    public bool manipulationIsOff = true;

    void Start()
    {
        UpdateMesh();
    }

    void Update()
    {
        if (mControllers == null || manipulationIsOff == true) return;

        Mesh theMesh = GetComponent<MeshFilter>().mesh;

        Vector3[] v = theMesh.vertices;
        Vector3[] n = theMesh.normals;

        for (int i = 0; i < mControllers.Length; i++)
        {
            v[i] = mControllers[i].transform.localPosition;
        }

        ComputeNormals(v, n);

        theMesh.vertices = v;
        //theMesh.normals = n; // fixes illumination gap
    }

    void UpdateMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        int vertNum = (M * N);
        int triangNum = (2 * (M - 1) * (N - 1) * 3);

        Vector3[] v = new Vector3[vertNum];   // 2x2 mesh needs 3x3 vertices
        int[] t = new int[triangNum];         // Number of triangles: 2x2 mesh and 2x triangles on each mesh-unit
        Vector3[] n = new Vector3[vertNum];   // MUST be the same as number of vertices

        float deltaRotation = Rotation / (N - 1) * Mathf.Deg2Rad;

        float deltaHeight = length / (M - 1);

        //setting v
        int index = 0;
        float r = 0;
        while (index < vertNum)
        {
            float cos = Mathf.Cos(r);
            float sin = Mathf.Sin(r);
            float yValue = 0;
            int yIndex = 0;
            while (yIndex < M)
            {
                n[index] = (new Vector3(cos, 0f, sin));
                v[index++] = new Vector3(radius * cos, yValue, radius * sin);

                yIndex++;
                yValue += deltaHeight;
            }
            r += deltaRotation;
        }

        ////setting n
        //for (int i = 0; i < vertNum; i++)
        //{
        //    n[i] = new Vector3(0, 1, 0);
        //}

        //setting t
        int z = 0;
        int b = 0; //base value
        for (int i = 0; i < (N - 1); i++)
        {
            for (int j = 0; j < (M - 1); j++)
            {

                //bottom triangle
                t[z] = b;
                t[z + 1] = b + M;
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


        mesh.vertices = v;
        mesh.triangles = t;
        mesh.normals = n;

        if (manipulationIsOff == false)
        {
            InitControllers(v);
            InitNormals(v, n);
        }
    }

    public void modifyCylinder(int m, int n, int rotation)
    {
        M = m;
        N = n;
        Rotation = rotation;
        UpdateMesh();
    }
}
