using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattleHandler : MonoBehaviour
{

    public float MOVE_SPEED = .3f;
    public float ATTACK_SPEED = .1f;

    List<Pets> roster = new List<Pets>();
    List<Pets> rosterOpp = new List<Pets>();
    List<GameObject> rosterOBJ = new List<GameObject>();
    List<GameObject> opponentOBJ = new List<GameObject>();
        
    private void Awake()
    {

        //Add Your Roster
        roster.Add(new Winnie());
        roster.Add(new NutCracker());
        roster.Add(new MobyDick());
        roster.Add(new NutCracker());
        roster.Add(new Tarzan());

        //Add Opponent Roster
        rosterOpp.Add(new Jesus());
        rosterOpp.Add(new MobyDick());
        rosterOpp.Add(new NutCracker());
        rosterOpp.Add(new Winnie());
        rosterOpp.Add(new NutCracker());
    }
    

    public void Start()
    {
        //Create GameObjects for you
        rosterOBJ.Add(Player_Spawner.instance.createPet(roster[0].getPrefab()));
        rosterOBJ.Add(Player_Spawner.instance.createPet(roster[1].getPrefab()));
        rosterOBJ.Add(Player_Spawner.instance.createPet(roster[2].getPrefab()));
        rosterOBJ.Add(Player_Spawner.instance.createPet(roster[3].getPrefab()));
        rosterOBJ.Add(Player_Spawner.instance.createPet(roster[4].getPrefab()));

        //Create GameObjects for opponent
        opponentOBJ.Add(Player_Spawner.instance.createPet(rosterOpp[0].getPrefab()));
        opponentOBJ.Add(Player_Spawner.instance.createPet(rosterOpp[1].getPrefab()));
        opponentOBJ.Add(Player_Spawner.instance.createPet(rosterOpp[2].getPrefab()));
        opponentOBJ.Add(Player_Spawner.instance.createPet(rosterOpp[3].getPrefab()));
        opponentOBJ.Add(Player_Spawner.instance.createPet(rosterOpp[4].getPrefab()));

    }
    void Update()
    {

        //Test Key
        if (Input.GetKeyDown(KeyCode.T))
        {
            Player_Spawner.instance.createClash();

        }

        //Only Battle on Y Key Press
        if (Input.GetKeyDown(KeyCode.Y))
        {

            //Don't play if one of teams is empty
            if (rosterOBJ.Count == 0 | opponentOBJ.Count == 0)
            {
                Debug.Log("Game is Finished");
                return;
            }
            else
            {
                //Battle the two lineups   
                Battle.instance.battle(roster, rosterOpp);
            }
            

            //Check to see if your lineups has a dead Pet
            if (Battle.instance.checkDead(roster[0]))
            {

                StartCoroutine(waitFor(.3f, drestoryDeadPlayerPet));
                StartCoroutine(waitFor(.5f, movePlayerTeam));
            }
            //Check to see if opponent lineups has a dead Pet
            if (Battle.instance.checkDead(rosterOpp[0]))
            {
                StartCoroutine(waitFor(.3f, drestoryDeadOppPet));
                StartCoroutine(waitFor(.5f, moveOppTeam));
                
            }


        }
        
        //Update visual statistics for pets
        for (int i = 0; i < rosterOBJ.Count; i++)
        {
            Player_Spawner.instance.updateHP(rosterOBJ[i], roster[i].getATK(), roster[i].getSPD(), roster[i].getHP());
        }
        for (int i = 0; i < opponentOBJ.Count; i++)
        {
            Player_Spawner.instance.updateHP(opponentOBJ[i], rosterOpp[i].getATK(), rosterOpp[i].getSPD(), rosterOpp[i].getHP());
        }


    }

    //Destorys the for pet in the player roster
    public void drestoryDeadPlayerPet()
    {
        GameObject.Destroy(rosterOBJ[0]);
        rosterOBJ.RemoveAt(0);
        roster.RemoveAt(0);
    }

    //Destorys the for pet in the Oppenent roster
    public void drestoryDeadOppPet()
    {
        
        GameObject.Destroy(opponentOBJ[0]);
        opponentOBJ.RemoveAt(0);
        rosterOpp.RemoveAt(0);
    }

    //Called to move the first user pet back and forth to kinda look like its hitting
    public void playerHitAna()
    {

        GameObject toHit = rosterOBJ[0];
        StartCoroutine(HitOverSeconds(toHit, toHit.transform.position + new Vector3(1f, 0, 0), ATTACK_SPEED));
    }

    //Does the same as the code above but for the oppenent
    public void oppHitAna()
    {
        GameObject toHit2 = opponentOBJ[0];
        StartCoroutine(HitOverSeconds(toHit2, toHit2.transform.position + new Vector3(-1f, 0, 0), ATTACK_SPEED));
    }

    //This is called when someone on the player team dies and realigns the rest of the team 
    public void movePlayerTeam()
    {
        foreach (GameObject n in rosterOBJ)
        {
            StartCoroutine(MoveOverSeconds(n, n.transform.position + new Vector3(1.7f, 0, 0), MOVE_SPEED));
        }
    }

    //This is called when someone on the oppenent team dies and realigns the rest of the team 
    public void moveOppTeam()
    {
        foreach (GameObject n in opponentOBJ)
        {
            StartCoroutine(MoveOverSeconds(n, n.transform.position + new Vector3(-1.7f, 0, 0), MOVE_SPEED));
        }
    }


    //This function moves a unit to a new location over time
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }


    //THus moves the player forward then right back to simulate a hit
    public IEnumerator HitOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;

        elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(end, startingPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }

    //Deadass dont remember but seems useful and it some lerp movement function
    public IEnumerator HitImageSpawn(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }


    //This function simply acts as a timer
    public IEnumerator waitFor(float time)
    {
        yield return new WaitForSeconds(time);
    }

    //This takes a float and a function and calls the funtion after an amount of time
    public IEnumerator waitFor(float time, Action act)
    {
        yield return new WaitForSeconds(time);
        act();
    }

}
