using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public GameObject button;
    public GameObject[] pole;
    int dropHitCount;
    public  int maxCount = 5;
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

    //open pole when water collides with switch  button
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Metaball_liquid"))
        {
            dropHitCount++;
            var index = (dropHitCount / maxCount) - 1;
            if (index >= 0 && !buttonOn)
            {
                pole[index].SetActive(false);
            }
            if (dropHitCount >= maxCount * pole.Length)
            {
                buttonOn = true;
                button.SetActive(false);
            }
        }

    }
}
