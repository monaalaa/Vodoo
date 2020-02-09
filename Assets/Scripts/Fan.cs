using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public int Force;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Ball.Instance.AddForce(Force);
            gameObject.SetActive(false);
        }
    }
}
