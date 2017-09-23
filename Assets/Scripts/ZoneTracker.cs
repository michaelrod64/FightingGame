using UnityEngine;
using System.Collections;

public class ZoneTracker : MonoBehaviour {

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

   

    public bool TopBoolP1;
    public bool TopBoolP2;

    public bool MiddleLeftBoolP1;
    public bool MiddleLeftBoolP2;

    public bool MiddleCenterRightBoolP1;
    public bool MiddleCenterRightBoolP2;

    public bool MiddleCenterLeftBoolP1;
    public bool MiddleCenterLeftBoolP2;

    public bool MiddleRightBoolP1;
    public bool MiddleRightBoolP2;

    public bool FloorBoolP1;
    public bool FloorBoolP2;
















    public GameObject[] zones = new GameObject[8];
    public bool[] zoneStatuses = new bool[16];

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 8; i++)
        {
            zoneStatuses[(2 * i)] = zones[i].GetComponent<PlayerInZone>().Player1InZone;
            zoneStatuses[(2 * i) + 1] = zones[i].GetComponent<PlayerInZone>().Player2InZone;
        }



    }
	
	// Update is called once per frame
	void Update () {

        for(int i = 0; i < 8; i++)
        {
            zoneStatuses[(2 * i)] = zones[i].GetComponent<PlayerInZone>().Player1InZone;
            zoneStatuses[(2 * i) + 1] = zones[i].GetComponent<PlayerInZone>().Player2InZone;
            //if(zoneStatuses[2 * i])

        }

	

                 

	}
}
