using UnityEngine;
using System.Collections;

public class Player1Animation : GameControllerInterface
{

    string state;
    Animator animator;
    GameController gamecontroller;
    Vector3 left = new Vector3(-1, 1, 1);
    Vector3 right = new Vector3(1, 1, 1);

    // Use this for initialization
    void Awake () {
        animator = GetComponent<Animator>();
       



    }

    // Update is called once per frame
    void Update() {



        if (gameController.gameModel.player1.getFacingLeft())
        {
            GetComponent<Transform>().localScale = left;
        }
        else
        {
            GetComponent<Transform>().localScale = right;
        }

            state = gameController.gameModel.player1.getStateString();


            if (state.Equals("Idle"))
            {
                animator.SetInteger("State", 0);
           
            }
            if (state.Equals("Running")) {
                animator.SetInteger("State", 1);
           
            }
            if (state.Equals("Jumping"))
            {
                animator.SetInteger("State", 3);
          
            }
            if (state.Equals("Dead"))
            {
                animator.SetInteger("State", 2);
           
            
            }
            if (state.Equals("Attacking"))
            {
                animator.SetInteger("State", 4);
                
            }
      }
}

