using UnityEngine;
using System.Collections;

public class PlayerInZone : MonoBehaviour {

    public bool Player1InZone;
    public bool Player2InZone;


    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.GetComponent<Player2Input>() == null && other.GetComponent<Player1Input>() == null)
            return;

        
        else if (other.GetComponent<Player2Input>() != null)
        {
            Player2InZone = true;
        }
        else
        {
            Player1InZone = true;
        }

        //Debug.Log("Entered");
    }
    void OnTriggerExit2D(Collider2D other)
    {

        Debug.Log("exited");

        if (other.GetComponent<Player2Input>() == null && other.GetComponent<Player1Input>() == null)
            return;
        else if (other.GetComponent<Player2Input>() != null)
        {
            Player2InZone = false;
        }
        else
        {
            Player1InZone = false;
        }
    }




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
