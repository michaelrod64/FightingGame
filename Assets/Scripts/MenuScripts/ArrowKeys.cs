using UnityEngine;
using System.Collections;

public class ArrowKeys : MonoBehaviour {

    public int[] Selections = { 0, 1, 2, 3 };
    public int currentSelection;
    public bool noneSelected = false;



    public void OverRideSelection(int selection)
    {
        currentSelection = selection;
    }
    public void SelectNone(bool selected)
    {
        noneSelected = selected;
    }
    public bool getSelectNone()
    {
        return noneSelected;
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentSelection = Selections[(currentSelection + 1) % Selections.Length];
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSelection == 0)
                currentSelection = Selections.Length - 1;
            else
            {
                currentSelection--;
            }
        }
	}
    public int getCurrentSelection()
    {
        return currentSelection;
    }
}
