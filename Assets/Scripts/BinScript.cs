using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<WasteScript>().type == this.gameObject.GetComponent<WasteScript>().type)
        {
            Destroy(collision.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        StartCoroutine(DelayColor());
    }
    public IEnumerator DelayColor()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
