using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisons : MonoBehaviour
{
  
    private LevelManager levelManager;


    public bool hasImpactOccurred; //used to create one second delay before player impact can occur again so that only 
                                    //one of the two colliding players can access this script - without this playerPacNumbers
                                    //were going up by twice as much as intended 
                                    // This may cause some issues in 3 and 4 players with the other two players colliding 
                                    //in the one second window, maybe can make window a fraction of a second


  

    public void PlayersOneAndTwoCollidedWithEachOther()
    {
   
        if (hasImpactOccurred == false)
        {
          
            hasImpactOccurred = true;
             if (LevelManager.Instance.pacTwoNumber == LevelManager.Instance.pacOneNumber)
            {

                EqualImpactPlayerOneAndTwo();
                Debug.Log("EqualImpact part 1");
             
            }
            else if (LevelManager.Instance.pacTwoNumber > LevelManager.Instance.pacOneNumber)
            {

                PlayerOneLose();
                Debug.Log("P1 Lose part 1");
              
            }
            else if (LevelManager.Instance.pacTwoNumber < LevelManager.Instance.pacOneNumber)
            {

                PlayerTwoLose();
                Debug.Log("P2 Lose");
             
            }
           
        }

    }

    // ********
    //Loads of voids covering every possibility of player collision and linking to voids below
    public void PlayersOneAndThreeCollidedWithEachOther()
    {
        if (hasImpactOccurred == false)
        {
            hasImpactOccurred = true;
            if (LevelManager.Instance.pacThreeNumber == LevelManager.Instance.pacOneNumber) ////
            {

                EqualImpactPlayerOneAndThree();


            }
            else if (LevelManager.Instance.pacThreeNumber > LevelManager.Instance.pacOneNumber)
            {

                PlayerOneLose();
               

            }
            else if (LevelManager.Instance.pacThreeNumber < LevelManager.Instance.pacOneNumber)
            {

                PlayerThreeLose();
          

            }

        }

    }

    public void PlayersOneAndFourCollidedWithEachOther()
    {
        if (hasImpactOccurred == false)
        {
            hasImpactOccurred = true;
            if (LevelManager.Instance.pacFourNumber == LevelManager.Instance.pacOneNumber) ////
            {

                EqualImpactPlayerOneAndFour();
                Debug.Log("EqualImpact part 2");

            }
            else if (LevelManager.Instance.pacFourNumber > LevelManager.Instance.pacOneNumber)
            {

                PlayerOneLose();
                Debug.Log("P1 Lose part 1");

            }
            else if (LevelManager.Instance.pacFourNumber < LevelManager.Instance.pacOneNumber)
            {

                PlayerFourLose();
                Debug.Log("P2 Lose");

            }

        }

    }

    public void PlayersTwoAndFourCollidedWithEachOther()
    {
        if (hasImpactOccurred == false)
        {
            hasImpactOccurred = true;
            if (LevelManager.Instance.pacFourNumber == LevelManager.Instance.pacTwoNumber) ////
            {

                EqualImpactPlayerTwoAndFour();
                Debug.Log("EqualImpact part 2");

            }
            else if (LevelManager.Instance.pacFourNumber > LevelManager.Instance.pacTwoNumber)
            {

                PlayerTwoLose();
                Debug.Log("P1 Lose part 1");

            }
            else if (LevelManager.Instance.pacFourNumber < LevelManager.Instance.pacTwoNumber)
            {

                PlayerFourLose();
                Debug.Log("P2 Lose");

            }

        }

    }

    public void PlayersTwoAndThreeCollidedWithEachOther()
    {
        if (hasImpactOccurred == false)
        {
            hasImpactOccurred = true;
            if (LevelManager.Instance.pacThreeNumber == LevelManager.Instance.pacTwoNumber) ////
            {

                EqualImpactPlayerTwoAndThree();
                Debug.Log("EqualImpact part 2");

            }
            else if (LevelManager.Instance.pacThreeNumber > LevelManager.Instance.pacTwoNumber)
            {

                PlayerTwoLose();
                Debug.Log("P1 Lose part 1");

            }
            else if (LevelManager.Instance.pacThreeNumber < LevelManager.Instance.pacTwoNumber)
            {

                PlayerThreeLose();
                Debug.Log("P2 Lose");

            }

        }

    }

    public void PlayersThreeAndFourCollidedWithEachOther()
    {
        if (hasImpactOccurred == false)
        {
            hasImpactOccurred = true;
            if (LevelManager.Instance.pacThreeNumber == LevelManager.Instance.pacFourNumber) ////
            {

                EqualImpactPlayerThreeAndFour();
                Debug.Log("EqualImpact part 2");

            }
            else if (LevelManager.Instance.pacThreeNumber > LevelManager.Instance.pacFourNumber)
            {

                PlayerFourLose();
                Debug.Log("P1 Lose part 1");

            }
            else if (LevelManager.Instance.pacThreeNumber < LevelManager.Instance.pacFourNumber)
            {

                PlayerThreeLose();
                Debug.Log("P2 Lose");

            }

        }

    }
    //*************


        //$$$$$$$
        //each possible collision outcome linking back to relevant player script(s)
    public void PlayerOneLose ()
    {

        GameObject.Find("Player One").GetComponent<PlayerOne>().PacNumberUpTwo();
        Debug.Log("P1 Lose part 2");
       

    }

    public void PlayerTwoLose()
    {
       
        GameObject.Find("Player Two").GetComponent<PlayerTwo>().PacNumberUpTwo();
        Debug.Log("P2 Lose part 2");
    

    }

    public void PlayerThreeLose()
    {

        GameObject.Find("Player Three").GetComponent<PlayerThree>().PacNumberUpTwo();
        Debug.Log("P2 Lose part 2");


    }

    public void PlayerFourLose()
    {

        GameObject.Find("Player Four").GetComponent<PlayerFour>().PacNumberUpTwo();
        Debug.Log("P2 Lose part 2");


    }



    public void EqualImpactPlayerOneAndTwo ()
    {

        GameObject.Find("Player One").GetComponent<PlayerOne>().PacNumberUpOne();
        GameObject.Find("Player Two").GetComponent<PlayerTwo>().PacNumberUpOne();
      
    }

    public void EqualImpactPlayerOneAndThree()
    {
        GameObject.Find("Player One").GetComponent<PlayerOne>().PacNumberUpOne();
        GameObject.Find("Player Three").GetComponent<PlayerThree>().PacNumberUpOne();

    }

    public void EqualImpactPlayerOneAndFour()
    {
        GameObject.Find("Player One").GetComponent<PlayerOne>().PacNumberUpOne();
        GameObject.Find("Player Four").GetComponent<PlayerFour>().PacNumberUpOne();

    }

    public void EqualImpactPlayerTwoAndThree()
    {
        GameObject.Find("Player Two").GetComponent<PlayerTwo>().PacNumberUpOne();
        GameObject.Find("Player Three").GetComponent<PlayerThree>().PacNumberUpOne();

    }

    public void EqualImpactPlayerTwoAndFour()
    {
        GameObject.Find("Player Two").GetComponent<PlayerTwo>().PacNumberUpOne();
        GameObject.Find("Player Four").GetComponent<PlayerFour>().PacNumberUpOne();

    }

    public void EqualImpactPlayerThreeAndFour()
    {
        GameObject.Find("Player Three").GetComponent<PlayerThree>().PacNumberUpOne();
        GameObject.Find("Player Four").GetComponent<PlayerFour>().PacNumberUpOne();

    }
    //$$$$$$$$$$$$$$

}
