using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedWorld : MonoBehaviour
{
    public float Speed;
  
    private void FixedUpdate()
    {
        if(GameManager.Instance.GameStarted)
        transform.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
    }
}
