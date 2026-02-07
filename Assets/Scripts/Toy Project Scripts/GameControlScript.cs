using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomPoseSpawnerScript : MonoBehaviour
{

    public List<GameObject> poses;

    private int r;

    public Transform spawnerPosition;

    private GameObject spawnedPose;

    private Vector3 randomRotation;

    public ChangePlayerSprite playerScript;
    public TimerBehavior timerScript;

    public TextMeshProUGUI score;
    private int scoreNumber;

    public GameObject AnswerFeedbackScreen;
    private float AnswerFeedbackTimer;
    public AudioSource AnswerFeedbackSound;
    public AudioClip correctAudio;
    public AudioClip incorrectAudio;
    public Image feebackImage;

    //All the stuff that needs to be turned on/off at the start and end of the game
    public GameObject mainGameUI;
    public GameObject backGroundsAndPlayer;
    public GameObject startingScreen;
    public GameObject failScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreNumber = 0;
        AnswerFeedbackTimer = 1;
        AnswerFeedbackScreen.SetActive(false);
        Instructions();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreNumber.ToString();

        if (AnswerFeedbackTimer < 0.3)
        {
            AnswerFeedbackScreen.SetActive(true);
        }
        else
        {
            AnswerFeedbackScreen.SetActive(false);
        }
        AnswerFeedbackTimer += 1 * Time.deltaTime;

        if(timerScript.timer.value >= 20)
        {
            YouLost();
        }
    }

    public void DoIFit()
    {

        //if player script is equal to r that means the selected sprite is the same as the sprite in the arraylist
        //0 is pose 1, 1 is pose 2, ect (see ChangePlayerSprite script)
        //AND playerRotation (from ChangePlayerScript) is within 40 of randomRotation. Meaning the player is the same rotation as the randomly generated rotation of the sillouhette
       if(playerScript.playerCurrentSprite == r && playerScript.playerRotation.z < (randomRotation.z + 20) && playerScript.playerRotation.z > (randomRotation.z - 20))
       {
            CorrectAnswer();
       }
        else
        {
            WrongAnswer();
        }
    }

    public void CorrectAnswer()
    {
        //set feedback image color to green
        feebackImage.color = new Color(0, 1, 0, 0.5f);

        //set feedback audio to correct aduio and play it
        AnswerFeedbackSound.clip = correctAudio;
        AnswerFeedbackSound.Play();
        //screen to flash breifly (see void Update())
        AnswerFeedbackTimer = 0;

        //increase score
        scoreNumber++;

        //resetTimer
        timerScript.timer.value = 0;

        //Destroys any previous spawned pose. We will only ever have one on screen at a time so this will not cause issues
        Destroy(spawnedPose);
        //Select a random number from poses list
        r = Random.Range(0, poses.Count);
        //Spawn the random pose that was selected by r
        spawnedPose = Instantiate(poses[r], spawnerPosition);
        //select a random number for rotation
        randomRotation.z = Random.Range(0, 360);
        //Apply that rotation to the variable holding the information for the instantiated Pose
        spawnedPose.transform.eulerAngles = randomRotation;
    }

    public void WrongAnswer()
    {
        //set feedback image color to red
        feebackImage.color = new Color(1, 0, 0, 0.5f);

        //play sound
        AnswerFeedbackSound.clip = incorrectAudio;
        AnswerFeedbackSound.Play();

        //screen to flash breifly (see void Update())
        AnswerFeedbackTimer = 0;
        //timer values goes up 3
        timerScript.timer.value += 3;
    }

    public void BeginGame()
    {
        //Turn on all gameplay Elements, Setting Everything to 0
        mainGameUI.SetActive(true);
        backGroundsAndPlayer.SetActive(true);

        //Turn off none gameplay Elements
        startingScreen.SetActive(false);
        failScreen.SetActive(false);

        //score to 0
        scoreNumber = 0;
        //Timer to 0
        timerScript.timer.value = 0;
    }

    public void YouLost()
    {
        //Turn off EVERYTHING that is not the fail screen
        mainGameUI.SetActive(false);
        backGroundsAndPlayer.SetActive(false);
        startingScreen.SetActive(false);
        //Turn on fail Screen
        failScreen.SetActive(true);
    }

    public void Instructions()
    {
        //Turn off EVERYTHING
        mainGameUI.SetActive(false);
        backGroundsAndPlayer.SetActive(false);
        failScreen.SetActive(false);

        //Turn on Starting Screen UI
        startingScreen.SetActive(true);
    }
}
