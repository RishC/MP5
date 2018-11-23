using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MyCylinder : MonoBehaviour {

    LineSegment[] mNormals;

    void InitNormals(Vector3[] v, Vector3[] n)
    {
        mNormals = new LineSegment[v.Length];
        for (int i = 0; i < v.Length; i++)
        {
            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            mNormals[i] = o.AddComponent<LineSegment>();
            mNormals[i].SetWidth(0.005f);
            mNormals[i].transform.SetParent(this.transform);
            mNormals[i].gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        UpdateNormals(v, n);
    }

    void UpdateNormals(Vector3[] v, Vector3[] n)
    {
        for (int i = 0; i < v.Length; i++)
        {
            mNormals[i].SetEndPoints(v[i], v[i] + 1.0f * n[i]);
        }
    }

    Vector3 FaceNormal(Vector3[] v, int i0, int i1, int i2)
    {
        Vector3 a = v[i1] - v[i0];
        Vector3 b = v[i2] - v[i0];
        return Vector3.Cross(a, b).normalized;
    }

    void ComputeNormals(Vector3[] v, Vector3[] n)
    {
        int num = (2 * (M-1) * (N-1));
        Vector3[] triNormal = new Vector3[num];

        for (int i = 0; i < n.Length; i++) n[i] = new Vector3(0, 0, 0);

        //setting triNormal
        int z = 0;
        int b = 0; //base value
        for (int i = 0; i < (N-1); i++)
        {
            for (int j = 0; j < (M-1); j++)
            {

                triNormal[z] = FaceNormal(v, b + M, b + M + 1, b);
                triNormal[z + 1] = FaceNormal(v, b, b + M + 1, b + 1);

                n[b] += triNormal[z];
                n[b + M] += triNormal[z];
                n[b + M + 1] += triNormal[z];

                n[b] += triNormal[z + 1];
                n[b + 1] += triNormal[z + 1];
                n[b + M + 1] += triNormal[z + 1];


                z += 2;
                b++;
            }
            b++;
        }

        if (Rotation == 360f)
        {
            for (int i = 0; i < (M); i++)
            {
                Vector3 first = n[i];
                Vector3 last = n[(N - 1) * M + i];
                Vector3 avg = first + last;
                n[i] = avg.normalized;
                n[(N - 1) * M + i] = avg.normalized;
            }
        }

        for (int i = 0; i < n.Length; i++) n[i] = -n[i].normalized;

        UpdateNormals(v, n);
    }

    void ClearNormals()
    {
        if (mNormals != null)
        {
            foreach (LineSegment n in mNormals) Destroy(n.gameObject);
            mNormals = null;
            manipulationIsOff = true;
        }
    }
}
