using UnityEngine;
using System.Collections;

//information about player
public class PlayerModel {

    public int lives = 3;
    public  int bullets = 4;
    public int[] states = { 0, 1, 2, 3, 4};
    public bool left = false;
    public string[] stateStrings = { "Idle", "Running", "Dead", "Jumping", "Attacking" };
    public int state = 0;
    public bool invincible = false;

    // Use this for initialization
  

    public bool isInvincible()
    {
        return invincible;
    }
    public void setInvincible(bool invincible)
    {
        this.invincible = invincible;
    }


    public void facingLeft(bool isLeft)
    {
        left = isLeft;
    }   
    public bool getFacingLeft()
    {
        return left;
    }

    public void setState(string stateString)
    {
        if(stateString.Equals("Idle"))
        {
            state = states[0];
        }
        else if(stateString.Equals("Running"))
        {
            state = states[1];
        }
        else if (stateString.Equals("Dead"))
        {
            state = states[2];
        }
        else if (stateString.Equals("Jumping"))
        {
            state = states[3];
        }
        else if (stateString.Equals("Attacking"))
        {
            state = states[4];
        }
    }
    public int getState()
    {
        return state;
    }
    public string getStateString()
    {
        return stateStrings[state];
    }

    public int getLives()
    {
        return lives; 
    } 
    public int addLives(int life)
    {
        if (life < 0 && lives > 0)
        {
            lives += life;
        }
        else if(life > 0)
        {
            lives += life;
        }
        return lives;
    }
    
    public int getBullets()
    {
        return bullets;
    }
    public int addBullets(int ammo)
    {
        bullets += ammo;
        return bullets;
    }
}
