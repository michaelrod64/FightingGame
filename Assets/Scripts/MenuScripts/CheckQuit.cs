using UnityEngine;
using System.Collections;

public class CheckQuit : MonoBehaviour {

    public bool openWindow = false;


    private Rect windowRect = new Rect(60, 60, 200, 200);
    void OnGUI()
    {
        if (openWindow)
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Quit");
    }
    void DoMyWindow(int windowID)
    {
        //GUI.Label(new Rect(20, 0, 100, 50), "Help");

        //GUI.DragWindow(new Rect(0, 0, 200, 140));
        //GUI.DragWindow(new Rect(0, 180, 200, 20));
        GUI.Label(new Rect(0, 20, 200, 20), "Are you sure you want to quit? ");

        

        if (GUI.Button(new Rect(40, 150, 50, 20), "NO") || Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponentInParent<ArrowKeys>().SelectNone(false);
            openWindow = false;
           
        }
          
        if(GUI.Button(new Rect(125, 150, 50, 20), "YES") || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Application.Quit();
        }
    }
    public void OpenWindow()
    {
        if(!GetComponentInParent<ArrowKeys>().getSelectNone()) { 
            openWindow = true;
            GetComponentInParent<ArrowKeys>().SelectNone(true);
            }
    }








}
