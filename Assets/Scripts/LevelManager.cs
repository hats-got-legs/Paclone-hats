using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private GlobalControl globalControl;

    private LevelManager levelManager;

    private Collectable collectable;

    public PlayerOne playerOne;
    public PlayerTwo playerTwo; 
    public PlayerThree playerThree; 
    public PlayerFour playerFour;

    public Button StartMarathon;
    public Button LevelOne;
    public Button LevelTwo;
    public Button LevelThree;

    public Button Menu;

    public int pacOneNumber;
    public int pacTwoNumber;
    public int pacThreeNumber;
    public int pacFourNumber;


    public static bool loadOnlyOneLevel; //alters how script works depending on which game was selected at menu 


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
       
            Scene scene = SceneManager.GetActiveScene(); 
            StartMarathon.onClick.AddListener(EnterMarathonMode);
            LevelOne.onClick.AddListener(EnterLevelOne);
            LevelTwo.onClick.AddListener(EnterLevelTwo);
            LevelThree.onClick.AddListener(EnterLevelThree);
            Menu.onClick.AddListener(GoToMainMenu);
        //LevelUno.onClick.AddListener(EnterLevelOne);
       

    }
    private void Update() // checks wether bool is currently true or false
    {
       

        if (loadOnlyOneLevel)
        {
            globalControl.LevelSetSingle();

        }
        if (!loadOnlyOneLevel)
        {

            globalControl.LevelSetMarathon();

        }
    }
   
    void EnterMarathonMode() //sets bool, pacNumbers, tells Player scripts to alter sprite, speed etc.
    {
        loadOnlyOneLevel = false;
        SceneManager.LoadScene("Level One"); //link to buttons
        pacOneNumber = 6;
        pacTwoNumber = 6;
        pacThreeNumber = 6;
        pacFourNumber = 6;
        playerOne.PlayerOneMarathon();
        playerTwo.PlayerTwoMarathon();
        playerThree.PlayerThreeMarathon();
        playerFour.PlayerFourMarathon();

    }

    void EnterLevelOne() //sets bool, pacNumbers, tells Player scripts to alter sprite, speed etc.
    {
        loadOnlyOneLevel = true;
        SceneManager.LoadScene("Level One"); //link to buttons
        SingleLevelPacPrefs();
    }

   
    void EnterLevelTwo()
    {
        loadOnlyOneLevel = true;
        SceneManager.LoadScene("Level Two"); //link to buttons
        SingleLevelPacPrefs();
    }

    void EnterLevelThree()
    {
        loadOnlyOneLevel = true;
        SceneManager.LoadScene("Level Three"); //link to buttons
        SingleLevelPacPrefs();
    }

    void SingleLevelPacPrefs()
    {
        pacOneNumber = 1;
        pacTwoNumber = 1;
        pacThreeNumber = 1;
        pacFourNumber = 1;
        playerOne.PlayerOneSingleLevel();
        playerTwo.PlayerTwoSingleLevel();
        playerThree.PlayerThreeSingleLevel();
        playerFour.PlayerFourSingleLevel();
    }


    void GoToMainMenu()
    {
      
        SceneManager.LoadScene("Menu"); //link to buttons
    }

    public void LoadNextLevel() //used to cycle through scenes, probably a more elegant way to do this... Will need to be rewritten to incorporate newly created scenes
    {
       
        if (loadOnlyOneLevel)
        {

        }
        else if (!loadOnlyOneLevel)
        {

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level One"))
            {
                SceneManager.LoadScene("Level Two");
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level Two"))
            {
                SceneManager.LoadScene("Level Three");
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level Three"))
            {
                SceneManager.LoadScene("Level One");
            }
        }
    }

   //public void OnMouseDown()
  // {
     //   Application.LoadLevel("Level One");
 //  }


        //pacNumberDown in Player"number" scripts link here when pacNumber reaches zero
    public void WinScreenPlayerOne()
    {
       
        SceneManager.LoadScene("Player One Wins");

    }

    public void WinScreenPlayerTwo()
    {
        SceneManager.LoadScene("Player Two Wins");
    }

    public void WinScreenPlayerThree()
    {
        SceneManager.LoadScene("Player Three Wins");
    }

    public void WinScreenPlayerFour()
    {
        SceneManager.LoadScene("Player Four Wins");
    }


}
