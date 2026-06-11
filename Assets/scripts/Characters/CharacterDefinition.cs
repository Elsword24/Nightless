using UnityEngine;

[CreateAssetMenu(menuName = "Nightless/Characters/Character Definition")]
public class CharacterDefinition : ScriptableObject
{
    [SerializeField] private string characterName = "Character";
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int attack = 10;
    [SerializeField] private int defense = 0;
    [SerializeField] private int speed = 10;
    [SerializeField] private int maxMana = 0;
    [SerializeField] private CombatActionDefinition[] actions = new CombatActionDefinition[0];

    public string CharacterName => characterName;
    public int MaxHealth => maxHealth;
    public int Attack => attack;
    public int Defense => defense;
    public int Speed => speed;

    public int MaxMana => maxMana;
    public CombatActionDefinition[] Actions => actions;
}
