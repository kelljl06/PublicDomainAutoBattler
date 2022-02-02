using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopHandler : MonoBehaviour
{

    public static ShopHandler instance;

    List<Pets> possiblePets = new List<Pets>();

    List<Pets> shopPetsClass = new List<Pets>();
    List<GameObject> shopPets = new List<GameObject>();


    List<GameObject> PlayerPets = new List<GameObject>();



    public GameObject pet;
    public int orderShop;
    public int orderPlayer;
    public int rand;

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

    public void updateStats(GameObject charac, int ATK, int SPD, int HP)
    {
        Text[] test = charac.GetComponentsInChildren<Text>();
        test[0].text = ATK.ToString();
        test[1].text = SPD.ToString();
        test[2].text = HP.ToString();
    }

    public void ShopRefresh() {
        ClearShop();

        for (int i = 0; 5 > i; i++) {
            rand = Random.Range(0, 6);
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
            }
            updateStats(shopPets[i], shopPetsClass[i].getATK(), shopPetsClass[i].getSPD(), shopPetsClass[i].getHP());
        }
        

    }


    public void ClearShop()
    {
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
        Debug.Log(""+ Player.instance.getHand().Count);

        if (place > Player.instance.getHand().Count)
            Player.instance.setWithinIndex(shopPetsClass[petPicked], Player.instance.getHand().Count);
        else
            Player.instance.setWithinIndex(shopPetsClass[petPicked], place);

        ShopHandler.instance.LoadPlayerPets();

    }
}
