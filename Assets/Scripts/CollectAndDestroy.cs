using UnityEngine;
using System.Collections;

public class CollectAndDestroy : GameControllerInterface {

    public int addNumber;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<Player1Input>() == null && other.GetComponent<Player2Input>() == null)
            return;
        else if(CompareTag("treasure"))
        {
           // gameController.addAmmo(1, 1); // how to select player??
                                          // how to access gamecontroller?
            Destroy(gameObject);
        }
        else if(CompareTag("potion"))
        {

            if (other.GetComponent<Player1Input>() != null)
            {
                gameController.addLives(1, 1);
            }
            else
            {
                gameController.addLives(1, 2);
            }
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
