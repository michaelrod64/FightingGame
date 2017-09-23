using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour {

    public int player1Choice;
    public int player2Choice;
    public bool player1Confirm;
    public bool player2Confirm;
    public bool stageConfirm;
    public bool isMultiplayer;

    public void SetStageConfirm(bool confirmed)
    {
        stageConfirm = confirmed;
    }
    public bool GetStageConfirm()
    {
        return stageConfirm;
    }



    public void SetPlayer1Confirm(bool confirmed)
    {
        player1Confirm = confirmed;
    }
    public bool GetPlayer1Confirm()
    {
        return player1Confirm;
    }
    public void SetPlayer2Confirm(bool confirmed)
    {
        player2Confirm = confirmed;
    }
    public bool GetPlayer2Confirm()
    {
        return player2Confirm;
    }
    public void setMultiplayer(bool isMultiplayer)
    {
        this.isMultiplayer = isMultiplayer;
    }
    public bool getMultiplayer()
    {
        return isMultiplayer;
    }






    public void setPlayer1Choice(int choice)
    {
        player1Choice = choice;
    }
    public void setPlayer2Choice(int choice)
    {
        player2Choice = choice;
    }


    public int getPlayer1Choice()
    {
        return player1Choice;
    }
    public int getPlayer2Choice()
    {
        return player2Choice;
    }



	// Use this for initialization
	void Awake () {

        DontDestroyOnLoad(this);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
