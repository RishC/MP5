using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour {

    public SliderWithEcho M, N;
    public MainController MainController;
	// Use this for initialization
	void Start () {
        M.SetSliderListener(MValueChanged);
        N.SetSliderListener(NValueChanged);

        M.InitSliderRange(2, 20, 5, "0");
        N.InitSliderRange(2, 20, 5, "0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MValueChanged(float v)
    {
        MainController.UpdateMeshParameters( (int)v, -1);
    }

    void NValueChanged(float v)
    {
        MainController.UpdateMeshParameters(-1, (int)v);
    }

    public int[] GetValues()
    {
        return new int[2] { (int)N.GetSliderValue(), (int)M.GetSliderValue()};
    }
}
