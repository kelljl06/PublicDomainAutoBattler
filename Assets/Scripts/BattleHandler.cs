using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class BattleHandler : MonoBehaviour
{
    public static BattleHandler instance;

    public const float MOVE_SPEED = .3f;
    public const float ATTACK_SPEED = .1f;
    public const int DEFAULT_DURATION = 1;

    List<Pets> roster = new List<Pets>();
    List<Pets> rosterOpp = new List<Pets>();
    List<GameObject> rosterOBJ = new List<GameObject>();
    List<GameObject> opponentOBJ = new List<GameObject>();

    public void Awake() => instance = this;

    public void Start()
    {

        for (int i = 0; i < Player.instance.getHand().Count; i++)
        {
            roster.Add(Player.instance.getWithinIndex(i).clone() as Pets);
        }

        for (int i = 0; 5 > i; i++)
        {
            int rand = UnityEngine.Random.Range(0, 6);
            switch (rand)
            {
                case 0:
                    rosterOpp.Add(new Winnie());
                    break;
                case 1:
                    rosterOpp.Add(new MobyDick());
                    break;
                case 2:
                    rosterOpp.Add(new NutCracker());
                    break;
                case 3:
                    rosterOpp.Add(new Jesus());
                    break;
                case 4:
                    rosterOpp.Add(new Death());
                    break;
                case 5:
                    rosterOpp.Add(new Tarzan());
                    break;
                case 6:
                    rosterOpp.Add(new Bozo());
                    break;
            }
        }
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
                if (roster.Count == 0 & rosterOpp.Count != 0) {
                    Player.instance.setHelth(1);
                    Debug.Log("Health = "+Player.instance.getHealth().ToString());
                }
                    
                Debug.Log("Game is Finished");
                Player.instance.rounds++; 
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

    public void spawnObjectAbove(GameObject newThing, GameObject pet, int duration = DEFAULT_DURATION, bool setParent = false)
    {
        newThing = Instantiate(newThing, pet.transform.position + new Vector3(0, 2f, 0), transform.localRotation);
        if (setParent)
            newThing.transform.SetParent(pet.transform);
        StartCoroutine(deleteObjectAbove(duration, newThing));
    }
    public IEnumerator deleteObjectAbove(float time, GameObject objectAbove)
    {
        yield return new WaitForSeconds(time);

        GameObject.Destroy(objectAbove);
    }

    public void waveAccrossStream(Vector3 startPos, bool movingLeft)
    {
        StartCoroutine(waveAccrossStream(startPos, movingLeft, 1f));
    }


    public IEnumerator waveAccrossStream(Vector3 startPos, bool movingLeft, float seconds)
    {
        
        GameObject wave = Resources.Load("UI/Wave") as GameObject;
        wave = Instantiate(wave, startPos, transform.localRotation);
        float elapsedTime = 0;
        Vector3 startingPos = wave.transform.position;
        Vector3 endingPos = new Vector3(12f, -2f, 0);
        if (movingLeft)
        {
            wave.GetComponent<SpriteRenderer>().flipX = true;
            endingPos = new Vector3(-12f, -2f, 0);
        }
            
            
        while (elapsedTime < seconds & wave != null)
        {
            wave.transform.position = Vector3.Lerp(startingPos, endingPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }
}
