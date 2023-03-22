using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ForceApplier : MonoBehaviour
{
    public Transform Center;
    public float StrongForce = 2.0f;
    public float WeakForce = 1.0f;

    private List<Rigidbody2D> mInStrongField = new List<Rigidbody2D>();
    private List<Rigidbody2D> mInWeakField = new List<Rigidbody2D>();

    void FixedUpdate()
    {
        Vector2 pos = Center.position;
        foreach (Rigidbody2D rb in mInWeakField)
        {
            Vector2 dir = (pos - rb.position).normalized;
            rb.AddForce(dir * WeakForce);
        }

        foreach(Rigidbody2D rb in mInStrongField)
        {
            Vector2 dir = (pos - rb.position).normalized;
            rb.AddForce(dir *  StrongForce);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (mInWeakField.Contains(rb))
        {
            mInStrongField.Add(rb);
            mInWeakField.Remove(rb);
        }
        else
            mInWeakField.Add(rb);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (mInStrongField.Contains(rb))
        {
            mInStrongField.Remove(rb);
            mInWeakField.Add(rb);
        }
        else
            mInWeakField.Remove(rb);
    }

}
