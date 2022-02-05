using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopHandler : MonoBehaviour
{

    public static ShopHandler instance;

    public List<Pets> shopPetsClass = new List<Pets>();
    public List<GameObject> shopPets = new List<GameObject>();


    public List<GameObject> PlayerPets = new List<GameObject>();



    public GameObject pet;
    public int orderShop;
    public int orderPlayer;
    public int rand;
    public bool firstReroll = true;

    Vector3[] shopPositions = {
        new Vector3 { x = 6.3f, y = -2, z = 0},
        new Vector3 { x = 3.1f, y = -2, z = 0},
        new Vector3 { x = 0f, y = -2, z = 0},
        new Vector3 { x = -3.1f, y = -2, z = 0},
        new Vector3 { x = -6.3f, y = -2, z = 0 },
        
};

    Vector3[] playerPositions = {

        new Vector3 { x = 6.3f, y = 2.3f, z = 0},
        new Vector3 { x = 3.1f, y = 2.3f, z = 0},
        new Vector3 { x = 0f, y = 2.3f, z = 0},
        new Vector3 { x = -3.1f, y = 2.3f, z = 0},
        new Vector3 { x = -6.3f, y = 2.3f, z = 0 },                         
                            
     };


    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
        loadPos();
    }
    void Start()
    {
        LoadPlayerPets();
        ShopRefresh();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void loadPos() {
        Vector3 adjust = new Vector3(0f,.13f, 0f);

        GameObject posGrab = GameObject.Find("shopPShadow1");
        playerPositions[0] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopPShadow2");
        playerPositions[1] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopPShadow3");
        playerPositions[2] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopPShadow4");
        playerPositions[3] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopPShadow5");
        playerPositions[4] = posGrab.transform.position + adjust;

        posGrab = GameObject.Find("shopEShadow1");
        shopPositions[0] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopEShadow2");
        shopPositions[1] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopEShadow3");
        shopPositions[2] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopEShadow4");
        shopPositions[3] = posGrab.transform.position + adjust;
        posGrab = GameObject.Find("shopEShadow5");
        shopPositions[4] = posGrab.transform.position + adjust;


    }

    public void updateStats(GameObject charac, int ATK, int SPD, int HP)
    {
        Text[] test = charac.GetComponentsInChildren<Text>();
        test[0].text = ATK.ToString();
        test[1].text = SPD.ToString();
        test[2].text = HP.ToString();
    }

    public void ShopRefresh() {

        if (!ShopPetClicked.instance.checkPurchaseable(ShopPetClicked.instance.rerollPrice))
            return;
        ClearShop();
        if (!firstReroll)
            ShopPetClicked.instance.payMoney(ShopPetClicked.instance.rerollPrice);

        firstReroll = false;

        for (int i = 0; 5 > i; i++) {
            rand = Random.Range(0, 13);
            switch (rand) {
                case 0: 
                    shopPetsClass.Add(new Winnie());
                    shopPets.Add(createPet(new Winnie().getPrefab(), false));
                    break;
                case 1:
                    shopPetsClass.Add(new MobyDick());
                    shopPets.Add(createPet(new MobyDick().getPrefab(), false));
                    break;
                case 2:
                    shopPetsClass.Add(new NutCracker());
                    shopPets.Add(createPet(new NutCracker().getPrefab(), false));
                    break;
                case 3:
                    shopPetsClass.Add(new Jesus());
                    shopPets.Add(createPet(new Jesus().getPrefab(), false));
                    break;
                case 4:
                    shopPetsClass.Add(new Tarzan());
                    shopPets.Add(createPet(new Tarzan().getPrefab(), false));
                    break;
                case 5:
                    shopPetsClass.Add(new Death());
                    shopPets.Add(createPet(new Death().getPrefab(), false));
                    break;
                case 6:
                    shopPetsClass.Add(new Bozo());
                    shopPets.Add(createPet(new Bozo().getPrefab(), false));
                    break;
                case 7:
                    shopPetsClass.Add(new Frankenstein());
                    shopPets.Add(createPet(new Frankenstein().getPrefab(), false));
                    break;
                case 8:
                    shopPetsClass.Add(new GingerbreadMan());
                    shopPets.Add(createPet(new GingerbreadMan().getPrefab(), false));
                    break;
                case 9:
                    shopPetsClass.Add(new Nessy());
                    shopPets.Add(createPet(new Nessy().getPrefab(), false));
                    break;
                case 10:
                    shopPetsClass.Add(new TinMan());
                    shopPets.Add(createPet(new TinMan().getPrefab(), false));
                    break;
                case 11:
                    shopPetsClass.Add(new Lion());
                    shopPets.Add(createPet(new Lion().getPrefab(), false));
                    break;
                case 12:
                    shopPetsClass.Add(new Scarecrow());
                    shopPets.Add(createPet(new Scarecrow().getPrefab(), false));
                    break;
            }
            updateStats(shopPets[i], shopPetsClass[i].getATK(), shopPetsClass[i].getSPD(), shopPetsClass[i].getHP());
        }
        

    }


    public void ClearShop()
    {
        ShopPetClicked.instance.ShopRefreshed();
        orderShop = 0;
        while (shopPets.Count > 0)
        {
            GameObject.Destroy(shopPets[0]);
            shopPets.RemoveAt(0);
            shopPetsClass.RemoveAt(0);
        }
        shopPets.Clear();
    }


    public void LoadPlayerPets()
    {
        ClearPets();
        for (int i = 0; i < Player.instance.getHand().Count; i++) {
            PlayerPets.Add(createPet(Player.instance.getWithinIndex(i).getPrefab(), true));
            updateStats(PlayerPets[i], Player.instance.getWithinIndex(i).getATK(),
                Player.instance.getWithinIndex(i).getSPD(), Player.instance.getWithinIndex(i).getHP());
        }
        
    }

    public void ClearPets() {
        orderPlayer = 0;
        while (PlayerPets.Count > 0)
        {
            GameObject.Destroy(PlayerPets[0]);
            PlayerPets.RemoveAt(0);
        }
        PlayerPets.Clear();
    }

    public GameObject createPet(string name, bool isPlayer)
    {
        pet = Resources.Load(name) as GameObject;
        return Spawn(pet, isPlayer);
    }

    //This takes a pet OBJECT and puts it on the screen and returns the on screen object
    public GameObject Spawn(GameObject ppet, bool isPlayer)
    {

        GameObject tempPet;
        if (isPlayer) {
            tempPet = Instantiate(ppet, playerPositions[orderPlayer], transform.localRotation);
            orderPlayer++;
        }
        else { 
            tempPet = Instantiate(ppet, shopPositions[orderShop], transform.localRotation);
            orderShop++;
        }

        return tempPet;
    }

    public void PurchasePet(int petPicked,int place)
    {

        if (place > Player.instance.getHand().Count)
            Player.instance.setWithinIndex(shopPetsClass[petPicked], Player.instance.getHand().Count);
        else
            Player.instance.setWithinIndex(shopPetsClass[petPicked], place);

        ShopHandler.instance.LoadPlayerPets();

    }
}
