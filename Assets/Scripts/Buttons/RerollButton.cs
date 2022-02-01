using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RerollButton : MonoBehaviour
{

    public Button rerollButton;
    void Start()
    {
        Button btn = rerollButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayClicked);
    }
    public void PlayClicked()
    {
        ShopHandler.instance.ShopRefresh();
    }
}
