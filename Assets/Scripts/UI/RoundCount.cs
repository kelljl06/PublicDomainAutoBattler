using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCount : MonoBehaviour
{

    public Text roundCount;

    void Update()
    {
        roundCount.text = Player.instance.rounds.ToString();
    }
}
