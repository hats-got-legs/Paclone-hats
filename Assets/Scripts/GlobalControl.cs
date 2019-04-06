using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlobalControl : MonoBehaviour
{

    //This script maintains data between scenes - such as Player Scores in Marathon

    public static GlobalControl Instance;
    //public static bool loadOnlyOneLevel;
    public int playerOneScore;
    public int playerTwoScore;
    public int playerThreeScore;
    public int playerFourScore;

    public Text playerOneScoreText;
    public Text playerTwoScoreText;
    public Text playerThreeScoreText;
    public Text playerFourScoreText;

    private LevelManager levelM;

    void Awake()   //avoids duplicate copies of GameMaster GO (which has GlobalControl script attached) from appearing in scenes
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        playerOneScoreText.text = playerOneScore.ToString(); //keeps on screen score up to date
        playerTwoScoreText.text = playerTwoScore.ToString();
        playerThreeScoreText.text = playerThreeScore.ToString();
        playerFourScoreText.text = playerFourScore.ToString();
    }

    public void PlayerOneWonRound()
    {
        Debug.Log("PlayerOneScores");
        playerOneScore++;
        playerOneScoreText.text = playerOneScore.ToString(); //keeps on screen score up to date
        //GlobalControl.Instance.playerFourScore = playerFourScore; // script SETS Player"Number"Score TO GlobalControl
        //playerFourScore = GlobalControl.Instance.playerFourScore;
    }

    public void PlayerTwoWonRound()
    {
        playerTwoScore++;
        playerTwoScoreText.text = playerTwoScore.ToString(); //keeps on screen score up to date
        //GlobalControl.Instance.playerFourScore = playerFourScore; // script SETS Player"Number"Score TO GlobalControl
        //playerFourScore = GlobalControl.Instance.playerFourScore;
    }

    public void PlayerThreeWonRound()
    {
        playerThreeScore++;
        playerThreeScoreText.text = playerThreeScore.ToString(); //keeps on screen score up to date
        //GlobalControl.Instance.playerFourScore = playerFourScore; // script SETS Player"Number"Score TO GlobalControl
        //playerFourScore = GlobalControl.Instance.playerFourScore;
    }

    public void PlayerFourWonRound()
    {
        playerFourScore++;
        playerFourScoreText.text = playerFourScore.ToString(); //keeps on screen score up to date
        //GlobalControl.Instance.playerFourScore = playerFourScore; // script SETS Player"Number"Score TO GlobalControl
        //playerFourScore = GlobalControl.Instance.playerFourScore;
    }



    public void LevelSetSingle () //linked to if LoadOnlyOneLevel in LevelManager is set to True, declares winner if player reaches 20 points
    {
        Debug.Log("OneLev");
        if (playerOneScore >= 20)
            {

                GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerOne();
                ScoreReset();
            }

            if (playerTwoScore >= 20)
            {

                GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerTwo();
                ScoreReset();
            }

            if (playerThreeScore >= 20)
            {

                GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerThree();
                ScoreReset();
            }

            if (playerFourScore >= 20)
            {
                GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerFour();
                ScoreReset();
            }

        }
       
       



public void LevelSetMarathon () //linked to if LoadOnlyOneLevel in LevelManager is set to False, declares winner if player reaches 5 points
    {
        Debug.Log("MarathonLevs");
        if (playerOneScore >= 5)
    {

        GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerOne();
        ScoreReset();
    }

    if (playerTwoScore >= 5)
    {

        GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerTwo();
        ScoreReset();
    }

    if (playerThreeScore >= 5)
    {

        GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerThree();
        ScoreReset();
    }

    if (playerFourScore >= 5)
    {
        GameObject.Find("ScriptHolder").GetComponent<LevelManager>().WinScreenPlayerFour();
        ScoreReset();
    }
}



private void ScoreReset() //resets scores to zero
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        playerThreeScore = 0;
        playerFourScore = 0;
    }
    // public void PlayerOneWon ()
    //  {
    //      playerOneScore++;
    //  }
}
