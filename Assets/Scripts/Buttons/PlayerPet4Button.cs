using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPet4Button : MonoBehaviour
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
            ShopPetClicked.instance.BuySelectedPet(3);
        }
        else
        {
            ShopPetClicked.instance.SwapRoster(3);
        }
    }
}
