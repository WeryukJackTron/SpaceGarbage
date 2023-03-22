using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset, oldPos = Vector3.zero, velocity;
	Collider2D targetObject;
 

 
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !selectedObject)
        {
            targetObject = Physics2D.OverlapPoint(mousePosition);
			print(targetObject == null);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
				selectedObject.transform.SetAsLastSibling();
				targetObject.enabled = false;
                oldPos = selectedObject.transform.position;
                //selectedObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            velocity = selectedObject.transform.position - oldPos;
            selectedObject.GetComponent<Rigidbody2D>().velocity = velocity*2;
			targetObject.enabled = true;
            selectedObject = null;
            print(velocity);
        }
        else if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
            StartCoroutine(DelayVelocity());
        }

        //oldPos = newPos;
    }

    public IEnumerator DelayVelocity()
    {
        yield return new WaitForSeconds(.5f);
        if (selectedObject)
        {
            oldPos = selectedObject.transform.position;
        }
    }
}
