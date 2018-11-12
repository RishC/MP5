using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour {
    public SliderWithEcho N, M;
	// Use this for initialization
	void Start () {
        N.InitSliderRange(2, 20, 2, "0");
        M.InitSliderRange(2, 20, 2, "0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
