using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject obsticle;
    [SerializeField]
    float Range;
    private void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(0.5f);
        float random = Random.Range(Range, -Range);
        Instantiate(obsticle, new Vector3(random, transform.position.y, transform.position.z),Quaternion.identity);
    }
}
