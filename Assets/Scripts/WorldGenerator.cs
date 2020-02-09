using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public List<GameObject> Items;
    public Transform Parent;

    public Transform LastElement;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            InstantiateItem();
        }   
    }

    private void Start()
    {
        GameManager.AGameStarted += StartGeneration;
    }
    void StartGeneration()
    {
        StartCoroutine(IGenerate());
    }
   
    void InstantiateItem()
    {
        GameObject temp = GameObject.Instantiate(ItemToGenerate());
        LastElement.GetComponent<Cones>().Next = temp;

        temp.transform.parent = Parent;
        temp.transform.position = new Vector3(temp.transform.position.x, LastElement.position.y, LastElement.position.z + 7f);
        LastElement = temp.transform;
    }

    IEnumerator IGenerate()
    {
        yield return new WaitForSeconds(1.5f);
        InstantiateItem();
        StartCoroutine(IGenerate());
    }

    GameObject ItemToGenerate()
    {
        return (Items[Random.Range(0, Items.Count)]);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        GameManager.AGameStarted -= StartGeneration;
    }

}
