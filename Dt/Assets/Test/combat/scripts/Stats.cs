using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stats : MonoBehaviour
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

    /// <summary>
    /// Heals itself for teh amount up to MAXHP
    /// </summary>
    /// <param name="amount"></param>
    public void Heal(int amount)
    {
        int life = HP + amount;
        if (life > MAXHP)
        {
            HP = MAXHP;
        }
        else
        {
            HP = life;
        }
    }
    public bool Damage(int Ap)
    {
        int damage = Ap - DP;
        if (damage < 0)
        {
            damage = 0;
        }
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return (true);
        }
        return false;
    }


}
