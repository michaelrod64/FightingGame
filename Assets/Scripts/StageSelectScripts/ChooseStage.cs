using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseStage : MonoBehaviour {

    public Sprite[] sprites; //= new Sprite[2];
    public int spriteNum;
    public KeyCode left1;
    public KeyCode left2;
    public KeyCode right1;
    public KeyCode right2;
    public KeyCode confirm1;
    public KeyCode confirm2;
    public KeyCode back1;
    public KeyCode back2;
    public SpriteRenderer player;
    public bool player1;
    bool chosen;
    GameObject PersistentDataObject;
    PersistentData playerData;
    


    // Use this for initialization
    void Awake () {
        PersistentDataObject = GameObject.Find("PersistentDataObject");
        playerData = PersistentDataObject.GetComponent<PersistentData>();
        player = GetComponent<SpriteRenderer>();

        player.sprite = sprites[spriteNum];
        //player.sprite.
      
       

    }
	void OnGUI()
    {

        //if(Input.GetKey(KeyCode.A))
    }




	// Update is called once per frame
	void Update () {
        if (!chosen) {
            if (Input.GetKeyDown(right1) || Input.GetKeyDown(right2))
            {
                spriteNum = (spriteNum + 1) % sprites.Length;
                player.sprite = sprites[spriteNum];
                
            }
            if (Input.GetKeyDown(left1) || Input.GetKeyDown(left2))
            {
                if (spriteNum == 0)
                {
                    spriteNum = sprites.Length - 1;
                    player.sprite = sprites[spriteNum];
                    
                }
                else
                {
                    spriteNum--;
                    player.sprite = sprites[spriteNum];
                    
                }
            }
        }
        if(Input.GetKeyDown(confirm1) || Input.GetKeyDown(confirm2))
        {
            playerData.SetStageConfirm(true);
            for(int i = 0; i <= 10; i++)
            {
                if (i >= 10)
                {
                    SceneManager.LoadScene(spriteNum + 3);
                }
            }

        }


        /*
       if(player1)
        {
            if(playerData.GetPlayer2Confirm())
            {
                chosen = true;
                playerData.SetPlayer1Confirm(true);
                spriteNum = (playerData.getPlayer2Choice() + 1) % sprites.Length;
                player.sprite = sprites[spriteNum];
                playerData.setPlayer1Choice(spriteNum);
            }
        }
       else
        {
            if(playerData.GetPlayer1Confirm())
            {
                chosen = true;
                playerData.SetPlayer2Confirm(true);
                spriteNum = (playerData.getPlayer1Choice() + 1) % sprites.Length;
                player.sprite = sprites[spriteNum];
                playerData.setPlayer2Choice(spriteNum);
            }
        }

        if(Input.GetKeyDown(confirm1))
        {
            chosen = true;

            if (player1) {
                playerData.SetPlayer1Confirm(true);
                playerData.setPlayer1Choice(spriteNum);
            }
            else { 
                playerData.setPlayer2Choice(spriteNum);
                playerData.SetPlayer2Confirm(true);
            }
        }
        */
        


	}
}
