using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MyMesh : MonoBehaviour
{

    float width = 2f; //width of mesh
    float height = 2f; //height of mesh

    int M = 5; //resolution for rows
    int N = 5; // rsolution for columns

    bool flag = true;

    public bool manipulationIsOff = true;

    // Use this for initialization
    void Start () {
        M--; N--;
        updateMesh();
    }

    void Update()
    {
        if (mControllers == null || manipulationIsOff == true) return;
         Mesh theMesh = GetComponent<MeshFilter>().mesh;
         Vector3[] v = theMesh.vertices;
        Vector3[] n = theMesh.normals;
         for (int i = 0; i < mControllers.Length; i++)         {
            v[i] = mControllers[i].transform.localPosition;         }

        ComputeNormals(v, n);          theMesh.vertices = v;
        theMesh.normals = n;
    }

    void updateMesh() {

        Mesh theMesh = GetComponent<MeshFilter>().mesh;   // get the mesh component
        theMesh.Clear();    // delete whatever is there!!

        int vertNum = (M + 1) * (N + 1);
        int triangNum = (2 * M * N * 3);

        Vector3[] v = new Vector3[vertNum];   // 2x2 mesh needs 3x3 vertices
        int[] t = new int[triangNum];         // Number of triangles: 2x2 mesh and 2x triangles on each mesh-unit
        Vector3[] n = new Vector3[vertNum];   // MUST be the same as number of vertices
        Vector2[] uv = new Vector2[vertNum];

        float deltaM = height / M;
        float deltaN = width / N;

        //setting v
        int z = 0;
        for (int i = 0; i < (M + 1); i++)
        {
            for (int j = 0; j < (N + 1); j++)
            {
                v[z] = new Vector3(j * deltaN - 1, 0, i * deltaM - 1);
                z++;
            }
        }

        ////setting uv
        z = 0;
        for (int i = 0; i < (M + 1); i++)
        {
            for (int j = 0; j < (N + 1); j++)
            {
                uv[z] = new Vector2(j * deltaN, i * deltaM);
                z++;
            }
        }

        //setting n
        for (int i = 0; i < vertNum; i++)
        {
            n[i] = new Vector3(0, 1, 0);
        }

        //setting t
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
        theMesh.uv = uv;

        if (manipulationIsOff == false){
            InitControllers(v);
            InitNormals(v, n);
        }

        GetComponent<TexturePlacement>().SaveInitUV(uv);
    }

    public void modifyResolution(int m, int n){
        if (m >= 2) M = m - 1;
        if (n >= 2)  N = n - 1;
        updateMesh();
    }
}
 