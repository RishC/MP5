using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour {
    public SliderWithEcho N, M, Rotation;
    public MainController MainController;
    // Use this for initialization
    void Start () {
        N.SetSliderListener(ValueChanged);
        M.SetSliderListener(ValueChanged);
        Rotation.SetSliderListener(ValueChanged);
        N.InitSliderRange(2, 20, 2, "0");
        M.InitSliderRange(2, 20, 2, "0");
        Rotation.InitSliderRange(10, 360, 275, "0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ValueChanged(float v)
    {
        MainController.UpdateCylinderParameters((int)N.GetSliderValue(), (int)M.GetSliderValue(), (int)Rotation.GetSliderValue());
    }
}
