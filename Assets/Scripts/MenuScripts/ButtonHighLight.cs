using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEditor;

public class ButtonHighLight : MonoBehaviour {

    public int buttonNumber;


	// Use this for initialization
	void Start () {

        if(buttonNumber == 0)

        GetComponent<Button>().Select();
        
	
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponentInParent<ArrowKeys>().getSelectNone())
        {
            
        }


        if(!GetComponentInParent<ArrowKeys>().getSelectNone() &&  buttonNumber == GetComponentInParent<ArrowKeys>().getCurrentSelection())
        {
            GetComponent<Button>().Select();
        }
        if(!GetComponentInParent<ArrowKeys>().getSelectNone() && buttonNumber == GetComponentInParent<ArrowKeys>().getCurrentSelection() && (Input.GetKeyDown(KeyCode.KeypadEnter) || (Input.GetKeyDown(KeyCode.F))))
        {
            GetComponent<Button>().onClick.Invoke();
        }



	}
}
