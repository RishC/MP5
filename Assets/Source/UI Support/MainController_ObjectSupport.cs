using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainController : MonoBehaviour {

    void ShowMesh()
    {
        MeshControl.gameObject.SetActive(true);
        CylinderControl.gameObject.SetActive(false);
        MainWorld.ShowMeshObject();
    }

    void ShowCylinder()
    {
        MeshControl.gameObject.SetActive(false);
        CylinderControl.gameObject.SetActive(true);
        MainWorld.ShowCylinderObject();
    }

    void InitObjectDropdown()
    {
        ObjectDropdown.onValueChanged.AddListener(ObjectChange);
    }

    void ObjectChange(int value)
    {
        if (value == 0)
        {
            ShowMesh();
        }
        if (value == 1)
        {
            ShowCylinder();
        }
    }

    public void UpdateMeshParameters(int n, int m)
    {
        MainWorld.SetMeshParameters(n, m);
    }

    public void UpdateCylinderParameters(int n, int m, int rotation)
    {
        MainWorld.SetCylinderParameters(n, m, rotation);
    }
}
