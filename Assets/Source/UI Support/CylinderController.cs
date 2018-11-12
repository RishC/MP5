using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour {
    public SliderWithEcho N, M, Rotation;
	// Use this for initialization
	void Start () {
        N.InitSliderRange(2, 20, 2, "0");
        M.InitSliderRange(2, 20, 2, "0");
        Rotation.InitSliderRange(10, 360, 275, "0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
