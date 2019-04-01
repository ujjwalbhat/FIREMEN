using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour
{

    public GameObject fire;
    float waterDrops = 0f;
    float rateOverTime;
    public float dropCount=25f;
    public static bool isFlameBurning = true;

    Collider2D collider;
    void Start()
    {
        waterDrops = 0f;
        rateOverTime = 1;
        isFlameBurning = true;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //reducing the scale of fire  
        Vector3 localScale = fire.transform.localScale;
        localScale.x = rateOverTime;
        localScale.y = rateOverTime;
        localScale.z = rateOverTime;
        fire.transform.localScale = localScale;
    }

    //Extinguish fire on collision with the water
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Metaball_liquid"))
        {
            waterDrops++;
            rateOverTime = 1 - (waterDrops/dropCount);
           // print(waterDrops);
            if (rateOverTime <= 0)
            {
                rateOverTime = 0f;
                isFlameBurning = false;
                collider.enabled = false;
            }

            col.gameObject.SetActive(false);    
        }

    }
}
