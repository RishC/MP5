using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePlacement : MonoBehaviour
{
    Vector2 Offset = Vector2.zero;
    Vector2 Scale = new Vector2(0.5f, 0.5f);
    float Rotation = 0f;
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
            //scale
            uv[i].x = mInitUV[i].x * Scale.x;
            uv[i].y = mInitUV[i].y * Scale.y;

            //rotation
            uv[i] = Rotate(uv[i], Rotation);

            //translation
            uv[i] = Offset + uv[i];

        }
        theMesh.uv = uv;
    }

    Vector2 Rotate(Vector2 init, float rot)
    {
        float c = Mathf.Cos(rot * Mathf.Deg2Rad);
        float s = Mathf.Sin(rot * Mathf.Deg2Rad);
        return new Vector2( init.x * c - init.y * s, init.x * s + init.y * c);
    }

    public void setTranslation(Vector3 nt){
        Offset = new Vector2(nt.x, nt.y);
    }

    public void setScale(Vector3 ns){
        Scale = new Vector2(ns.x, ns.y);
    }

    public void setRotation(float nr){
        Rotation = nr;
    }

    public Vector2 getTranslation()
    {
        return Offset;
    }

    public Vector2 getScale()
    {
        return Scale;
    }

    public float getRotation(){
        return Rotation;
    }
}
