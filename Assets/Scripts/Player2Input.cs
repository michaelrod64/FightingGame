using UnityEngine;
using System.Collections;

public class Player2Input : GameControllerInterface {

    private float RunSpeed = 1;
    public float jumpHeight = 300;
    public float doubleJumpHeight = 250;
    public bool singleJumped = false;
    public bool doubleJumped = false;
    bool start = true;
    GameController gamecontroller;
    PlayerModel player2Model;
    GameObject PersistentDataObject;
    PersistentData playerData;
    int player;
    KeyCode left;
    KeyCode right;
    KeyCode jump;
    KeyCode attack;

    // Use this for initialization
    void Start()
    {
        PersistentDataObject = GameObject.Find("PersistentDataObject");
        playerData = PersistentDataObject.GetComponent<PersistentData>();
        player = playerData.getPlayer2Choice();

        if(player == 1)
        {
            left = KeyCode.J;
            right = KeyCode.L;
            jump = KeyCode.I;
            attack = KeyCode.Semicolon;
            GetComponent<Transform>().position = new Vector3(Screen.width/32, Screen.height/64, 0);
        }
        else
        {
            left = KeyCode.A;
            right = KeyCode.D;
            jump = KeyCode.W;
            attack = KeyCode.F;
            GetComponent<Transform>().position = new Vector3(-Screen.width/32, Screen.height/64, 0);
        }





    }

    // Update is called once per frame
    void Update()
    {
        if (start && (player == 1))
        {
            gameController.gameModel.player2.facingLeft(true);
            start = false;
        }
        else if(start)
        {
            gameController.gameModel.player2.facingLeft(false);
            start = false;
        }
           

        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            singleJumped = false;
            doubleJumped = false;
        }

        if ((gameController.gameModel.player2.getState() != 2) && Input.GetKeyDown(jump))
        { //jump button subject to change
            if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > 0 && singleJumped && !doubleJumped)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, doubleJumpHeight);
                doubleJumped = true;
                GetComponent<AudioSource>().Play();
            }
            else if (!singleJumped)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); // leaves x velocity unchanged, makes y velocity 100 
                GetComponent<AudioSource>().Play();
                singleJumped = true;
            }
        }
        if ((gameController.gameModel.player2.getState() != 2) && Input.GetKey(right))
        {
            GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x + RunSpeed, GetComponent<Rigidbody2D>().position.y);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(RunSpeed, GetComponent<Rigidbody2D>().velocity.y);
            gameController.gameModel.player2.facingLeft(false);
        }
        if (((gameController.gameModel.player2.getState() != 2) && Input.GetKey(left)))
        {
            GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x - RunSpeed, GetComponent<Rigidbody2D>().position.y);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-RunSpeed, GetComponent<Rigidbody2D>().velocity.y);
            gameController.gameModel.player2.facingLeft(true);
        }
        if (gameController.gameModel.player2.getLives() <= 0)
        {
            gameController.gameModel.player2.setState("Dead");
        }
        else
        {
            if ((GetComponent<Rigidbody2D>().velocity.y < Mathf.Abs(2)) && (Input.GetKey(left) || Input.GetKey(right)) && (!Input.GetKey(attack)))
            {
                gameController.gameModel.player2.setState("Running");
            }
            if ((!(Input.GetKey(left) || Input.GetKey(right) || Input.GetKey(attack)) && (GetComponent<Rigidbody2D>().velocity.y == 0)))
            {
                gameController.gameModel.player2.setState("Idle");
            }
            if ((!(Input.GetKey(attack)) && GetComponent<Rigidbody2D>().velocity.y != 0))
            {
                gameController.gameModel.player2.setState("Jumping");
            }
            if (Input.GetKeyDown(attack))
            {
                gameController.gameModel.player2.setState("Attacking");
            }
        }




    }

}