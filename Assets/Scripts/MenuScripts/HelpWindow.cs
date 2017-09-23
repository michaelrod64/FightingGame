using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HelpWindow : MonoBehaviour
{
    public bool openWindow = false;

    
    private Rect windowRect = new Rect(0, 0, 400, 400);
    void OnGUI()
    {
        if(openWindow)
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "Help");
    }
    void DoMyWindow(int windowID)
    {
        //GUI.Label(new Rect(20, 0, 100, 50), "Help");

        //GUI.DragWindow(new Rect(50, 0, 400, 20));
       // GUI.DragWindow(new Rect(0, 20, 400, 380));
        GUI.Label(new Rect(20, 20, 400, 400), "Story: Two elite warriors have challenged each other to a duel, to see once and for all who is the greatest fighter in all the land.\n\nControls:\n\nPlayer1:\nMove Left: A\nMove Right: D\nJump: W (press in midair to double jump!)\nAttack: F\n\nPlayer2:\nMove Left: J\nMove Right: L\nJump: I (Press in midair to double jump!)\nAttack: ; (Semicolon)");
     
        if (GUI.Button(new Rect(0, 0, 50, 20), "Close") || Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponentInParent<ArrowKeys>().SelectNone(false);
            openWindow = false;
            
        }
            
    }
    public void OpenWindow()
    {
        if (!GetComponentInParent<ArrowKeys>().getSelectNone())
        {
            openWindow = true;
            GetComponentInParent<ArrowKeys>().SelectNone(true);
        }
    }
}



