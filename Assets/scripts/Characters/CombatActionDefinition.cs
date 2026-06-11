using UnityEngine;

public enum CombatActionTarget
{
    Enemy,
    Ally,
    Self
}

public enum CombatActionEffect
{
    Damage,
    Heal
}

[CreateAssetMenu(menuName = "Nightless/Combat/Action Definition")]
public class CombatActionDefinition : ScriptableObject
{
    [SerializeField] private string actionName = "Attack";
    [SerializeField] private CombatActionEffect effect = CombatActionEffect.Damage;
    [SerializeField] private int power = 10;
    [SerializeField] private CombatActionTarget target = CombatActionTarget.Enemy;

    public string ActionName => actionName;
    public CombatActionEffect Effect => effect;
    public int Power => power;
    public CombatActionTarget Target => target;
}
