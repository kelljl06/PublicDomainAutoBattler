using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
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
        roster.Add(new Winnie());
        roster.Add(new NutCracker());
        roster.Add(new Winnie());

        //Add Opponent Roster
        rosterOpp.Add(new NutCracker());
        rosterOpp.Add(new Winnie());
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            playerHitAna();
            oppHitAna();

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
                GameObject.Destroy(rosterOBJ[0]);
                rosterOBJ.RemoveAt(0);
                roster.RemoveAt(0);

                foreach (GameObject n in rosterOBJ)
                {
                    StartCoroutine(MoveOverSeconds(n, n.transform.position + new Vector3(1.7f, 0, 0), MOVE_SPEED));
                }
            }
            //Check to see if opponent lineups has a dead Pet
            if (Battle.instance.checkDead(rosterOpp[0]))
            {
                GameObject.Destroy(opponentOBJ[0]);
                opponentOBJ.RemoveAt(0);
                rosterOpp.RemoveAt(0);

                foreach (GameObject n in opponentOBJ)
                {
                    StartCoroutine(MoveOverSeconds(n, n.transform.position + new Vector3(-1.7f, 0, 0), MOVE_SPEED));
                }
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

    public void playerHitAna()
    {

        GameObject toHit = rosterOBJ[0];
        StartCoroutine(HitOverSeconds(toHit, toHit.transform.position + new Vector3(1f, 0, 0), ATTACK_SPEED));
    }

    public void oppHitAna()
    {
        GameObject toHit2 = opponentOBJ[0];
        StartCoroutine(HitOverSeconds(toHit2, toHit2.transform.position + new Vector3(-1f, 0, 0), ATTACK_SPEED));
    }

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


}
