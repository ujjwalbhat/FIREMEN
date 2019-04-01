using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class RotateHose : MonoBehaviour
{
    Vector2 startPos,endPos,mouseUpPos;
    Vector2 direction,direction1;
    public bool isDragOnly;

    public static bool isSpraying = false;

    public Trajectory trajectory;

    public Water2D_Spawner water2D_Spawner;

    void Awake()
    {
   
    }

    void Start()
    {
        //setup defaults
        isSpraying = false;
        isDragOnly = false;
        direction = transform.right;
        direction1 = direction;
        trajectory.trajectoryDotsParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

      
        if (Input.GetMouseButtonDown(0))
        {
            isDragOnly = true;
            startPos = Input.mousePosition;
            water2D_Spawner.Dynamic = false;
            isSpraying = false;
            trajectory.trajectoryDotsParent.SetActive(true);
            trajectory.DisplayTrajectory();
        }

        //rotate the hose/cannon by dragging anywhere on the screen
        if (isDragOnly)
        {
            endPos = Input.mousePosition;

            if (endPos.magnitude != startPos.magnitude)
            {
                direction1 = direction + (endPos - startPos)/30;
                float angle = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Lerp(transform.rotation, q, 500 * Time.deltaTime);
                trajectory.DisplayTrajectory();
            }
        }

       
        if (Input.GetMouseButtonUp(0) && !isSpraying)
        {
            trajectory.trajectoryDotsParent.SetActive(false);
            mouseUpPos = Input.mousePosition;
            direction = direction1;
            isDragOnly = false;
            isSpraying = true;
            //spray water if game manager time is not up 
            if (!GameManager.gm.isTimeUp && !gas.gasCanExploded)
            {
                water2D_Spawner.Dynamic = true;
                water2D_Spawner.Spawn();
          
            } 
        }
    }


}
