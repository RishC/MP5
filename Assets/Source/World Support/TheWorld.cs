using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour {
    GameObject currentObject;
    int ResolutionN;
    int ResolutionM;
    int Rotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ShowMeshObject()
    {

    }

    public void ShowCylinderObject()
    {

    }

    public void SetMeshParameters(int n, int m)
    {
        ResolutionN = n;
        ResolutionM = m;
    }

    public void SetCylinderParameters(int n, int m, int rotation)
    {
        ResolutionN = n;
        ResolutionM = m;
        Rotation = rotation;
    }
}
