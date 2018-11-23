using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class MainController : MonoBehaviour {

    public TheWorld MainWorld = null;
    public Camera MainCamera = null;
    public XfromControl TextureControl = null;
    public MeshController MeshControl = null;
    public CylinderController CylinderControl = null;
    public Dropdown ObjectDropdown = null;
    public CameraManipulation MCM = null; //MainCameraManipulation

    // Use this for initialization
    void Start () {
        InitGame();
        InitObjectDropdown();
        TextureControl.SetSelectedObject(MainWorld.TheMesh.texturePlacement);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitGame()
    {
        MainWorld.SetMeshParameters(5, 5);
        ShowMesh();
    }

}
