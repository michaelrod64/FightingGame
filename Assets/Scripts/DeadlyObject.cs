using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeadlyObject : GameControllerInterface
{

    public Text text;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player1Input>() == null && other.GetComponent<Player2Input>() == null)
            return;
        if (other.GetComponent<Player1Input>() != null)
        {
            if (!gameController.gameModel.player1.isInvincible())
            {
                gameController.addLives(-1, 1);

                if (gameController.gameModel.player1.getLives() > 0)
                {
                    gameController.gameModel.player1.setInvincible(true);
                   // StartCoroutine(InvincibleMethod(other, true));
                    //other.GetComponentInChildren<Player1Attack>().InvincibleMethod(other,true);
                }


            }
          
        }
        else
        {
            if (!gameController.gameModel.player2.isInvincible())
            {
                gameController.addLives(-1, 2);

                if (gameController.gameModel.player2.getLives() > 0)
                {
                    //other.GetComponentInChildren<Player2Attack>().InvincibleMethod(other, false);
                    gameController.gameModel.player2.setInvincible(true);
                    
                   // StartCoroutine(InvincibleMethod(other, false));
                }
            }
        }
            

        //GameState.TYPE a = GameState.TYPE.GAMEOVER;

        if(gameController.gameModel.player1.getLives() <= 0 || gameController.gameModel.player2.getLives() <= 0)
        gameController.gameModel.currentState = GameModel.TYPE.GAMEOVER;
        //if(GameState.currentState == GameState.TYPE.GAMEOVER)

            //yield return new WaitForSeconds(5);
        
    /*
        else if (CompareTag("treasure"))
        {
            LifeAmmoManager.changeAmmo(1);
            Destroy(gameObject);
        }
        else if (CompareTag("potion"))
        {
            LifeAmmoManager.changeLives(1);
            Destroy(gameObject);
        }
        */
    }
    /*
    IEnumerator InvincibleMethod(Collider2D other, bool player1)
    {
        if (player1)
        {

            if (gameController.gameModel.player1.isInvincible())
            {
                float i;
                for (i = 0; i < 3; i += .2f)
                {
                    other.GetComponentInParent<SpriteRenderer>().enabled = false;
                    yield return new WaitForSeconds(.1f);
                    other.GetComponentInParent<SpriteRenderer>().enabled = true;
                    yield return new WaitForSeconds(.1f);
                }
                gameController.gameModel.player1.setInvincible(false);

            }
        }
        else
        {
            if (gameController.gameModel.player2.isInvincible())
            {
                float i;
                for (i = 0; i < 3; i += .2f)
                {
                    other.GetComponentInParent<SpriteRenderer>().enabled = false;
                    yield return new WaitForSeconds(.1f);
                    other.GetComponentInParent<SpriteRenderer>().enabled = true;
                    yield return new WaitForSeconds(.1f);
                }
                gameController.gameModel.player2.setInvincible(false);
            }
        }
    }
    */




}













