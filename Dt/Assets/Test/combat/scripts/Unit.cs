using UnityEngine;
using System;
/*
 	HP -> health points 
	MP -> move points
	AP -> attack power
	DP -> defense power
	SP -> speed
*/

public class Unit
{
    public string NAME;
    public int HP;
    public int MAXHP;
    public int MP;
    public int MAXMP;
    public int AP;
    public int DP;
    public int SP;
    public int CASILLA;


    public Unit()
    {
        NAME = "";
        HP = 0;
        MAXHP = 0;
        MP = 0;
        MAXMP = 0;
        AP = 0;
        DP = 0;
        SP = 0;
        CASILLA = 0;
    }

    public Unit(string nAME, int hP, int mAXHP, int mP, int mAXMP, int aP, int dP, int sP ,int cASILLA)
    {
        NAME = nAME;
        HP = hP;
        MAXHP = mAXHP;
        MP = mP;
        MAXMP = mAXMP;
        AP = aP;
        DP = dP;
        SP = sP;
        CASILLA = cASILLA;
    }

}

