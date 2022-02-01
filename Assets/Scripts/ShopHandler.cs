using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{

    public static ShopHandler instance;

    List<Pets> possiblePets = new List<Pets>();
    List<GameObject> shopPets = new List<GameObject>();


    List<GameObject> PlayerPets = new List<GameObject>();


    public GameObject pet;
    public int orderShop;
    public int orderPlayer;

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

    public void ShopRefresh() {

        shopPets.Add(createPet(possiblePets[0].getPrefab(), false));
        shopPets.Add(createPet(possiblePets[1].getPrefab(), false));
        shopPets.Add(createPet(possiblePets[2].getPrefab(), false));
        shopPets.Add(createPet(possiblePets[3].getPrefab(), false));
        shopPets.Add(createPet(possiblePets[4].getPrefab(), false));

    }

    public void LoadPlayerPets()
    {
        ClearPets();
        for (int i = 0; i < Player.instance.getHand().Count; i++) {
            Debug.Log("Load Pet "+ i);
            PlayerPets.Add(createPet(Player.instance.getWithinIndex(i).getPrefab(), true));
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
