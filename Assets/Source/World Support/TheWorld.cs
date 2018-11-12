using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour {

    enum ObjectType
    {
        Mesh = 0,
        Cylinder = 1
    }
    ObjectType currentObject = ObjectType.Mesh;
    int ResolutionN;
    int ResolutionM;
    int Rotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(ResolutionN);
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

    public void SetMeshParameters(int n, int m)
    {
        if (currentObject == ObjectType.Mesh)
        {
            ResolutionN = n;
            ResolutionM = m;
        }
    }

    public void SetCylinderParameters(int n, int m, int rotation)
    {
        if (currentObject == ObjectType.Cylinder)
        {
            ResolutionN = n;
            ResolutionM = m;
            Rotation = rotation;
        }
    }
}
