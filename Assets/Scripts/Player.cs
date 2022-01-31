using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static List<Pets> PlayerHand = new  List<Pets>();

    public static Player instance;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    public Pets getWithinIndex(int index) {
        return PlayerHand[index];
    }

    public void setWithinIndex(Pets pet, int index)
    {
        PlayerHand.Insert(index, pet);
    }




}
