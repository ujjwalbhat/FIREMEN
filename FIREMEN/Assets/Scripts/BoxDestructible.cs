using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestructible : MonoBehaviour
{
    public int dropCount = 5;
    int count = 0;
    public GameObject explodePrefab;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Disable box when water hit the box gameobject
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Metaball_liquid"))
        {
            count++;
            if (count >= dropCount)
            {
                GameObject exlode = (GameObject)Instantiate(explodePrefab, transform.position, Quaternion.identity);
                Destroy(exlode, 1f);
                gameObject.SetActive(false);
            }
            col.gameObject.SetActive(false);
        }

    }
}
