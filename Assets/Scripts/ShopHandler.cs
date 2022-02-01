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
                            new Vector3 { x = -6.3f, y = -2, z = 0 },
                            new Vector3 { x = -3.1f, y = -2, z = 0},
                            new Vector3 { x = 0f, y = -2, z = 0},
                            new Vector3 { x = 3.1f, y = -2, z = 0},
                            new Vector3 { x = 6.3f, y = -2, z = 0},

     };

    Vector3[] playerPositions = {
                            new Vector3 { x = -6.3f, y = 2.3f, z = 0 },
                            new Vector3 { x = -3.1f, y = 2.3f, z = 0},
                            new Vector3 { x = 0f, y = 2.3f, z = 0},
                            new Vector3 { x = 3.1f, y = 2.3f, z = 0},
                            new Vector3 { x = 6.3f, y = 2.3f, z = 0},

     };


    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        possiblePets.Add(new Winnie());
        possiblePets.Add(new MobyDick());
        possiblePets.Add(new NutCracker());
        possiblePets.Add(new Jesus());
        possiblePets.Add(new Tarzan());

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
        
        for (int i = 0; possiblePets.Count > i; i++) {
            rand = Random.Range(0, possiblePets.Count);
            shopPets.Add(createPet(possiblePets[rand].getPrefab(), false));
            shopPetsClass.Add(possiblePets[rand]);
            updateStats(shopPets[i], shopPetsClass[i].getATK(), shopPetsClass[i].getSPD(), shopPetsClass[i].getHP());
        }
        

    }
    public void ClearShop()
    {
        orderShop = 0;
        while (shopPets.Count > 0)
        {
            Debug.Log("1111111111");
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
            Debug.Log("Load Pet "+ i);
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
}
