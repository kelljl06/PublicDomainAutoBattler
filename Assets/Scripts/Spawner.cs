using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pet;
    public static Spawner instance;
    public void Awake() => instance = this;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void createPet(string name) {
        pet = Resources.Load(name) as GameObject;
        Spawn1(pet);
    }


    public void Spawn1(GameObject pet) {
        Instantiate(pet);
    }
    static public void Spawn()
    {
        Debug.Log("1");
    }
}
