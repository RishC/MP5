using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisFrame : MonoBehaviour {

    public GameObject X = null, Y = null, Z = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectAxis(char c){
        UnselectAllAxis();
        switch (c){
            case 'x':
                X.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 'y':
                Y.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 'z':
                Z.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            default:
                break;
        }
    }

    void UnselectAllAxis(){
        X.GetComponent<Renderer>().material.color = Color.red;
        Y.GetComponent<Renderer>().material.color = Color.green;
        Z.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void TranslateTo(float t, char dir){
        Vector3 newPosition = transform.localPosition;
        switch (dir)
        {
            case 'x':
                newPosition.x += t;
                break;
            case 'y':
                newPosition.y += t;
                break;
            case 'z':
                newPosition.z += t;
                break;
            default:
                break;
        }
        transform.localPosition = newPosition;
    }

    public Vector3 GetTranslation(){
        return transform.localPosition;
    }
}
