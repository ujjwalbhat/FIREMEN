using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class gas : MonoBehaviour
{
    public GameObject explodePrefab;
    public GameObject[] fires;
    public static bool gasCanExploded;
    GameManager gameManager;
    public int dropCount = 5;
    int count = 0;
    void Start()
    {
        gasCanExploded = false;
        count = 0;
        foreach (GameObject g in fires)
        {
            g.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    //enable fire gameobjects if gas collides with fire
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fire"))
        {
                GameObject exlode = (GameObject)Instantiate(explodePrefab, transform.position, Quaternion.identity);
                Destroy(exlode, 1f);
                gasCanExploded = true;
                Water2D_Spawner.instance.Dynamic = false;
                foreach (GameObject g in fires)
                {
                    g.SetActive(true);
                }
                gameManager.StartResettingGame();
                gameObject.SetActive(false);
        }

    }
}
