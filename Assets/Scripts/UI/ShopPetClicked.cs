using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPetClicked : MonoBehaviour
{

    public static ShopPetClicked instance;

    public bool isSelected = false;
    public int playerSpot;

    public bool isRosterSelected = false;
    public int rosterSwap1;
    public int rosterSwap2;

    public List<int> bannedPlaces; 

    public void Awake()
    {
        instance = this;
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
        //Debug.Log("Banned " + bannedPlaces[1]);
        bannedPlaces.Clear();
        
    }

    public void BuySelectedPet(int purchaseLocation) {

        ShopHandler.instance.PurchasePet(playerSpot, purchaseLocation);
        Clear();
        RemovePet();
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
