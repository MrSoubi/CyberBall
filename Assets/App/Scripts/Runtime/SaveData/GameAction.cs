using System;
using UnityEngine;

[System.Serializable]
public class GameAction
{
    public string actionTime;
    public string elem1, elem2, elem3, elem4;

    public GameAction(string e1)
    {
        this.elem1 = e1;

        actionTime = DateTime.Now.ToString();
    }
    public GameAction(string e1, string e2)
    {
        this.elem1 = e1;
        this.elem2 = e2;

        actionTime = DateTime.Now.ToString();
    }
    public GameAction(string e1, string e2, string e3)
    {
        this.elem1 = e1;
        this.elem2 = e2;
        this.elem3 = e3;

        actionTime = DateTime.Now.ToString();
    }
    public GameAction(string e1, string e2, string e3, string e4)
    {
        this.elem1 = e1;
        this.elem2 = e2;
        this.elem3 = e3;
        this.elem4 = e4;

        actionTime = DateTime.Now.ToString();
    }
}
