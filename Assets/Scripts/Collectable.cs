using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject item;
    float randomX, randomY; //limit range to game are for spawning collectable pellet
    Vector2 whereToSpawn;
   // public Sprite[] pelletSprites;
   private bool gameHasStarted = false; //use to only spawn one collectable in update at start of scene
  
    private LevelManager levelManager;
    private Collectable collectable;


  


    void Update()
    {

        if (!gameHasStarted)
        {
            gameHasStarted = true;
            RandomRespawn();

        }

    }

   

    void OnTriggerEnter2D() //create new collectable and destroy the one that has been hit by a player
    {

        RandomRespawn();
        Destroy(gameObject); 

    }

    public void RandomRespawn()
    {

        int randomX = (int)Random.Range(61f, 731f);
        int randomY = (int)Random.Range(62f, 445f);
        whereToSpawn = new Vector2(randomX, randomY);
        Instantiate (item, whereToSpawn, Quaternion.identity);
        //int spriteIndex = Random.Range(0, pelletSprites.Length);
        //LoadSprites();

        // TODO: make collectable not spawn on player or wall, make collectable spawn not too close to collectable just destroyed?, 
        //sometimes more that one collectable sprite will appear in scene - but only one is actual collectable (the rest can just be passed over) - need to work out why and stop it happening.

    }



}
