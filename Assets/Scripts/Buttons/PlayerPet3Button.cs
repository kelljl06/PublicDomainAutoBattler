using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPet3Button : MonoBehaviour
{

    public Button PlayerPet;

    void Start()
    {
        Button btn = PlayerPet.GetComponent<Button>();
        btn.onClick.AddListener(PlayClicked);
    }

    public void PlayClicked()
    {
        if (ShopPetClicked.instance.isSelected) {
            ShopHandler.instance.PurchasePet(ShopPetClicked.instance.playerSpot, 2);
            ShopPetClicked.instance.Clear();
        }
        else
        {
            ShopPetClicked.instance.SwapRoster(2);
        }
    }
}