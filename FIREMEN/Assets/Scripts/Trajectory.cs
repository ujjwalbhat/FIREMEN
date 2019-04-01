using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class Trajectory : MonoBehaviour
{
    private Vector2 LAUNCH_VELOCITY;
    private  Vector2 INITIAL_POSITION = Vector2.zero;
    private  Vector2 GRAVITY = new Vector2(0f, -9.8f);
    private const float DELAY_UNTIL_LAUNCH = 1f;
    public int NUM_DOTS_TO_SHOW = 13;
    private float DOT_TIME_STEP = 0.05f;

    private bool launched = false;
    private float timeUntilLaunch = DELAY_UNTIL_LAUNCH;
    private Rigidbody2D rigidBody;

    public GameObject gun;
    public GameObject[] tDot; 
    public GameObject hose;
    public Water2D_Spawner waterSpawner;
    public GameObject trajectoryDotsParent;

    public bool isinstantiated = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        trajectoryDotsParent.SetActive(false);
        isinstantiated = false;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    //Display dots 
    public void DisplayTrajectory()
    {
        LAUNCH_VELOCITY = waterSpawner.speed * hose.transform.right;
        INITIAL_POSITION = waterSpawner.transform.position;
        for (int i = 0; i < NUM_DOTS_TO_SHOW; i++)
        {
            tDot[i].transform.position = CalculatePosition(DOT_TIME_STEP * i);
        }
    }

    //Calculate the position of the dots
    private Vector2 CalculatePosition(float elapsedTime)
    {
        return GRAVITY * elapsedTime * elapsedTime * 0.5f + LAUNCH_VELOCITY * elapsedTime + INITIAL_POSITION;
    }
}
