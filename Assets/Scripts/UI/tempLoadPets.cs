using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempLoadPets : MonoBehaviour
{


    public Button playButton;

    void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayClicked);
    }

    public void PlayClicked()
    {
        Player.instance.setWithinIndex(new Jesus(), 0);
        Player.instance.setWithinIndex(new Jesus(), 1);
        Player.instance.setWithinIndex(new NutCracker(), 1);
        Player.instance.setWithinIndex(new Jesus(), 2);
        Player.instance.setWithinIndex(new Jesus(), 3);
        Player.instance.setWithinIndex(new Jesus(), 4);

        ShopHandler.instance.LoadPlayerPets();

    }
}

