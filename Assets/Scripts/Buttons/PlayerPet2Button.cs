using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPet2Button : MonoBehaviour
{

    public Button PlayerPet;

    void Start()
    {
        Button btn = PlayerPet.GetComponent<Button>();
        btn.onClick.AddListener(PlayClicked);
    }

    public void PlayClicked()
    {
        if (ShopPetClicked.instance.isSelected)
        {
            ShopPetClicked.instance.BuySelectedPet(1);
        }
        else
        {
            ShopPetClicked.instance.SwapRoster(1);
        }
    }
}
