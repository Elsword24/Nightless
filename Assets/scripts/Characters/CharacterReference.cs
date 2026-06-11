using UnityEngine;

public class CharacterReference : MonoBehaviour
{
    [SerializeField] private CharacterDefinition characterDefinition;

    public CharacterDefinition Definition => characterDefinition;
}
