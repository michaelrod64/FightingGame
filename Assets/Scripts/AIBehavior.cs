using UnityEngine;
using System.Collections;
using WindowsInput;

public class AIBehavior : MonoBehaviour {



   VirtualKeyCode left = VirtualKeyCode.VK_J;
   VirtualKeyCode right = VirtualKeyCode.VK_L;
    VirtualKeyCode jump = VirtualKeyCode.VK_I;
    VirtualKeyCode attack = VirtualKeyCode.OEM_1;

    public float floorWayPoint;
    public float leftCenterWayPoint1;
    public float leftCenterWayPoint2;
    public float rightCenterWayPoint1;
    public float rightCenterWayPoint2;
    public float rightWayPoint;

    public int TopP1 = 0;
    public int TopP2 = 1;

    public int MiddleLeftP1 = 2;
    public int MiddleLeftP2 = 3;

    public int MiddleCenterRightP1 = 4;
    public int MiddleCenterRightP2 = 5;

    public int MiddleCenterLeftP1 = 6;
    public int MiddleCenterLeftP2 = 7;

    public int MiddleRightP1 = 8;
    public int MiddleRightP2 = 9;

    public int FloorP1 = 10;
    public int FloorP2 = 11;

    public int LeftDeathP1 = 12;
    public int LeftDeathP2 = 13;

    public int RightDeathP1 = 14;
    public int RightDeathP2 = 15;

    public bool sameZone;
    GameObject zonetracker;
    GameObject human;
    GameObject computerObject;
    ZoneTracker zones;

