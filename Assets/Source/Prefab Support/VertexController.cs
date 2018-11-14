using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexController : MonoBehaviour {

    bool isSelected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeColorTo(Color c){
        gameObject.GetComponent<Renderer>().material.color = c;
    }

    public void Select()
    {
        isSelected = true;
        ChangeColorTo(Color.black);
    }

    public void Unselect()
    {
        isSelected = false;
        ChangeColorTo(Color.white);
    }
}
