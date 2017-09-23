using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour {

    public Sprite[] sprites; //= new Sprite[2];
    public int spriteNum;
    public KeyCode left;
    public KeyCode right;
    public KeyCode confirm;
    public KeyCode back;
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
            if (Input.GetKeyDown(right))
            {
                spriteNum = (spriteNum + 1) % sprites.Length;
                player.sprite = sprites[spriteNum];
                
            }
            if (Input.GetKeyDown(left))
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

        if(Input.GetKeyDown(confirm))
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
        


	}
}
