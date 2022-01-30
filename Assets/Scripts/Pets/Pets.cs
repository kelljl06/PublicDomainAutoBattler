using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pets
{
    public int ID;
    public int HP;
    public int ATK;
    public int SPD;

    public int Base_HP = 1;
    public int Base_ATK = 1;
    public int Base_SPD = 1;

    public string prefab;

    public Pets()
    {

    }
    

    public Pets(int pID, int pHP, int pATK, int pSPD)
    {
        ID = pID;
        HP = pHP;
        ATK = pATK;
        SPD = pSPD;
    }

    override public string ToString()
    {
        return "("+ID.ToString()+","+ATK.ToString()+","+SPD.ToString()+","+HP.ToString()+")";
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
        SPD = pSPD;
    }



    public int getBaseHP()
    {
        return Base_HP;
    }
    public int getBaseATK()
    {
        return Base_ATK;
    }
    public int getBaseSPD()
    {
        return Base_SPD;
    }

    public void setBaseHP(int pHP)
    {
        Base_HP = pHP;
    }
    public void setBaseATK(int pATK)
    {
        Base_ATK = pATK;
    }
    public void setBaseSPD(int pSPD)
    {
        Base_SPD = pSPD;
    }

    public string getPrefab()
    {
        return prefab;
    }

    public void setPrefab(string pFAB)
    {
        prefab = pFAB;
    }


}