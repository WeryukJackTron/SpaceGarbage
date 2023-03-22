using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public GameObject explosion;
    GameObject aux;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        aux = Instantiate(explosion, collision.gameObject.transform.position, new Quaternion(), this.gameObject.transform);
        StartCoroutine(DelayClear());
        Destroy(collision.gameObject);
    }

    public IEnumerator DelayClear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(aux);
    }
}
