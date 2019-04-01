using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;
public class WaterSwitch : MonoBehaviour
{
    public GameObject button;
    public Water2D_Spawner waterSpawner;
    int dropHitCount;
    public int maxCount = 5;
    bool buttonOn = false;

    // Start is called before the first frame update
    void Start()
    {
        buttonOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //enable water spray if water hit the water switch.
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Metaball_liquid"))
        {
            dropHitCount++;
            if (dropHitCount > maxCount && !buttonOn)
            {
                button.SetActive(false);
                waterSpawner.Dynamic = true;
                waterSpawner.Spawn();
                buttonOn = true;
                StartCoroutine("DisableWaterSpawnerAfterSeconds", 3f);
            }
        }
    }

    IEnumerator DisableWaterSpawnerAfterSeconds(float t)
    {
        yield return new WaitForSeconds(t);
        waterSpawner.Dynamic = false;
    }
}
