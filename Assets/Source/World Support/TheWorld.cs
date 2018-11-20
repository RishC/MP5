using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour {

    public MyMesh TheMesh = null;

    GameObject selectedAxisFrame = null;
    AxisFrame selectedAxisFrameScript = null;
    VertexController selectedVertex = null;
    char selectedAxis = 'n';

    enum ObjectType
    {
        Mesh = 0,
        Cylinder = 1
    }
    ObjectType currentObject = ObjectType.Mesh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ShowMeshObject(int[] values)
    {
        currentObject = ObjectType.Mesh;
        SetMeshParameters(values[0], values[1]);
    }

    public void ShowCylinderObject(int[] values)
    {
        currentObject = ObjectType.Cylinder;
        SetCylinderParameters(values[0], values[1], values[2]);
    }

    public void SetMeshParameters(int m, int n)
    {
        if (currentObject == ObjectType.Mesh)
        {
            TheMesh.modifyResolution(m, n);
        }
    }

    public void SetCylinderParameters(int m, int n, int rotation)
    {
        if (currentObject == ObjectType.Cylinder)
        {
            //not yet implemented
        }
    }

    public void SelectVertex( VertexController v){
        if (selectedVertex != null) selectedVertex.Unselect();
        RemoveAxisFrameFromSelected();
        selectedVertex = v;
        selectedVertex.Select();
        AddAxisFrameToSelected();
    }

    public void AddAxisFrameToSelected(){
        selectedAxisFrame = Instantiate(Resources.Load("AxisFrame")) as GameObject;
        selectedAxisFrame.transform.localPosition = selectedVertex.transform.localPosition;
        selectedAxisFrame.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        selectedAxisFrameScript = selectedAxisFrame.GetComponent<AxisFrame>();
        SetSelectedAxis('n');
    }

    public void RemoveAxisFrameFromSelected(){
        Destroy(selectedAxisFrame);
        selectedAxisFrame = null;
        selectedAxisFrameScript = null;
    }

    public void SetSelectedAxis(char c){
        selectedAxis = c;
        if(selectedAxisFrameScript) selectedAxisFrameScript.SelectAxis(c);
    }

    public char GetSelectedAxis(){
        return selectedAxis;
    }

    public void MoveAxisFrame(float amount)
    {
        if (selectedAxisFrameScript == null) return;
        selectedAxisFrameScript.TranslateTo(amount, selectedAxis);
        selectedVertex.transform.localPosition = selectedAxisFrameScript.GetTranslation();
    }
}
