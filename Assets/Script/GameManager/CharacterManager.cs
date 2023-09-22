using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private List<SO_CharacterBasicStat> _characterBasicStats;
    [SerializeField]
    private GameObject _characterPrefab;

    [HideInInspector]
    public static Character CurrentCharacter;

    private void Awake()
    {
        MakeCharacter(CharacterClass.Warrior);
    }

    public Character MakeCharacter(CharacterClass characterClass)
    {
        Character newCharacter = Instantiate(_characterPrefab).GetComponent<Character>();
        CharacterStats stats = newCharacter.CharacterStat.GetComponent<CharacterStats>();

        stats.BasicStat = _characterBasicStats[(int)characterClass];
        CurrentCharacter = newCharacter;

        return newCharacter;
    }
}
