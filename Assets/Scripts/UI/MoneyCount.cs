using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour
{

    public Text coinCount;

    void Update()
    {
        coinCount.text = ShopPetClicked.instance.money.ToString();
    }
}
