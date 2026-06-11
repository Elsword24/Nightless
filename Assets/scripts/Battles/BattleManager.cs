using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private List<BattleUnit> allies; //change later when battle unit is created
    private List<BattleUnit> ennemies; //change later when battle unit is created
    private List<CharacterDefinition> ennemiDefinitions; //change later when battle unit is created
    private List<PartyMemberState> alliesdefinitions; //change later when battle unit is created


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ennemies = new List<BattleUnit>(); //change later when battle unit is created
        ennemiDefinitions = new List<CharacterDefinition>(GameManager.instance.currentEnemies); //get ennemies from gamemanager
        foreach (CharacterDefinition definition in ennemiDefinitions)
        {
            BattleUnit newEnnemy = new BattleUnit(definition, BattleTeam.Enemy);
            ennemies.Add(newEnnemy);
        }

        ennemies.ForEach(ennemy => Debug.Log("Ennemy: " + ennemy.Name + " with " + ennemy.CurrentHealth + " health"));

        allies = new List<BattleUnit>(); //change later when battle unit is created

        alliesdefinitions = new List<PartyMemberState>(PartyManager.instance.CurrentParty.partyMembers); //get allies from partymanager

        foreach (PartyMemberState member in alliesdefinitions)
        {
            BattleUnit newAlly = new BattleUnit(member, BattleTeam.Ally);
            allies.Add(newAlly);
        }
        foreach (BattleUnit ally in allies)
        {
            Debug.Log("Ally: " + ally.Name + " with " + ally.CurrentHealth + " health");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndBattle()
    {
        GameManager.instance.EndEncounter();
    } 

    public void Attack()
    {
        if (ennemies.Count == 0)
        {
            Debug.Log("No enemies to attack");
            return;
        }
        BattleUnit targetEnnemy = ennemies.FirstOrDefault(e => e.IsAlive);
        if (targetEnnemy != null && targetEnnemy.IsAlive)
        {
            targetEnnemy.TakeDamage(10); //change later when battle unit is created
            Debug.Log("You attack the enemy for 10 damage");
            Debug.Log("Ennemy health: " + targetEnnemy.CurrentHealth); //change later when battle unit is created
        }
      
        if (ennemies.All(e => !e.IsAlive))
        {
            Debug.Log("You win");
            EndBattle();
        }

        if (allies.All(a => !a.IsAlive))
        {
            Debug.Log("You lose");
            EndBattle();
        }
    }

    public void Run()
    {
        Debug.Log("You run away from the battle");
        GameManager.instance.EndEncounter();
    }

}
