using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    public Transform ImpactPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        Vector2 dir = -rb.velocity.normalized;
        Vector3 pos = rb.position;
        Destroy(rb.gameObject);

        float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x);
        Instantiate(ImpactPrefab, pos, Quaternion.Euler(0.0f, 0.0f, angle));
    }
}
