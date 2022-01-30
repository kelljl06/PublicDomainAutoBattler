using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Spawner : MonoBehaviour
{
    public GameObject pet;
    public static Player_Spawner instance;
    public void Awake() => instance = this;

    Vector3[] playerPositions = { new Vector3 { x = -1f, y = -2, z = 0 },
                            new Vector3 { x = -2.7f, y = -2, z = 0},
                            new Vector3 { x = -4.4f, y = -2, z = 0},
                            new Vector3 { x = -6.1f, y = -2, z = 0},
                            new Vector3 { x = -7.8f, y = -2, z = 0},
                            new Vector3 { x = 1f, y = -2, z = 0 },
                            new Vector3 { x = 2.7f, y = -2, z = 0},
                            new Vector3 { x = 4.4f, y = -2, z = 0},
                            new Vector3 { x = 6.1f, y = -2, z = 0},
                            new Vector3 { x = 7.8f, y = -2, z = 0}
     };

    public int order = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject createPet(string name) {
        pet = Resources.Load(name) as GameObject;

        
        return Spawn(pet);
    }


    public GameObject Spawn(GameObject ppet) {

        GameObject tempPet;
        
        tempPet = Instantiate(ppet, playerPositions[order], transform.localRotation);

        if (order > 4)
        {
            tempPet.GetComponent<SpriteRenderer>().flipX = true;
        }

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
