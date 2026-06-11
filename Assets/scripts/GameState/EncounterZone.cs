using System.Collections.Generic;
using UnityEngine;

public class EncounterZone : MonoBehaviour
{

    string encounterZone;
    float encounterChance = 10;
    PlayerController player;
    Vector3 lastPlayerPosition;
    bool playerInside;
    float accumulatedDistance;
    public List<CharacterDefinition> possibleEncounters; 
    public float fightChance = 0.5f; // Chance to start a fight when an encounter occurs
    private List<CharacterDefinition> enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            player = other.GetComponent<PlayerController>();
            lastPlayerPosition = player.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            player = null;
            accumulatedDistance = 0f; // Reset distance when player leaves the zone
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = new List<CharacterDefinition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside)
        {
            float distance = Vector3.Distance(player.transform.position, lastPlayerPosition);
            accumulatedDistance += distance;
            lastPlayerPosition = player.transform.position;

            if (accumulatedDistance >= encounterChance)
            {
                fightChance = Mathf.Clamp01(fightChance + 0.1f); // Increase fight chance with each encounter
                if (Random.value <= fightChance)
                {

                    //set up ennemis
                    int nbofEnnemis = Random.Range(1, 5); //change later when encounter system is created
                    for (int i = 0; i < nbofEnnemis; i++)
                    {
                        CharacterDefinition randomEncounter = possibleEncounters[Random.Range(0, possibleEncounters.Count)];
                        //create battle unit with random encounter and add it to the battle manager
                        enemies.Add(randomEncounter);
                        //add newEnnemy to battle manager
                    }
                    GameManager.instance.StartEncounter(player.transform.position, enemies);
                    accumulatedDistance = 0f; // Reset distance after encounter starts
                    fightChance = 0.5f; // Reset fight chance after an encounter
                    enemies.Clear(); // Clear the list of enemies for the next encounter
                }
                else
                {
                    accumulatedDistance = 0f; // Reset distance even if no fight starts, to avoid too many encounters
                }
            }
        }
    }
}
