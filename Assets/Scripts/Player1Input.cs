using UnityEngine;
using System.Collections;

public class Player1Input : GameControllerInterface {

    private float RunSpeed = 1;
    public float jumpHeight = 300;
    public float doubleJumpHeight = 250;
    public bool singleJumped = false;
    public bool doubleJumped = false;

    GameController gamecontroller;
    PlayerModel player1Model;

    bool start = true;
    GameObject PersistentDataObject;
    PersistentData playerData;
    int player;
    KeyCode left;
    KeyCode right;
    KeyCode jump;
    KeyCode attack;


    // Use this for initialization
    void Start () {

        PersistentDataObject = GameObject.Find("PersistentDataObject");
        playerData = PersistentDataObject.GetComponent<PersistentData>();
        player = playerData.getPlayer1Choice();

        if (player == 1)
        {
            left = KeyCode.J;
            right = KeyCode.L;
            jump = KeyCode.I;
            attack = KeyCode.Semicolon;
            GetComponent<Transform>().position = new Vector3(Screen.width / 32, Screen.height / 64, 0);
        }
        else
        {
            left = KeyCode.A;
            right = KeyCode.D;
            jump = KeyCode.W;
            attack = KeyCode.F;
            GetComponent<Transform>().position = new Vector3(-Screen.width / 32, Screen.height / 64, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (start && (player == 1))
        {
            gameController.gameModel.player1.facingLeft(true);
            start = false;
        }
        else if (start)
        {
            gameController.gameModel.player1.facingLeft(false);
            start = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            singleJumped = false;
            doubleJumped = false;
        }

        if ((gameController.gameModel.player1.getState() != 2) && Input.GetKeyDown(jump)) { //jump button subject to change
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
        if((gameController.gameModel.player1.getState() != 2) && Input.GetKey(right))
            {
            GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x + RunSpeed, GetComponent<Rigidbody2D>().position.y);
            gameController.gameModel.player1.facingLeft(false);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(RunSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if(((gameController.gameModel.player1.getState() != 2) && Input.GetKey(left)))
            {
                GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x - RunSpeed, GetComponent<Rigidbody2D>().position.y);
                gameController.gameModel.player1.facingLeft(true);
                //GetComponent<Rigidbody2D>().velocity = new Vector2(-RunSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        if (gameController.gameModel.player1.getLives() <= 0)
        {
            gameController.gameModel.player1.setState("Dead");
        }
        else
        {


            if ((GetComponent<Rigidbody2D>().velocity.y < Mathf.Abs(2)) && (Input.GetKey(left) || Input.GetKey(right)) && (!Input.GetKey(attack)))
            {
                gameController.gameModel.player1.setState("Running");
            }
            if ((!(Input.GetKey(left) || Input.GetKey(right) || Input.GetKey(attack)) && (GetComponent<Rigidbody2D>().velocity.y == 0)))
            {
                gameController.gameModel.player1.setState("Idle");
            }
            if ((!(Input.GetKey(attack)) && GetComponent<Rigidbody2D>().velocity.y != 0))
            {
                gameController.gameModel.player1.setState("Jumping");
            }
            if (Input.GetKeyDown(attack)){

                gameController.gameModel.player1.setState("Attacking");
            }
        }


       

    }
	
}

