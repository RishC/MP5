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
            if (MainWorld.TheMesh.manipulationIsOff == false) MainWorld.TheMesh.ClearControllers();
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
            if (MainWorld.TheMesh.manipulationIsOff == true) MainWorld.TheMesh.InitControllers();

            //watch for selection with LBM
            if (Input.GetMouseButtonDown(0)) // Mouse Left Down
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    VertexController VC = hitInfo.transform.gameObject.GetComponent<VertexController>();
                    if (!VC) return; //hit point isn't a vertex

                    MainWorld.SelectVertex(VC);
                }
                else
                {
                    Debug.Log("No hit");
                }
            }
        }
        else {
            if (MainWorld.TheMesh.manipulationIsOff == false) MainWorld.TheMesh.ClearControllers();
        }
    }

}
