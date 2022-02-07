using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static List<Pets> PlayerHand = new  List<Pets>();

    public int rounds;
    public int health;
    public string teamName;

    public static Player instance;

    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
            rounds = 1;
            health = 10;
        }
        else if (instance != this) { 
        
        }

    }


    public List<Pets> getHand()
    {
        return PlayerHand;
    }

    public void setHand(List<Pets> petArray) {
        PlayerHand = petArray;
    }

    public Pets getWithinIndex(int index) {
        return PlayerHand[index];
    }

    public void setWithinIndex(Pets pet, int index)
    {
        if (index < PlayerHand.Count)
            PlayerHand.RemoveAt(index);
        PlayerHand.Insert(index, pet);

    }

    public void setHealth(int newHealth) {
        health = newHealth;
    }

    public int getHealth()
    {
        return health;
    }

    public void setHelth(int total) {
        health = health - total;
    }

    public void setTeamName(string name)
    {
        teamName = name;
    }

    public string getTeamName()
    {
        return teamName;
    }





}
