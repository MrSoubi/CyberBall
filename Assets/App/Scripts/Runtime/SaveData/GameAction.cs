using System;
using UnityEngine;

[System.Serializable]
public class GameAction
{
    public string playerID;
    public PlayerGender gender;

    [Space(10)]
    public string actionTime;
    public string elem1, elem2, elem3, elem4;

    public GameAction(string e1)
    {
        this.elem1 = e1;

        SetTime();
    }
    public GameAction(string e1, string e2)
    {
        this.elem1 = e1;
        this.elem2 = e2;

        SetTime();
    }
    public GameAction(string e1, string e2, string e3)
    {
        this.elem1 = e1;
        this.elem2 = e2;
        this.elem3 = e3;

        SetTime();
    }
    public GameAction(string e1, string e2, string e3, string e4)
    {
        this.elem1 = e1;
        this.elem2 = e2;
        this.elem3 = e3;
        this.elem4 = e4;

        SetTime();
    }

    void SetTime()
    {
        actionTime = DateTime.Now.ToString("G");
    }
}

public enum PlayerGender
{ 
    Homme = 0,
    Femme = 1,
    Non_Binaire = 2,
    Autre = 3,
    Ne_Se_Prononce_Pas = 4
}