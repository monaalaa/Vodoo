using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            UIManager.Instance.PlayerGetDiamond();
            Vector3 pos= new Vector3(transform.position.x,transform.position.y + 0.8f, transform.position.z);
            VFX.Instance.CreateVFX(Quaternion.identity, pos, VFXNames.Diamond);
        }
    }
}
