using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controls game
public class GameController : MonoBehaviour {
    //GAMEMANAGER/CONTROLLER

    //map from gamestate.TYPE to string
    public const string empty = "";
    public const string gameOver = "GAMEOVER";

    

    public Text livesTextP1;
    public Text ammoTextP1;

    public Text livesTextP2;
    public Text ammoTextP2;

    public Text gameOverText;

    public GameModel gameModel;
    KeyCode pause = KeyCode.Escape;
    GameObject Buttons;
    GameObject persistentData;
    GameObject AIObject;

    PersistentData playerData;
    int playerchoice;
    GameObject PersistentDataObject;


    bool firstTime;
    public bool endGame = false;
    bool isMultiplayer;

    void Start()
    {
        Buttons = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
        
        gameModel = new GameModel();
        GetComponent<AudioSource>().Play();
        persistentData = GameObject.Find("CrossSceneData");
        
        AIObject = GameObject.Find("Players");
        firstTime = true;
        endGame = false;
        Time.timeScale = 1.0f;
        PersistentDataObject = GameObject.Find("PersistentDataObject");
        playerData = PersistentDataObject.GetComponent<PersistentData>();
        playerchoice = playerData.getPlayer1Choice();
        isMultiplayer = persistentData.GetComponent<PersistentData>().getMultiplayer();

    }
    void Update()
    {
        if (gameModel.player1.getLives() <= 0 || gameModel.player2.getLives() <= 0)
        {
            gameModel.currentState = GameModel.TYPE.GAMEOVER;
        }



        /*
        if(!endGame && !Buttons.activeSelf)
        {
            Time.timeScale = 1.0f;
        }
        */

        if ((SceneManager.GetActiveScene().buildIndex == 3)  && isMultiplayer)
        {
            AIObject.GetComponent<AIBehavior>().enabled = false;
            firstTime = false;
        }
        else if((SceneManager.GetActiveScene().buildIndex == 3) && !isMultiplayer)
        {
            AIObject.GetComponent<AIBehavior>().enabled = true;
            firstTime = false;
        }


        AudioSource music = GetComponent<AudioSource>();

        if (gameModel.currentState == GameModel.TYPE.GAMEOVER)
        {
           

            if (gameModel.player1.getLives() <= 0 && gameModel.player2.getLives() <= 0)
            {
               
                if (playerchoice == 1)
             
                    gameOverText.text = "It's a tie!";
            }
            else if(gameModel.player1.getLives() <= 0)
            {
                if (playerchoice == 0)
                {
                    gameOverText.text = "Player2 Wins!";
                }
                else
                {
                    gameOverText.text = "Player1 Wins!";
                }
            }
            else if(gameModel.player2.getLives() <= 0)
            {
                if (playerchoice == 0)
                {
                    gameOverText.text = "Player1 Wins!";
                }
                else
                {
                    gameOverText.text = "Player2 Wins!";
                }


            }

            Time.timeScale = 0.0f;
            endGame = true;
            gameModel.currentState = GameModel.TYPE.PLAY;


            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //doesn't restart the scene correctly
        }
        else
        {
            gameOverText.text = "";
        }


        if(Input.GetKeyDown(KeyCode.M)) {
            gameModel.toggleMusic();
        }
        if(gameModel.musicOn && !music.isPlaying)
        {
            music.Play();
        }
        if(!gameModel.musicOn && music.isPlaying)
        {
            music.Pause();
        }
        /*
        if(gameModel.currentState == GameModel.TYPE.PLAY && Input.GetKeyDown(pause))
        {

            GameObject.Find("ResumeObject").GetComponent<ClickResume>().resume();
            gameModel.currentState = GameModel.TYPE.PAUSE;
            Time.timeScale = 0.0f;
            
        }
        if(gameModel.currentState == GameModel.TYPE.PAUSE && Input.GetKeyDown(pause))
        {
            GameObject.Find("ResumeObject").GetComponent<ClickResume>().resume();
            Time.timeScale = 1.0f;
            gameModel.currentState = GameModel.TYPE.PLAY;
        }
        */





        /*if(gameModel.currentState == GameModel.TYPE.PLAY)
        {
            
        }
        */


       
    }
    

    public void addLives(int life, int player)
    {
        switch(player)
        {
            case 1:
                if (playerchoice == 0)
                {
                    gameModel.player1.addLives(life);
                    livesTextP1.text = "" + gameModel.player1.getLives();
                }
                else
                {
                    gameModel.player1.addLives(life);
                    livesTextP2.text = "" + gameModel.player1.getLives();
                }
                break;
            default:

                if (playerchoice == 0)
                {
                    gameModel.player2.addLives(life);
                    livesTextP2.text = "" + gameModel.player2.getLives();
                }
                else
                {
                    gameModel.player2.addLives(life);
                    livesTextP1.text = "" + gameModel.player2.getLives();
                }
                break;
        }
       
    }
   /* public bool needClouds()
    {
        GameModel newgameModel = gameModel;

        //int clouds = gameModel.getCloudNumber();

        //if (clouds < 5)
            return true;

        //return false;
    }
    public void addClouds()
    {

        gameModel.cloudNumber++;
    }
    */
    /*
    public void addAmmo(int bullets, int player)
    {
        switch (player)
        {
            case 1:
                gameModel.player1.addBullets(bullets);
                ammoTextP1.text = "" + gameModel.player1.getBullets();
                break;
            default:
                gameModel.player2.addBullets(bullets);
                ammoTextP2.text = "" + gameModel.player2.getBullets();
                break;
        }
    }
    */
    void restartValues()
    {
        gameModel = new GameModel();
        //addAmmo(0, 1);
       // addAmmo(0, 2);
        addLives(0, 1);
        addLives(0, 2);
    }

   



}
