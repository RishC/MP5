using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour {
    public SliderWithEcho N, M;
    public MainController MainController;
	// Use this for initialization
	void Start () {
        N.SetSliderListener(ValueChanged);
        M.SetSliderListener(ValueChanged);
        N.InitSliderRange(2, 20, 2, "0");
        M.InitSliderRange(2, 20, 2, "0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ValueChanged(float v)
    {
        MainController.UpdateMeshParameters((int)N.GetSliderValue(), (int)M.GetSliderValue());
    }
}
