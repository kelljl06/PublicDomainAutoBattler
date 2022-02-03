using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPetClicked : MonoBehaviour
{

    public static ShopPetClicked instance;

    public bool isSelected = false;
    public int playerSpot;

    public int money;
    public int unitPrice;
    public int rerollPrice;

    public bool isRosterSelected = false;
    public int rosterSwap1;
    public int rosterSwap2;

    public List<int> bannedPlaces; 

    public void Awake()
    {
        instance = this;
        money = 10;
        unitPrice = 3;
        rerollPrice = 1;
    }

    public void setplayerSpot(int spot) {
        Debug.Log("Player Spot" + spot);
        if (bannedPlaces.Contains(spot))
            return;
        playerSpot = spot;
        isSelected = true;
        
    }

    public void Clear()
    {
        isSelected = false;
        isRosterSelected = false;
    }

    public void RemovePet() {
        GameObject.Destroy(ShopHandler.instance.shopPets[playerSpot]);
        ShopHandler.instance.shopPets.RemoveAt(playerSpot);
        ShopHandler.instance.shopPets.Insert(playerSpot, null);
        bannedPlaces.Add(playerSpot);
    
    }

    public void ShopRefreshed() {
        bannedPlaces.Clear();
        
    }

    public void BuySelectedPet(int purchaseLocation) {

        if (checkPurchaseable(unitPrice))
        {
            ShopHandler.instance.PurchasePet(playerSpot, purchaseLocation);
            Clear();
            RemovePet();
            payMoney(unitPrice);
        }
    }

    public void payMoney(int price) {
        money = money - price;
    }

    public bool checkPurchaseable(int price) {
        if (money - price >= 0) {
            return true;
        }
        return false;
    }

    public void SwapRoster(int place) {

        if (place <= Player.instance.getHand().Count-1)

        { 

            if (isRosterSelected == false)
            {
                rosterSwap1 = place;
                isRosterSelected = true;
            }
            else {
                rosterSwap2 = place;

               List<Pets> tempArray = Player.instance.getHand();

                Pets temp = tempArray[rosterSwap1];
                tempArray[rosterSwap1] = tempArray[rosterSwap2];
                tempArray[rosterSwap2] = temp;

                Player.instance.setHand(tempArray);

                ShopHandler.instance.LoadPlayerPets();
                Clear();
            }


        }


    }

}
