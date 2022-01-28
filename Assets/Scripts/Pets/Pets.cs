using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pets
{
    public int ID;
    public int HP;
    public int ATK;
    public int SPD;

    public Pets(int pID, int pHP, int pATK, int pSPD)
    {
        ID = pID;
        HP = pHP;
        ATK = pATK;
        SPD = pSPD;
    }


    public int getID()
    {
        return ID;
    }
    public int getHP()
    {
        return HP;
    }
    public int getATK()
    {
        return ATK;
    }
    public int getSPD()
    {
        return SPD;
    }

    public void setID(int pID)
    {
        ID = pID;
    }
    public void setHP(int pHP)
    {
        HP = pHP;
    }
    public void setATK(int pATK)
    {
        ATK = pATK;
    }
    public void setSPD(int pSPD)
    {
        ID = SPD;
    }




}