using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cones : MonoBehaviour
{
    public GameObject Next;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "End")
            Destroy(gameObject)
;    }
}
