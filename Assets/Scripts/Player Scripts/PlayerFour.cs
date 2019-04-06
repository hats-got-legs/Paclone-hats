using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFour : MonoBehaviour
{

    private Rigidbody2D rb2d;
   // private PlayerFourScore playerFourScore;
    private LevelManager levelManager;
    private PlayerFour playerFour;


    public float speed;
    public int pacFourNumber; //set to 6 in inspector, this number shown on player sprite, goes down one for each collectable collected - cannot be higher that six.
    public LevelManager win;
    public PlayerCollisons impact;
    public Sprite[] hitSprites;
    private bool TestTest = true;
    public static bool loadOnlyOneLevel;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;

    public float rayLength; //used to try and stop player passing through wall at high speed - limited success so far

    [SerializeField] private LayerMask visibleObjects; //choose Wall in Player Inspector
    private SpriteRenderer spr;




    // Start is called before the first frame update
    void Start()
    {
        pacFourNumber = LevelManager.Instance.pacFourNumber;
        rb2d = GetComponent<Rigidbody2D>();
        LoadSprites();
        AlterSpeed();


    }

 

    public void PlayerFourMarathon ()
    {
        Debug.Log("Marathon 3");
        //pacFourNumber = 3;
        rb2d = GetComponent<Rigidbody2D>();
        LoadSprites();
        AlterSpeed();
    }

    public void PlayerFourSingleLevel()
    {
        Debug.Log("Single 2");
        //pacFourNumber = 2;
        rb2d = GetComponent<Rigidbody2D>();
        LoadSprites();
        AlterSpeed();
    }

    void OnTriggerEnter2D()  //if player touches collectable
    {
        PacNumberDown();


    }



    void FixedUpdate()
    {
        rayLength = (7 - pacFourNumber) * 1.5f; //raycast gets longer as player speed increases - may need fine tuning to work perfectly or a complete rethink

        if (Input.GetKey(KeyCode.J))
        {
            MoveLeft(); //player movements currently linking out to separate void to stop Update being overloaded, not sure if this is causing a little slowdown? 
            //controls in general need improving somehow
        }
        if (Input.GetKey(KeyCode.K))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.I))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.M))
        {
            MoveDown();
        }

    }

    void MoveUp()
    {
        Debug.Log("Wall Detected");
        var hitUp = Physics2D.Raycast(up.position, Vector2.up, 1.5f, visibleObjects);

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
        var hitDown = Physics2D.Raycast(down.position, Vector2.down, 1.5f, visibleObjects);
       
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
        var hitLeft = Physics2D.Raycast(left.position, Vector2.left, 1.5f, visibleObjects);
       
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
        var hitRight = Physics2D.Raycast(right.position, Vector2.right, 1.5f, visibleObjects);
       
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
        if (target.gameObject.tag.Equals("PlayerOneTag") == true)
        {
            impact.PlayersOneAndFourCollidedWithEachOther();
        }
        if (target.gameObject.tag.Equals("PlayerTwoTag") == true)
        {
            impact.PlayersTwoAndFourCollidedWithEachOther();
        }
        if (target.gameObject.tag.Equals("PlayerThreeTag") == true)
        {
            impact.PlayersThreeAndFourCollidedWithEachOther();
        }
    }


    void PacNumberDown()
    {
        if (pacFourNumber > 1)  //if Pac Number greater than one before impact: pac number goes down one, new player sprite loads and speed goes up
        {
            pacFourNumber--;
            LevelManager.Instance.pacFourNumber = pacFourNumber;
            LoadSprites();
            AlterSpeed();
        }
        else if (pacFourNumber <= 1) //if pac number becomes zero on contact with collectable: player score goes up by one, load next level
        {
            GameObject.Find("Canvas").GetComponent<GlobalControl>().PlayerFourWonRound();
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            GameObject.Find("ScriptHolder").GetComponent<LevelManager>().LoadNextLevel();

        }
    }



    public void PacNumberUpTwo()
    {
        if (pacFourNumber < 5) //pac number goes up by two...
        {
            pacFourNumber++;
            pacFourNumber++;
            LevelManager.Instance.pacFourNumber = pacFourNumber;
        }
        else
        {
            pacFourNumber++;  // ...unless its currently on 5, in which case it only goes up by one as pac number cannot exceed 6 because of current limit on player sprites
            LevelManager.Instance.pacFourNumber = pacFourNumber;
        }
            AlterSpeed();
        LoadSprites();
        //Destroy(gameObject);
        transform.position = new Vector3(440f, 210f, 0f); //player goes back to starting vector
        Invoke("SetBoolBack", 1); //bool to stop two player scripts both contacting PlayerCollisions script for same impact, resets to allow 
                //impacts after one second, may cause issues in 3 and 4 player games? see note in PlayerCollisions script.
   
    }




    public void SetBoolBack()
    {
        impact.hasImpactOccurred = false;
    }


    public void PacNumberUpOne()
    {
        if (pacFourNumber < 6) //pac number cannot currently exceed six
        {
            pacFourNumber++;
            LevelManager.Instance.pacFourNumber = pacFourNumber;
            LoadSprites();
            AlterSpeed();

        }
        transform.position = new Vector3(440f, 210f, 0f);
        Invoke("SetBoolBack", 1);
      
    }

    //Makes number in spritesheet match pacNumber
    public void LoadSprites()
    {

        int spriteIndex = pacFourNumber - 1; //sprite number needs to be one less than pac number as sprites start at zero.
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; //selects correct sprite from spriteArray
    }

    //Speed goes up as pacNumber comes down!
    //Currently a bit broken as higher speeds allow player to pass through walls (update: partly fixed by raycasting)
    public void AlterSpeed()
    {
        speed = (7 - pacFourNumber) * 250;
    }
}
