using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShopPet4Button : MonoBehaviour
{

    public Button ShopPet;

    void Start()
    {
        Button btn = ShopPet.GetComponent<Button>();
        btn.onClick.AddListener(PlayClicked);
    }

    public void PlayClicked()
    {
        ShopPetClicked.instance.setplayerSpot(3);

    }
}
