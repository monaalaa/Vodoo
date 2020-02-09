using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticle : MonoBehaviour
{
    public float Speed;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hall")
        {
            Destroy(gameObject);
        }
    }
}
