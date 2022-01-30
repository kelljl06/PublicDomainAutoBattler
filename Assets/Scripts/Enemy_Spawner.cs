using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject pet;
    public static Enemy_Spawner instance;
    public void Awake() => instance = this;

    Vector3[] playerPositions = { new Vector3 { x = -9.5f, y = -2, z = 0 },
                            new Vector3 { x = -11.2f, y = -2, z = 0},
                            new Vector3 { x = -12.9f, y = -2, z = 0},
                            new Vector3 { x = -14.6f, y = -2, z = 0},
                            new Vector3 { x = -16.3f, y = -2, z = 0}
     };

    public int order = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject createPet(string name)
    {
        pet = Resources.Load(name) as GameObject;
        return Spawn(pet);
    }


    public GameObject Spawn(GameObject ppet)
    {
        GameObject tempPet = Instantiate(ppet, playerPositions[order], transform.rotation);
        order++;
        return tempPet;
    }

    public void updateHP(GameObject charac, int ATK, int SPD, int HP)
    {
        Text[] test = charac.GetComponentsInChildren<Text>();
        test[0].text = ATK.ToString();
        test[1].text = SPD.ToString();
        test[2].text = HP.ToString();
    }

}
