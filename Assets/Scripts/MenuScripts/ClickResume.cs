using UnityEngine;
using System.Collections;

public class ClickResume : MonoBehaviour {

    GameObject buttons;
    GameObject endButtons;
    public GameObject GameControllerObject;
    GameController gameController;
    KeyCode pause = KeyCode.Escape;

    void Start()
    {

        gameController = GameControllerObject.GetComponent<GameController>();
        buttons = GameObject.Find("Buttons");
        buttons.SetActive(false);
        endButtons = GameObject.Find("EndGameButtons");
        endButtons.SetActive(false);
        Time.timeScale = 1.0f;
        //gameController.gameModel.currentState = GameModel.TYPE.PAUSE;

    }


    void Update()
    {
        if(Input.GetKeyDown(pause))
        {
            resume();
        }
        if(gameController.endGame)
        {
            endButtons.SetActive(true);
        }
        else
        {
            endButtons.SetActive(false);
        }
    }

    public void resume()
    {
        
        GameControllerObject = GameObject.Find("GameControllerObject");
        gameController = GameControllerObject.GetComponent<GameController>();

        if (gameController.gameModel.currentState == GameModel.TYPE.PAUSE)
        {
            gameController.gameModel.currentState = GameModel.TYPE.PLAY;
            //buttons = GameObject.Find("Buttons");
            buttons.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            gameController.gameModel.currentState = GameModel.TYPE.PAUSE;
            //buttons = GameObject.Find("Buttons");
            buttons.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }
}
