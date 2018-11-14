using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainController : MonoBehaviour {

    void ShowMesh()
    {
        MeshControl.gameObject.SetActive(true);
        CylinderControl.gameObject.SetActive(false);
        MainWorld.ShowMeshObject(MeshControl.GetValues());
    }

    void ShowCylinder()
    {
        MeshControl.gameObject.SetActive(false);
        CylinderControl.gameObject.SetActive(true);
        MainWorld.ShowCylinderObject(CylinderControl.GetValues());
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

    public void UpdateMeshParameters(int m, int n)
    {
        MainWorld.SetMeshParameters(m, n);
    }

    public void UpdateCylinderParameters(int m, int n, int rotation)
    {
        MainWorld.SetCylinderParameters(m, n, rotation);
    }
}
