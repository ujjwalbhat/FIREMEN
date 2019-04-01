using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandBag : MonoBehaviour
{
    public int dropCount = 5;
    int count = 0;
    public GameObject explodePrefab;
    public GameObject[] SandDropsObjects;
    bool sandExploded;
    GameObject _parent;

    void Start()
    {

        sandExploded = false;
        count = 0;
        _parent = new GameObject("_SandBalls");
       SandDropsObjects[0].transform.SetParent(_parent.transform);

  
    }

    // Update is called once per frame
    void Update()
    {

    }

    //explode sandBag gameobject if it collides with water
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Metaball_liquid"))
        {
            count++;
            if (count >= dropCount && !sandExploded)
            {
                GameObject exlode = (GameObject)Instantiate(explodePrefab, transform.position, Quaternion.identity);
                Destroy(exlode, 1f);
                gameObject.SetActive(false);
                sandExploded = true;
                SandSpawn();
            }
            col.gameObject.SetActive(false);
        }
    }

    //spawn sand particles 
    public void SandSpawn()
    {

        for (int i = 1; i < SandDropsObjects.Length; i++)
        {
            SandDropsObjects[i] = Instantiate(SandDropsObjects[0], gameObject.transform.position, new Quaternion(0, 2, 1, 0)) as GameObject;
            SandDropsObjects[i].transform.SetParent(_parent.transform);
            SandDropsObjects[i].SetActive(true);
        }  
    }
}
