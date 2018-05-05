using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateModel : MonoBehaviour {


    public float dragSpeed = 2;
    private Vector3 move;
    private Vector3 dragOrigin;

    bool isDragging;
  
	
	void Update ()
    {
        

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);



            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                    isDragging = true;
                else
                    isDragging = false;
            }

            dragOrigin = Input.mousePosition;

            return;
        }

        if (Input.GetMouseButtonUp(0))
            isDragging = false;

        if (isDragging && Input.GetMouseButton(0) && dragOrigin != Input.mousePosition)
        {

            if (Vector3.Distance(dragOrigin, Input.mousePosition) > 5)
            {

                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
                move = Vector3.Lerp(move, new Vector3(0, pos.x * dragSpeed, 0) * -3, Time.deltaTime * 5);


                dragOrigin = Input.mousePosition;


            }
        }
        else
        {
            move = Vector3.Lerp(move, new Vector3(0, 0, 0), Time.deltaTime * 5);
        }

        transform.Rotate(move, Space.Self);

    }



}
