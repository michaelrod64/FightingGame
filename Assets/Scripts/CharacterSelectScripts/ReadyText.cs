using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyText : MonoBehaviour {

    public bool player1;
    PersistentData playerData;
    GameObject PersistentDataObject;



	// Use this for initialization
	void Awake () {

        //playerData = 
        PersistentDataObject = GameObject.Find("PersistentDataObject");
        playerData = PersistentDataObject.GetComponent<PersistentData>();
          //  GetComponent<PersistentData>();

        

	}
	
	// Update is called once per frame
	void Update () {
        if(player1 && playerData.GetPlayer1Confirm())
        {
            if (playerData.GetPlayer1Confirm())
                GetComponent<Text>().enabled = true;
            else
                GetComponent<Text>().enabled = false;
        }
        else
        {
            if (playerData.GetPlayer2Confirm())
                GetComponent<Text>().enabled = true;
            else
                GetComponent<Text>().enabled = false;
            
        }

	
	}
}
