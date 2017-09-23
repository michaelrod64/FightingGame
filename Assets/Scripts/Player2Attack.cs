using UnityEngine;
using System.Collections;

public class Player2Attack : GameControllerInterface
{

    private bool attacking = false;
    private float animationDuration = .15f;
    private float timer = 0;
    public Collider2D trigger;

    public bool invincible = false;
    public bool swordClash = false;


    private Animator animator;

    GameObject PersistentDataObject;
    PersistentData playerData;
    int player;

    KeyCode left;
    KeyCode right;
    KeyCode jump;
    KeyCode attack;

    int frameCount;
    





    // Use this for initialization
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        trigger = GetComponent<BoxCollider2D>();
        trigger.enabled = false;

        PersistentDataObject = GameObject.Find("PersistentDataObject");
        playerData = PersistentDataObject.GetComponent<PersistentData>();
        player = playerData.getPlayer2Choice();

        if (player == 1)
        {
            left = KeyCode.J;
            right = KeyCode.L;
            jump = KeyCode.I;
            attack = KeyCode.Semicolon;
          
        }
        else
        {
            left = KeyCode.A;
            right = KeyCode.D;
            jump = KeyCode.Space;
            attack = KeyCode.F;
           
        }




    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.gameModel.player2.isInvincible())
        {
            StartCoroutine(InvincibleMethod(GetComponent<Collider2D>(), false));
        }

        if (attacking == false && Input.GetKeyDown(attack))
        {
            attacking = true;
            timer = animationDuration;
            trigger.enabled = true;
        }
        

        if (attacking == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                swordClash = false;
                trigger.enabled = false;
            }
        }
    }

    //if both sword and player, don't remove a life
    //count frames in here, and don't do anything until you count 5 frames
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sword") frameCount++;
        if (frameCount > 5)
        {

        }
    }

    //mark colliding with sword, mark colliding with player

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Player1Attack>() == null && other.GetComponent<Player1Input>() == null)
            return;


        
        else if (other.GetComponent<Player1Attack>() != null)
        {
            swordClash = true;
            if (gameController.gameModel.player1.getFacingLeft())
                other.GetComponentInParent<Player1Input>().GetComponent<Rigidbody2D>().velocity = new Vector3(100, 0, 0);

            else
            {
                other.GetComponentInParent<Player1Input>().GetComponent<Rigidbody2D>().velocity = new Vector3(-100, 0, 0);
            }
        }

        




        else if (other.GetComponent<Player1Input>() != null && swordClash == false)
        {

            if (!gameController.gameModel.player1.isInvincible())
            {

                gameController.addLives(-1, 1);

                if (gameController.gameModel.player2.getFacingLeft())
                    other.GetComponentInParent<Player1Input>().GetComponent<Rigidbody2D>().velocity = new Vector3(-50, 100, 0);

                else
                {
                    other.GetComponentInParent<Player1Input>().GetComponent<Rigidbody2D>().velocity = new Vector3(50, 100, 0);
                }
                if (gameController.gameModel.player1.getLives() > 0)
                {
                    gameController.gameModel.player1.setInvincible(true);
                }

            }


        }
       


            
   }
    public IEnumerator InvincibleMethod(Collider2D other, bool player1)
    {
        if (player1)
        {
            if (gameController.gameModel.player1.isInvincible())
            {

                float i;
                for (i = 0; i < 2; i += .2f)
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
                for (i = 0; i < 2; i += .2f)
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


    public IEnumerator InvincibleMethod(Collider2D other)
    {

        if (gameController.gameModel.player1.isInvincible())
        {
            float i;
            for (i = 0; i < 2; i += .2f)
            {
                other.GetComponentInParent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(.1f);
                other.GetComponentInParent<SpriteRenderer>().enabled = true;
                yield return new WaitForSeconds(.1f);
            }
            gameController.gameModel.player1.setInvincible(false);
            
        }
    }


}



