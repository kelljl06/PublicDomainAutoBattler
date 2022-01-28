using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundDisplay : MonoBehaviour
{
    private int round = 7;
    public Text roundText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = round.ToString();

        if (Input.GetKeyDown(KeyCode.P))
            round--;
    }
}
