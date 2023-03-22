using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset, oldPos = Vector3.zero, velocity;
 

 
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                oldPos = selectedObject.transform.position;
                selectedObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            velocity = selectedObject.transform.position - oldPos;
            selectedObject.GetComponent<Rigidbody2D>().velocity = velocity;
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

    private void FixedUpdate()
    {
        
    }
}
