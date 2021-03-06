﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MyMesh : MonoBehaviour 
{

    GameObject[] mControllers;
    GameObject[] mNormal;

    public void InitControllers(Vector3[] v)
    {
        ClearControllers();

        mControllers = new GameObject[v.Length];
        //mNormal = new GameObject[v.Length];
        for (int i = 0; i < v.Length; i++)
        {
            //sphere creation
            mControllers[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            mControllers[i].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            mControllers[i].AddComponent<VertexController>();

            mControllers[i].transform.localPosition = v[i];
            mControllers[i].transform.parent = this.transform;
        }
        manipulationIsOff = false;
    }

    public void ClearControllers()
    {
        if (mControllers != null){
            foreach (GameObject g in mControllers) Destroy(g);
            manipulationIsOff = true;
        }
        ClearNormals();
    }

    public void ShowControllers(){
        Mesh theMesh = GetComponent<MeshFilter>().mesh;
        Vector3[] v = theMesh.vertices;
        Vector3[] n = theMesh.normals;
        InitControllers(v);
        InitNormals(v,n);
    }
}