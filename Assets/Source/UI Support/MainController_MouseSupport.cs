using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public partial class MainController : MonoBehaviour
{

    void OnGUI()
    {

        if (Event.current.alt){
            if (MainWorld.TheMesh.manipulationIsOff == false){
                MainWorld.TheMesh.ClearControllers();
                MainWorld.RemoveAxisFrameFromSelected();
                MainWorld.SetSelectedAxis('n');
            } 
            if (Input.GetMouseButton(1)) // Mouse Drag Right
            {
                MCM.trackUp(Input.mousePosition);
                MCM.trackRight(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0)) // Mouse Drag Left
            {
                MCM.tumbleUp(Input.mousePosition);
                MCM.tumbleRight(Input.mousePosition);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") != 0f) // Mouse scroll
            {
                MCM.Dolly(Input.GetAxis("Mouse ScrollWheel"));
            }
        }
        else if (Input.GetKey(KeyCode.LeftControl)) {
            if (MainWorld.CheckSelectedObjectManipulation() == true) MainWorld.ShowControllers();

            //watch for selection with LBM
            if (Input.GetMouseButtonDown(0)) // Mouse Left Down
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    if (hitInfo.transform.gameObject.name == "Sphere"){
                        VertexController VC = hitInfo.transform.gameObject.GetComponent<VertexController>();
                        if (!VC) return; //hit point isn't a vertex

                        MainWorld.SelectVertex(VC);
                    }
                    else if (hitInfo.transform.gameObject.name == "X") MainWorld.SetSelectedAxis('x');
                    else if (hitInfo.transform.gameObject.name == "Y") MainWorld.SetSelectedAxis('y');
                    else if (hitInfo.transform.gameObject.name == "Z") MainWorld.SetSelectedAxis('z');
                }
                else
                {
                    Debug.Log("No hit");
                }
            }
            else {
                float scrolledAmount = -Input.GetAxis("Mouse ScrollWheel");
                MainWorld.MoveAxisFrame(scrolledAmount);
            }
        } else {
            if (MainWorld.CheckSelectedObjectManipulation() == false){
                MainWorld.ClearControllers();
                MainWorld.RemoveAxisFrameFromSelected();
                MainWorld.SetSelectedAxis('n');
            } 
        }
    }

    bool MouseSelectObjectAt(out Vector3 p, int layerMask)
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, layerMask);
        if (hit)
        {
            p = hitInfo.point;
        }
        else
        {
            p = Vector3.zero;
        }
        return hit;
    }

}
