using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePlacement : MonoBehaviour
{
    Vector2 Offset = Vector2.zero;
    Vector2 Scale = new Vector2(0.5f, 0.5f);
    Vector2[] mInitUV = null; // initial values

    public void SaveInitUV(Vector2[] uv)
    {
        mInitUV = new Vector2[uv.Length];
        for (int i = 0; i < uv.Length; i++)
            mInitUV[i] = uv[i];
    }

    // Update is called once per frame
    void Update()
    {
        Mesh theMesh = GetComponent<MeshFilter>().mesh;
        Vector2[] uv = theMesh.uv;
        for (int i = 0; i < uv.Length; i++)
        {
            uv[i].x = mInitUV[i].x * Scale.x;
            uv[i].y = mInitUV[i].y * Scale.y;
            uv[i] = Offset + uv[i];
        }
        theMesh.uv = uv;
    }

    public void setTranslation(Vector3 nt){
        Offset = new Vector2(nt.x, nt.y);
    }

    public void setScale(Vector3 ns){
        Scale = new Vector2(ns.x, ns.y);
    }

    public Vector2 getTranslation()
    {
        return Offset;
    }

    public Vector2 getScale()
    {
        return Scale;
    }
}
