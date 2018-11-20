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

            Matrix3x3 trs = Matrix3x3Helpers.CreateTRS(Offset, Rotation, Scale);
            Vector3 InitUV = new Vector3(mInitUV[i].x, mInitUV[i].y, 1);
            Vector3 newUV = trs * InitUV;
            uv[i].x = newUV.x;
            uv[i].y = newUV.y;

        }
        theMesh.uv = uv;
    }

    Vector2 Rotate(Vector2 init, float rot)
    {
        float cos = Mathf.Cos(rot * Mathf.Deg2Rad);
        float sin = Mathf.Sin(rot * Mathf.Deg2Rad);
        return new Vector2( init.x * cos - init.y * sin, init.x * sin + init.y * cos);
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