    Transform player1;
    Transform computer;
    public int k;
    // Use this for initialization
    void Start () {
         zonetracker = GameObject.Find("Zones");
         zones = zonetracker.GetComponent<ZoneTracker>();

        computerObject = GameObject.Find("Player2");
        computer = computerObject.GetComponent<Transform>();

        human = GameObject.Find("Player");
        player1 = human.GetComponent<Transform>();

        floorWayPoint = GameObject.Find("floorwaypoint").GetComponent<Transform>().position.x;
        leftCenterWayPoint1 = GameObject.Find("leftcenterwaypoint1").GetComponent<Transform>().position.x;
        leftCenterWayPoint2 = GameObject.Find("leftcenterwaypoint2").GetComponent<Transform>().position.x;
        rightCenterWayPoint1 = GameObject.Find("rightcenterwaypoint1").GetComponent<Transform>().position.x;
        rightCenterWayPoint2 = GameObject.Find("rightcenterwaypoint2").GetComponent<Transform>().position.x;
        rightWayPoint = GameObject.Find("rightwaypoint").GetComponent<Transform>().position.x;
        k = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if((InputSimulator.IsKeyDown(left) || InputSimulator.IsKeyDown(right)) && k > 500)
        {
            InputSimulator.SimulateKeyUp(left);
            InputSimulator.SimulateKeyUp(right);
            k = 0;
        }
        else
        {
            k++;
        }
        
        for (int i = 0; i <= 6; i++)
        {
            if (i != 6 && zones.zoneStatuses[2 * i] && zones.zoneStatuses[(2 * i) + 1])
            {

                sameZone = true;
                break;
            }
            else if (i == 6)
            {
                sameZone = false;
            }
        }
        if (sameZone)
        {

            // StartCoroutine(followAndAttack());

            if (sameZone && Mathf.Abs((player1.position.x - computer.position.x)) < 10)
            {
                if (sameZone && player1.position.x > computer.position.x)
                {
                    //InputSimulator.SimulateKeyUp(left);
                    InputSimulator.SimulateKeyPress(right);
                    InputSimulator.SimulateKeyPress(attack);
                }
                else if(sameZone)
                {
                    //InputSimulator.SimulateKeyUp(right);
                    InputSimulator.SimulateKeyPress(left);
                    InputSimulator.SimulateKeyPress(attack);
                }
            }
            else if (sameZone && player1.position.x > computer.position.x)
            {
                //InputSimulator.SimulateKeyUp(left);
                InputSimulator.SimulateKeyPress(right);
            }
            else if (sameZone && player1.position.x < computer.position.x)
            {
                // InputSimulator.SimulateKeyUp(right);
                InputSimulator.SimulateKeyPress(left);
            }

        }

        else if (zones.zoneStatuses[FloorP2])
        {
            if (zones.zoneStatuses[MiddleCenterRightP1] || zones.zoneStatuses[MiddleRightP1])
            {
                if (Mathf.Abs(computer.transform.position.x - floorWayPoint) < 5)
                {
                    InputSimulator.SimulateKeyUp(left);
                    InputSimulator.SimulateKeyDown(right);
                    InputSimulator.SimulateKeyPress(jump);
                    InputSimulator.SimulateKeyPress(jump);
                    // InputSimulator.SimulateKeyPress(right);
                    //InputSimulator.SimulateKeyPress(right);

                }
                else if (computer.transform.position.x < floorWayPoint)
                {
                    InputSimulator.SimulateKeyPress(right);
                }
                else
                {
                    InputSimulator.SimulateKeyPress(left);
                }
            }
            else if (zones.zoneStatuses[MiddleCenterLeftP1] || zones.zoneStatuses[MiddleLeftP1] || zones.zoneStatuses[TopP1])
            {
                if (Mathf.Abs(computer.transform.position.x - floorWayPoint) < 5)
                {
                    InputSimulator.SimulateKeyUp(right);
                    InputSimulator.SimulateKeyDown(left);
                    InputSimulator.SimulateKeyPress(jump);
                    InputSimulator.SimulateKeyPress(jump);
                    // InputSimulator.SimulateKeyPress(right);
                    //InputSimulator.SimulateKeyPress(right);

                }
                else if ((computer.transform.position.x < floorWayPoint) && (zones.zoneStatuses[MiddleCenterLeftP1] || zones.zoneStatuses[MiddleLeftP1] || zones.zoneStatuses[TopP1]))
                {
                    InputSimulator.SimulateKeyPress(right);
                }
                else if((computer.transform.position.x > floorWayPoint) && (zones.zoneStatuses[MiddleCenterLeftP1] || zones.zoneStatuses[MiddleLeftP1] || zones.zoneStatuses[TopP1]))
                {
                    InputSimulator.SimulateKeyPress(left);
                }
            }
        }
        else if(zones.zoneStatuses[MiddleCenterLeftP2])
        {
            if(zones.zoneStatuses[FloorP1])
            {
                InputSimulator.SimulateKeyPress(right);
            }
            else if(zones.zoneStatuses[MiddleCenterRightP1])
            {
                if(Mathf.Abs(computer.transform.position.x - leftCenterWayPoint2) < 5)
                {
                    InputSimulator.SimulateKeyUp(left);
                    InputSimulator.SimulateKeyDown(right);
                    InputSimulator.SimulateKeyPress(jump);
                    InputSimulator.SimulateKeyPress(jump);
                }
                else if(computer.position.x < leftCenterWayPoint2)
                {
                    InputSimulator.SimulateKeyPress(right);
                }
            }
            else if(zones.zoneStatuses[MiddleLeftP1] || zones.zoneStatuses[TopP1])
            {
                if (Mathf.Abs(computer.transform.position.x - leftCenterWayPoint1) < 5)
                {
                    InputSimulator.SimulateKeyPress(jump);
                    InputSimulator.SimulateKeyUp(right);
                    InputSimulator.SimulateKeyDown(left);
                    InputSimulator.SimulateKeyPress(jump);
                    InputSimulator.SimulateKeyPress(jump);
                }
                else if (computer.position.x > leftCenterWayPoint1)
                {
                    InputSimulator.SimulateKeyPress(left);
                }
            }
        }
        else if (zones.zoneStatuses[MiddleCenterRightP2])
        {
            if (zones.zoneStatuses[FloorP1])
            {
                InputSimulator.SimulateKeyPress(left);
            }
            else if (zones.zoneStatuses[MiddleCenterLeftP1])
            {
                if (Mathf.Abs(computer.transform.position.x - rightCenterWayPoint1) < 5)
                {
                    InputSimulator.SimulateKeyUp(right);
                    InputSimulator.SimulateKeyDown(left);
                    InputSimulator.SimulateKeyPress(jump);
                    InputSimulator.SimulateKeyPress(jump);
                }
                else if (computer.position.x > rightCenterWayPoint1)
                {
                    InputSimulator.SimulateKeyPress(left);
                }
            }
            else if(zones.zoneStatuses[MiddleRightP1])
            {
                if (Mathf.Abs(computer.transform.position.x - rightCenterWayPoint2) < 5)
                {
                    InputSimulator.SimulateKeyUp(left);
                    InputSimulator.SimulateKeyDown(right);
                    InputSimulator.SimulateKeyPress(jump);
                    InputSimulator.SimulateKeyPress(jump);
                }
                else if (computer.position.x < rightCenterWayPoint2)
                {
                    InputSimulator.SimulateKeyPress(right);
                }
            }
        }
        else if(!sameZone && zones.zoneStatuses[MiddleRightP2])
        {
                InputSimulator.SimulateKeyUp(right);
                InputSimulator.SimulateKeyDown(left);
                InputSimulator.SimulateKeyPress(jump);
                InputSimulator.SimulateKeyPress(jump);
        }
        else if(!sameZone && zones.zoneStatuses[MiddleLeftP2])
        {
            InputSimulator.SimulateKeyUp(left);
            InputSimulator.SimulateKeyDown(right);
            InputSimulator.SimulateKeyPress(jump);
            StartCoroutine(secondJump());
           // InputSimulator.SimulateKeyPress(jump);
        }
        else if(!sameZone && zones.zoneStatuses[TopP2])
        {
            InputSimulator.SimulateKeyPress(right);
        }



        else if(zones.zoneStatuses[LeftDeathP2])
        {
            InputSimulator.SimulateKeyUp(left);
            InputSimulator.SimulateKeyPress(jump);
            InputSimulator.SimulateKeyDown(right);
        }
        else if (zones.zoneStatuses[RightDeathP2])
        {
            InputSimulator.SimulateKeyUp(right);
            InputSimulator.SimulateKeyPress(jump);
            InputSimulator.SimulateKeyDown(left);
        }















        //StartCoroutine(jumpToRight());



        // } 
        //}
        /* else
         {
             InputSimulator.SimulateKeyUp(left);
             InputSimulator.SimulateKeyUp(right);
         }
         */


        /*
             IEnumerator jumpToRight()
         {
             while (zones.zoneStatuses[FloorP2] && zones.zoneStatuses[MiddleCenterLeftP1])
             {

                 if (Mathf.Abs(computer.position.x - HalfScreenWidth) < 20)
                 {
                     InputSimulator.SimulateKeyPress(right);
                     InputSimulator.SimulateKeyPress(jump);
                     yield return new WaitForSeconds(.5f);
                     InputSimulator.SimulateKeyPress(jump);
                 }

                 else if (computer.position.x >= HalfScreenWidth)
                 {
                     //InputSimulator.SimulateKeyUp(right);
                     InputSimulator.SimulateKeyPress(left);
                     Debug.Log("left");
                 }
                 else if (computer.position.x < HalfScreenWidth - 20)
                 {
                     // InputSimulator.SimulateKeyUp(left);
                     InputSimulator.SimulateKeyPress(right);
                     Debug.Log("right");
                 }
             }







             //InputSimulator.SimulateKeyUp(right);
         }
         */
    }
    IEnumerator secondJump()
    {
        yield return new WaitForSeconds(.5f);
        InputSimulator.SimulateKeyPress(jump);
    }
}
