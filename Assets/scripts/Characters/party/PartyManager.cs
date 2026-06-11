using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    PartyState currentParty;
    public static PartyManager instance;
    public PartyState CurrentParty { get => currentParty; set => currentParty = value; }
    public List<CharacterDefinition> defaultCharacters;

    private void Awake()
    {
        // Ensure that the PartyManager persists across scenes
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        // Initialize the party with some default characters (for testing purposes)
        InitParty();

        foreach (CharacterDefinition character in defaultCharacters)
        {
            AddPartyMember(character);
        }


    }

    void AddPartyMember(CharacterDefinition character)
    {
        if (currentParty.partyMembers == null)
        {
            currentParty.partyMembers = new System.Collections.Generic.List<PartyMemberState>();
        }
        PartyMemberState newMember = new PartyMemberState
        {
            characterDefinition = character,
            CurrentHealth = character.MaxHealth,
            CurrentMana = character.MaxMana
        };
        currentParty.partyMembers.Add(newMember);
    }

    void InitParty()
    {
        // This method can be used to initialize the party at the start of the game or when loading a saved game
        currentParty = new PartyState
        {
            partyMembers = new System.Collections.Generic.List<PartyMemberState>()
        };
    }
}
