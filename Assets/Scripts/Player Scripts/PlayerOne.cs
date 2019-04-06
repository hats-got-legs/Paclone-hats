using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    //private PlayerOneScore playerOneScore;
    private LevelManager levelManager;

    public float speed;


    //int health = 0;
    public int pacOneNumber; //set to 6 in inspector, this number shown on player sprite, goes down one for each collectable collected - cannot be higher that six.
    public LevelManager win;
    public PlayerCollisons impact;
    //public ScoreDisplay ScoreDisplay; 
    public Sprite[] hitSprites;
    [SerializeField] private LayerMask visibleObjects; //choose Wall in Player Inspector

    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;

    public float rayLength; //used to try and stop player passing through wall at high speed - limited success so far

   


   // private SpriteRenderer spr;


    // Start is called before the first frame update
    void Start()
    {
        pacOneNumber = LevelManager.Instance.pacOneNumber;
        rb2d = GetComponent<Rigidbody2D>();
        LoadSprites();
        AlterSpeed();
    }

    public void PlayerOneMarathon()
    {
        rb2d = GetComponent<Rigidbody2D>();
        LoadSprites();
        AlterSpeed();
    }

    public void PlayerOneSingleLevel()
    {
        rb2d = GetComponent<Rigidbody2D>();
        LoadSprites();
        AlterSpeed();
    }


    void OnTriggerEnter2D() //if player touches collectable
    {
        PacNumberDown();
       
    }


    void FixedUpdate()
    {
        rayLength = (7 - pacOneNumber) * 1.5f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft(); //player movements currently linking out to separate void to stop Update being overloaded, not sure if this is causing a little slowdown? 
            //controls in general need improving somehow
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }
       
    }

    void MoveUp()
    {
        var hitUp = Physics2D.Raycast(up.position, Vector2.up, rayLength, visibleObjects);

        if (hitUp && hitUp.transform.tag == "Wall")
        {
         
        }
        if (!hitUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
         
        }
       
    }

    void MoveDown()
    {
        var hitDown = Physics2D.Raycast(down.position, Vector2.down, rayLength, visibleObjects);
    
        if (hitDown && hitDown.transform.tag == "Wall")
        {

        }
        if (!hitDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

        }
    }

    void MoveLeft()
    {
        var hitLeft = Physics2D.Raycast(left.position, Vector2.left, rayLength, visibleObjects);
      
        if (hitLeft && hitLeft.transform.tag == "Wall")
        {

        }
        if (!hitLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }

    }

    void MoveRight()
    {
        var hitRight = Physics2D.Raycast(right.position, Vector2.right, rayLength, visibleObjects);
       
        if (hitRight && hitRight.transform.tag == "Wall")
        {

        }
        if (!hitRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }

    }




    void OnCollisionEnter2D(Collision2D target) //uses tags to determine which other player has been collided with
    {

         if (target.gameObject.tag.Equals("PlayerTwoTag") == true)
        {
            Debug.Log("Lemsip");
            impact.PlayersOneAndTwoCollidedWithEachOther();
           
        }
        if (target.gameObject.tag.Equals("PlayerThreeTag") == true)
        {
            impact.PlayersOneAndThreeCollidedWithEachOther();

        }
        if (target.gameObject.tag.Equals("PlayerFourTag") == true)
        {
            impact.PlayersOneAndFourCollidedWithEachOther();

        }
    }






    void PacNumberDown()
    {
        if (pacOneNumber > 1) //if Pac Number greater than one before impact: pac number goes down one, new player sprite loads and speed goes up
        {
            pacOneNumber--;
            LevelManager.Instance.pacOneNumber = pacOneNumber;
            LoadSprites();
            AlterSpeed();
        }
        else if (pacOneNumber <= 1)
        {
           GameObject.Find("Canvas").GetComponent<GlobalControl>().PlayerOneWonRound();
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            GameObject.Find("ScriptHolder").GetComponent<LevelManager>().LoadNextLevel();
      
        }
    }



    public void PacNumberUpTwo()
    {
        if (pacOneNumber < 5) //pac number goes up by two...
        {
            pacOneNumber++;
            pacOneNumber++;
            LevelManager.Instance.pacOneNumber = pacOneNumber;
        }
        else { pacOneNumber++; // ...unless its currently on 5, in which case it only goes up by one as pac number cannot exceed 6 because of current limit on player sprites
            LevelManager.Instance.pacOneNumber = pacOneNumber;
        } 
        AlterSpeed();
        LoadSprites();
        //Destroy(gameObject);
        transform.position = new Vector3(355f, 285f, 0f);
        Invoke("SetBoolBack", 1);//bool to stop two player scripts both contacting PlayerCollisions script for same impact, resets to allow 
                                 //impacts after one second, may cause issues in 3 and 4 player games? see note in PlayerCollisions script.
    }




    public void SetBoolBack()
    {
    impact.hasImpactOccurred = false;
}


    public void PacNumberUpOne()
    {
        if (pacOneNumber < 6) //pac number cannot currently exceed six
        {
            pacOneNumber++;
            LoadSprites();
            AlterSpeed();
            LevelManager.Instance.pacOneNumber = pacOneNumber;
        }
        transform.position = new Vector3(355f, 285f, 0f);
        Invoke("SetBoolBack", 1);
        Debug.Log("P1 up1");
    }

    //Makes number in spritesheet match pacNumber
    public void LoadSprites()
    {

        int spriteIndex = pacOneNumber - 1; //sprite number needs to be one less than pac number as sprites start at zero.
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; //selects correct sprite from spriteArray
    }

    //Speed goes up as pacNumber comes down!
    //Currently a bit broken as higher speeds allow player to pass through walls (update: partly fixed by raycasting)
    public void AlterSpeed ()
    {
        speed = (7 - pacOneNumber) * 250;
    }
}
