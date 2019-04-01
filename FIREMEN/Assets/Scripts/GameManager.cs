using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using Water2D;


public class GameManager : MonoBehaviour {

	public static GameManager gm;


    public GameObject levelCompletedPanel;
    public GameObject ResetTimer;
    public Text resetTimerText;
    public Water2D_Spawner water2D_Spawner;
	// UI elements to control
    public Slider waterSlider;

    //to control the slider value and gametime
    public float spraytime = 0f;
    public float endtime = 7f;
    public float waitTimeForLevelEnd = 2f;
    public bool isTimeUp;
	// private variables

	Scene _scene;
    LevelManager level;

    public bool levelCompleted = false;


	void Awake () {
	
		if (gm == null)
			gm = this.GetComponent<GameManager>();

		// setup all defaults
        waterSlider.value = 1f;
        levelCompleted = false;
        levelCompletedPanel.SetActive(false);
        ResetTimer.SetActive(false);

        level = GameObject.FindObjectOfType<LevelManager>();
        isTimeUp = false;
	}


    void Update()
    {
        //increase the spraytime
        if (RotateHose.isSpraying)
        {
            spraytime += Time.deltaTime;
            waterSlider.value = 1 - (spraytime / endtime);
        }
        //stop sparying water if spraytime is greater than endtime
        if (spraytime >= endtime)
        {
            water2D_Spawner.Dynamic = false;
            RotateHose.isSpraying = false;
            spraytime += Time.deltaTime;
            isTimeUp = true;
        }

        //level completed if the flames are extinguished
        if (!ExtinguishFire.isFlameBurning && !levelCompleted)
        {
           //print("LevelCompelte");
            levelCompleted = true;
            StartCoroutine("DisplayLevelCompletePanel");    
        }

        //wait for game to end 
        if (spraytime>(endtime+waitTimeForLevelEnd) && ExtinguishFire.isFlameBurning && !levelCompleted)
        {
            StartResettingGame();
            levelCompleted = true;
        }

    }

    public void StartResettingGame()
    {
         StartCoroutine("ResetGameAfterDelay");
    }
    IEnumerator DisplayLevelCompletePanel()
    {
        yield return new WaitForSeconds(1f);
        levelCompletedPanel.SetActive(true);
    }

    IEnumerator ResetGameAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        ResetTimer.SetActive(true);
        resetTimerText.text = "3";
        StartCoroutine("ResetGameAfter2");
    }

    IEnumerator ResetGameAfter2()
    {
        yield return new WaitForSeconds(1f);
        resetTimerText.text = "2";
        StartCoroutine("ResetGameAfter1");
    }

    IEnumerator ResetGameAfter1()
    {
        yield return new WaitForSeconds(1f);
        resetTimerText.text = "1";
        StartCoroutine("ResetGame");
    }

    IEnumerator ResetGame()
    {
        resetTimerText.text = "1";
        yield return new WaitForSeconds(1f);
        level.LoadCurrentLevel();
    }
}
