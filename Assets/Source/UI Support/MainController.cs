using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    public TheWorld MainWorld = null;
    public Camera MainCamera = null;
    public XfromControl XFormControl = null;
    public MeshController MeshControl = null;
    public CylinderController CylinderControl = null;
    public Dropdown ObjectDropdown = null;

	// Use this for initialization
	void Start () {
        ShowMesh();
        InitObjectDropdown();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

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
}
