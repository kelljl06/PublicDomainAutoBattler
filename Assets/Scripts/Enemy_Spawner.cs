using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject pet;
    public static Enemy_Spawner instance;
    public void Awake() => instance = this;

    Vector3[] playerPositions = { new Vector3 { x = -1f, y = -2, z = 0 },
                            new Vector3 { x = -2.7f, y = -2, z = 0},
                            new Vector3 { x = -4.4f, y = -2, z = 0},
                            new Vector3 { x = -6.1f, y = -2, z = 0},
                            new Vector3 { x = -7.8f, y = -2, z = 0}
     };

    public int order = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void createPet(string name)
    {
        pet = Resources.Load(name) as GameObject;
        Spawn(pet);
    }


    public void Spawn(GameObject pet)
    {
        Instantiate(pet, playerPositions[order], transform.rotation);
        order++;
    }

}
