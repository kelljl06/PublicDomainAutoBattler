using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

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
        for (int i = 0; i < Player.instance.getHand().Count; i++)
        {
            roster.Add(Player.instance.getWithinIndex(i).clone() as Pets);
        }

        //Add Opponent Roster
        rosterOpp.Add(new NutCracker());
        rosterOpp.Add(new MobyDick());
        rosterOpp.Add(new NutCracker());
        rosterOpp.Add(new Winnie());
        rosterOpp.Add(new NutCracker());
    }
    

    public void Start()
    {
        //Create GameObjects for you

        for (int i = 0; i < Player.instance.getHand().Count; i++)
        {
            rosterOBJ.Add(Player_Spawner.instance.createPet(roster[i].getPrefab()));
            roster[i].visualEffect = rosterOBJ[i];
        }

        //Create GameObjects for opponent
        for (int i = 0; i < rosterOpp.Count; i++)
        {
            opponentOBJ.Add(Player_Spawner.instance.createPet(rosterOpp[i].getPrefab()));
            rosterOpp[i].visualEffect = opponentOBJ[i];
        }
        Pets[] tempRoster = new Pets[roster.Count];
        Pets[] tempOppRoster = new Pets[rosterOpp.Count];
        roster.CopyTo(tempRoster);
        rosterOpp.CopyTo(tempOppRoster);
        foreach (Pets pet in tempRoster)
        {
            pet.onSpawn(roster, rosterOpp);
        }
        foreach (Pets pet in tempOppRoster)
        {
            pet.onSpawn(rosterOpp, roster);
        }
        StartCoroutine(waitFor(.5f, movePlayerTeam));
        StartCoroutine(waitFor(.5f, moveOppTeam));
    }
    void Update()
    {

        //Only Battle on Y Key Press
        if (Input.GetKeyDown(KeyCode.Y))
        {

            //Don't play if one of teams is empty
            if (roster.Count == 0 | rosterOpp.Count == 0)
            {
                Debug.Log("Game is Finished");
                SceneManager.LoadScene("ShopUI", LoadSceneMode.Single);
                return;
            }
            else
            {
                //Battle the two lineups   
                Battle.instance.battle(roster, rosterOpp);
            }


            //Check to see if your lineups has a dead Pet
            for (int i = 0; i < roster.Count; i++)
            {
                if (Battle.instance.checkDead(roster[i]))
                {
                    roster[i].onDeath(roster, rosterOpp);
                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (j != i)
                            roster[j].onAllyDeath(roster[i], roster, rosterOpp);
                    }
                    drestoryDeadPlayerPet(i);
                    
                }
            }
            //Check to see if opponent lineups has a dead Pet
            for (int i = 0; i < rosterOpp.Count; i++)
            {
                if (Battle.instance.checkDead(rosterOpp[i]))
                {
                    rosterOpp[i].onDeath(rosterOpp, roster);
                    for (int j = 0; j < rosterOpp.Count; j++)
                    {
                        if (j != i)
                            rosterOpp[j].onAllyDeath(rosterOpp[i], rosterOpp, roster);
                    }
                    drestoryDeadOppPet(i);
                    
                }
            }
            StartCoroutine(waitFor(.5f, movePlayerTeam));
            StartCoroutine(waitFor(.5f, moveOppTeam));

        }
        
        //Update visual statistics for pets
        for (int i = 0; i < roster.Count; i++)
        {
            Player_Spawner.instance.updateHP(roster[i].visualEffect, roster[i].getATK(), roster[i].getSPD(), roster[i].getHP());
        }
        for (int i = 0; i < rosterOpp.Count; i++)
        {
            Player_Spawner.instance.updateHP(rosterOpp[i].visualEffect, rosterOpp[i].getATK(), rosterOpp[i].getSPD(), rosterOpp[i].getHP());
        }


    }

    //Destorys the for pet in the player roster
    public void drestoryDeadPlayerPet(int i)
    {
        GameObject.Destroy(roster[i].visualEffect);
        roster.RemoveAt(i); 
    }

    //Destorys the for pet in the Oppenent roster
    public void drestoryDeadOppPet(int i)
    {
        GameObject.Destroy(rosterOpp[i].visualEffect);
        rosterOpp.RemoveAt(i);
    }

    //Called to move the first user pet back and forth to kinda look like its hitting
    public void playerHitAna()
    {
        Player_Spawner.instance.createClash();
        GameObject toHit = roster[0].visualEffect;
        StartCoroutine(HitOverSeconds(toHit, toHit.transform.position + new Vector3(1f, 0, 0), ATTACK_SPEED));
    }

    //Does the same as the code above but for the oppenent
    public void oppHitAna()
    {
        Player_Spawner.instance.createClash();
        GameObject toHit2 = rosterOpp[0].visualEffect;
        StartCoroutine(HitOverSeconds(toHit2, toHit2.transform.position + new Vector3(-1f, 0, 0), ATTACK_SPEED));
    }

    //This is called when someone on the player team dies and realigns the rest of the team 
    public void movePlayerTeam()
    {
        for (int i = 0; i < roster.Count; i++)
        {
            GameObject n = roster[i].visualEffect;
            Vector3 vecGoal = new Vector3((float)(-1-1.7*i), -2, 0);
            StartCoroutine(MoveOverSeconds(n, vecGoal, MOVE_SPEED));
        }
    }

    //This is called when someone on the oppenent team dies and realigns the rest of the team 
    public void moveOppTeam()
    {       
        for (int i = 0; i < rosterOpp.Count; i++)
        {
            GameObject n = rosterOpp[i].visualEffect;
            Vector3 vecGoal = new Vector3((float)(1 + 1.7 * i), -2, 0);
            StartCoroutine(MoveOverSeconds(n, vecGoal, MOVE_SPEED));
        }
    }


    //This function moves a unit to a new location over time
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds & objectToMove != null)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (objectToMove != null)
            objectToMove.transform.position = end;
    }


    //THus moves the player forward then right back to simulate a hit
    public IEnumerator HitOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds & objectToMove != null)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (objectToMove != null)
            objectToMove.transform.position = end;

        elapsedTime = 0;
        while (elapsedTime < seconds & objectToMove != null)
        {
            objectToMove.transform.position = Vector3.Lerp(end, startingPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

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
