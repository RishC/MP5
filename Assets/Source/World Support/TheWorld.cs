using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour {

    public MyMesh TheMesh = null;

    VertexController selectedVertex = null;

    enum ObjectType
    {
        Mesh = 0,
        Cylinder = 1
    }
    ObjectType currentObject = ObjectType.Mesh;
    int ResolutionM;
    int ResolutionN;
    int Rotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ShowMeshObject(int[] values)
    {
        currentObject = ObjectType.Mesh;
        SetMeshParameters(values[0], values[1]);
    }

    public void ShowCylinderObject(int[] values)
    {
        currentObject = ObjectType.Cylinder;
        SetCylinderParameters(values[0], values[1], values[2]);
    }

    public void SetMeshParameters(int m, int n)
    {
        if (currentObject == ObjectType.Mesh)
        {
            ResolutionM = m;
            ResolutionN = n;
            TheMesh.modifyResolution(m, n);
        }
    }

    public void SetCylinderParameters(int m, int n, int rotation)
    {
        if (currentObject == ObjectType.Cylinder)
        {
            ResolutionM = m;
            ResolutionN = n;
            Rotation = rotation;
        }
    }

    public void SelectVertex( VertexController v){
        if (selectedVertex != null) selectedVertex.Unselect();
        selectedVertex = v;
        selectedVertex.Select();
    }
}
