using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulation : MonoBehaviour
{

    public Camera TheCamera = null;
    public float minFov = 1f;
    public float maxFov = 250f;
    public float sensitivity = 10f;

    public enum LookAtCompute
    {
        QuatLookRotation = 0,
        TransformLookAt = 1
    };

    public Transform LookAtPosition = null;
    public LookAtCompute ComputeMode = LookAtCompute.QuatLookRotation;

    Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        Debug.Assert(LookAtPosition != null);
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        switch (ComputeMode)
        {
            case LookAtCompute.QuatLookRotation:
                // Viewing vector is from transform.localPosition to the lookat position
                Vector3 V = LookAtPosition.localPosition - transform.localPosition;
                Vector3 W = Vector3.Cross(-V, transform.up);
                Vector3 U = Vector3.Cross(W, -V);
                transform.localRotation = Quaternion.LookRotation(V, U);
                break;

            case LookAtCompute.TransformLookAt:
                transform.LookAt(LookAtPosition);
                break;
        }

    }

    float RotateDelta = 100f / 60;  // about 10-degress per second
    float TranslationDelta = 100f / 60;

    public void tumbleUp(Vector3 mousePosition)
    {
        if (Vector3.Dot(transform.localPosition.normalized, Vector3.up) > 0.99)
        {
            if (mousePosition.y > Screen.height / 2) return;
        }
        else if (Vector3.Dot(transform.localPosition.normalized, Vector3.up) < -0.99)
        {
            if (mousePosition.y < Screen.height / 2) return;
        }

        RotateDelta = (20f / 60) * (2 * (mousePosition.y - Screen.height / 2) / Screen.height);

        // 1. Rotation of the viewing direction by right axis
        Quaternion q = Quaternion.AngleAxis(RotateDelta, transform.right);

        // 2. we need to rotate the camera position
        Matrix4x4 r = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
        Matrix4x4 invP = Matrix4x4.TRS(-LookAtPosition.localPosition, Quaternion.identity, Vector3.one);
        r = invP.inverse * r * invP;
        Vector3 newCameraPos = r.MultiplyPoint(transform.localPosition);
        transform.localPosition = newCameraPos;
        transform.LookAt(LookAtPosition);
    }

    public void tumbleRight(Vector3 mousePosition)
    {
        RotateDelta = (20f / 60) * (2 * -(mousePosition.x - Screen.width / 2) / Screen.width);

        // 1. Rotation of the viewing direction by right axis
        Quaternion q = Quaternion.AngleAxis(RotateDelta, transform.up);

        // 2. we need to rotate the camera position
        Matrix4x4 r = Matrix4x4.TRS(Vector3.zero, q, Vector3.one);
        Matrix4x4 invP = Matrix4x4.TRS(-LookAtPosition.localPosition, Quaternion.identity, Vector3.one);
        r = invP.inverse * r * invP;
        Vector3 newCameraPos = r.MultiplyPoint(transform.localPosition);
        transform.localPosition = newCameraPos;
        transform.LookAt(LookAtPosition);
    }

    public void trackUp(Vector3 mousePosition)
    {
        float maxPosition = originalPosition.y + 50;
        float minPosition = originalPosition.y - 50;
        if (transform.localPosition.y >= maxPosition)
            if (mousePosition.y > Screen.height / 2) return;
            else if (transform.localPosition.y <= minPosition)
                if (mousePosition.y < Screen.height / 2) return;

        TranslationDelta = (20f / 60) * (2 * (mousePosition.y - Screen.height / 2) / Screen.height);

        // 1. Rotation of the viewing direction by right axis
        Vector3 v = new Vector3(0, TranslationDelta, 0);

        // 2. we need to rotate the camera position
        Matrix4x4 r = Matrix4x4.TRS(v, Quaternion.identity, Vector3.one);
        Matrix4x4 invP = Matrix4x4.TRS(-LookAtPosition.localPosition, Quaternion.identity, Vector3.one);
        r = invP.inverse * r * invP;
        Vector3 newCameraPos = r.MultiplyPoint(transform.localPosition);

        if (newCameraPos.y >= maxPosition || newCameraPos.y <= minPosition) return;

        transform.localPosition = newCameraPos;

        LookAtPosition.localPosition += new Vector3(0, TranslationDelta, 0);
        transform.LookAt(LookAtPosition);

    }

    public void trackRight(Vector3 mousePosition)
    {
        float maxPosition = originalPosition.x + 50;
        float minPosition = originalPosition.x - 50;
        if (transform.localPosition.x >= maxPosition)
            if (mousePosition.y > Screen.height / 2) return;
            else if (transform.localPosition.x <= minPosition)
                if (mousePosition.y < Screen.height / 2) return;

        TranslationDelta = (20f / 60) * (2 * (mousePosition.x - Screen.width / 2) / Screen.width);

        // 1. Rotation of the viewing direction by right axis
        Vector3 v = new Vector3(TranslationDelta, 0, 0);

        // 2. we need to rotate the camera position
        Matrix4x4 r = Matrix4x4.TRS(v, Quaternion.identity, Vector3.one);
        Matrix4x4 invP = Matrix4x4.TRS(-LookAtPosition.localPosition, Quaternion.identity, Vector3.one);
        r = invP.inverse * r * invP;
        Vector3 newCameraPos = r.MultiplyPoint(transform.localPosition);

        if (newCameraPos.x >= maxPosition || newCameraPos.x <= minPosition) return;

        transform.localPosition = newCameraPos;

        LookAtPosition.localPosition += new Vector3(TranslationDelta, 0, 0);
        transform.LookAt(LookAtPosition);
    }

    public void Dolly(float scrolledAmount)
    {

        float fov = TheCamera.fieldOfView;
        fov -= scrolledAmount * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        TheCamera.fieldOfView = fov;
    }

}
