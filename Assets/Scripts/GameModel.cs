using UnityEngine;
using System.Collections;


//Information about game
public class GameModel
{
    public PlayerModel player1 = new PlayerModel();
    public PlayerModel player2 = new PlayerModel();
    public bool musicOn = true;
    //public double cloudNumber = 3;
    /*
        Tips for MVC
        GameModel is a model
        PlayerModel is a model, they just contain data and info


        Whatever controls the UI contacts the model to obtain the state
        and modifies the view, which in this case are the unity ui elements
        (aka a Controller)
    */
    public enum TYPE
    {
        GAMEOVER, PLAY, PAUSE
    };
    private static TYPE _currentState = TYPE.PLAY;
    private static TYPE _previousState = TYPE.PLAY;

    public TYPE currentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            _previousState = _currentState;
            _currentState = value;
        }
    }
    public TYPE previousState
    {
        get
        {
            return _previousState;
        }
    }
    public int getBullets(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1: return player1.getBullets();
            default: return player2.getBullets();

        }
    }

    public void toggleMusic()
    {
        musicOn = !musicOn;
    }
    /*
    public void addCloud()
    {
        cloudNumber++;
    }
    public void removeCloud()
    {
        cloudNumber--;
    }
    public double getCloudNumber()
    {
        return cloudNumber;
    }
    //return PlayerModel
    */



    /*
        public static TYPE setState(TYPE newState)
        {
            var previousState = currentState;
            currentState = newState;
            return previousState;
        }



        public static TYPE getState()
        {
            return currentState;
        }
        */



}