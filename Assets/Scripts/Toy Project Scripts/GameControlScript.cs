using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomPoseSpawnerScript : MonoBehaviour
{
    //A list of gameObjects that are the sillouhettes of players pose
    public List<GameObject> poses;

    //This will be assigned a random number in CorrectAnswer Function to select the number in the arrayList poses
    private int r;

    //The position of the **MainScriptHolder**, this is where the pose will be spawned
    public Transform spawnerPosition;

    //A game object that will be assigned to the current instantiated pose
    private GameObject spawnedPose;

    //A vector3 that will be assigned a random z value and be applied to the rotation of the spawnedPose
    private Vector3 randomRotation;

    //Reference to the script that keeps track of what sprite the player is currently using
    public ChangePlayerSprite playerScript;
    //Reference to the script that controls the timer
    public TimerBehavior timerScript;


  /////////////////////////////////////////////   SCOREING   //////////////////////////////////////
    //The text that displays the score
    public TextMeshProUGUI score;
    //Players score
    private int scoreNumber;
    //The end game score display
    public TextMeshProUGUI endScore;
  ///////////////////////////////////////////////////////////////////////////////////////////

  /////////////////////////////////////////////   PlAYER FEEDBACK    ///////////////////////////////
    //All the stuff for answer feedback
    public GameObject AnswerFeedbackScreen; //The screen that will flash red or green depending on correct or incorrect answer
    public Image feebackImage; //The UI Image that will be assigned red or green and be flashed with AnswerFeedbackScreen
    private float AnswerFeedbackTimer; //The timer that controls how long AnswerFeedbackScreen is visible for
    public AudioSource AnswerFeedbackSound; //The audiosource that will play a sound when "Do I Fit" Button is pressed
    public AudioClip correctAudio; //A chime for a correct Answer
    public AudioClip incorrectAudio; //A Buzzer for an Incorrect Answer
  ///////////////////////////////////////////////////////////////////////////////////////////

  ///////////////////////////////    WHAT IS BEIND DISPLAYED TO PLAYER    ///////////////////////////
    //All the stuff that needs to be turned on/off at the start and end of the game
    public GameObject mainGameUI;
    public GameObject backGroundsAndPlayer;
    public GameObject startingScreen;
    public GameObject failScreen;
    ///////////////////////////////////////////////////////////////////////////////////////////

    //This will be the gameobject with the timer script on. So when it is turned off the timer stops counting
    public GameObject timerStop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //reset score 
        scoreNumber = 0;
        //set answerFeedbacktimer to more than 0.3 so it doesnt display the screen at the beginging (see update)
        AnswerFeedbackTimer = 1;
        //Play the funciton Instructions, a breif hello and how to play for players
        Instructions();
    }

    // Update is called once per frame
    void Update()
    {
        //the displayed score will always equal the scoreNumber. To display player score
        score.text = "Score: " + scoreNumber.ToString();

        //the timer for the flashing screen to give player a visual and audio queue if the answer was right or wrong. Only last for 0.3 seconds
        if (AnswerFeedbackTimer < 0.3)
        {
            AnswerFeedbackScreen.SetActive(true);
        }
        else
        {
            AnswerFeedbackScreen.SetActive(false);
        }
        //increase the feedbacktimer by delta time
        AnswerFeedbackTimer += 1 * Time.deltaTime;

        //if timer (see TimerBehavior) reaches its max value, trigger youLost Function
        if(timerScript.timer.value >= timerScript.timer.maxValue)
        {
            YouLost();
        }
    }

    //This function controls what happeneds when the "Do i fit" button has been pressed
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

            //This function happends when the player presses the "Do i fit" and the answer is CORRECT
    public void CorrectAnswer()
    {
        //set feedback image color to green
        feebackImage.color = new Color(0, 1, 0, 0.5f);

        //set the audio player to a chime sound and play it
        AnswerFeedbackSound.clip = correctAudio;
        AnswerFeedbackSound.Play();

        //screen to flash breifly (see void Update())
        AnswerFeedbackTimer = 0;

        //increase score
        scoreNumber++;

        //reset clock Timer
        timerScript.timer.value = 0;

        //Destroys any previous spawned pose. We will only ever have one on screen at a time so this will not cause issues
        Destroy(spawnedPose);

        //Select a random number from poses array list
        r = Random.Range(0, poses.Count);
        //Spawn the random pose that was selected by r at the position of its spawner
        spawnedPose = Instantiate(poses[r], spawnerPosition);

        //select a random number for rotation between 0 and 359 (because 360 is the same as 0)
        randomRotation.z = Random.Range(0, 360);
        //Apply that rotation to the variable holding the information for the instantiated Pose
        spawnedPose.transform.eulerAngles = randomRotation;
    }

            //This function happends when the player presses the "Do i fit" and the answer is INCORRECT
    public void WrongAnswer()
    {
        //set feedback image color to red
        feebackImage.color = new Color(1, 0, 0, 0.5f);

        //set the audio player to a buzzer sound and play it
        AnswerFeedbackSound.clip = incorrectAudio;
        AnswerFeedbackSound.Play();

        //screen to flash breifly (see void Update())
        AnswerFeedbackTimer = 0;

        //timer values goes up 3 seconds as a punishment
        timerScript.timer.value += 3;
    }

            //This function is called when the "here" Button in the instructions is pressed and will begin the game
    public void BeginGame()
    {
        //Turn on all gameplay Elements
        mainGameUI.SetActive(true);
        backGroundsAndPlayer.SetActive(true);
        timerStop.SetActive(true);

        //Turn off none gameplay Elements
        startingScreen.SetActive(false);
        failScreen.SetActive(false);

        //Reset score and timer
        scoreNumber = 0;
        timerScript.timer.value = 0;

        //Spawn the first hole in the wall for the player
        r = Random.Range(0, poses.Count);
        spawnedPose = Instantiate(poses[r], spawnerPosition);
    }

            //This function is called when the timer runs out (slider max value is reached)
    public void YouLost()
    {
        //Turn off EVERYTHING that is not the fail screen
        mainGameUI.SetActive(false);
        backGroundsAndPlayer.SetActive(false);
        startingScreen.SetActive(false);
        //Turn on fail Screen
        failScreen.SetActive(true);

        //Display player score
        endScore.text = "Your Score: " + scoreNumber.ToString();

        //Destroy any pose that is currently on screen
        Destroy(spawnedPose);
    }

        //This function is called at the start of the game, it explains rules and a brief hello
    public void Instructions()
    {
        //Turn off EVERYTHING that is not the starting screen
        mainGameUI.SetActive(false);
        backGroundsAndPlayer.SetActive(false);
        failScreen.SetActive(false);
        timerStop.SetActive(false);

        //Turn on Starting Screen UI
        startingScreen.SetActive(true);
    }
}
