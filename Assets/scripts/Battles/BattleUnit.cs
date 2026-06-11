using UnityEngine;

public enum BattleTeam
{
    Ally,
    Enemy
}

public class BattleUnit
{
    public BattleUnit(CharacterDefinition definition, BattleTeam team)
    {
        Definition = definition;
        Team = team;
        CurrentHealth = definition != null ? definition.MaxHealth : 0;
    }

    public BattleUnit(PartyMemberState memberState, BattleTeam team)
    {
        Definition = memberState.characterDefinition;
        Team = team;
        CurrentHealth = memberState.CurrentHealth;
    }

    public CharacterDefinition Definition { get; }
    public BattleTeam Team { get; }
    public int CurrentHealth { get; private set; }
    public bool IsAlive => CurrentHealth > 0;
    public string Name => Definition != null ? Definition.CharacterName : "Unknown";
    public int Attack => Definition != null ? Definition.Attack : 0;
    public int Defense => Definition != null ? Definition.Defense : 0;
    public int Speed => Definition != null ? Definition.Speed : 0;
    public CombatActionDefinition[] Actions => Definition != null ? Definition.Actions : new CombatActionDefinition[0];

    public void TakeDamage(int amount)
    {
        int damage = Mathf.Max(0, amount);
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
    }
}
