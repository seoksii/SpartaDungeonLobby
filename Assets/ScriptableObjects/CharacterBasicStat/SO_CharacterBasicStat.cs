using UnityEngine;

[CreateAssetMenu(fileName = "CharacterBasicStat", menuName = "Scriptable Object/CharacterBasicStat", order = int.MinValue)]
public class SO_CharacterBasicStat : ScriptableObject
{
    [Header("Class Info")]
    [SerializeField]
    private CharacterClass _characterClass;
    public CharacterClass CharacterClass { get { return _characterClass; } }
    [SerializeField]
    private string _className;
    public string ClassName { get { return _className; } }
    [SerializeField]
    private string _classDescription;
    public string ClassDescription { get { return _classDescription; } }

    [Header("Character Stat")]
    [SerializeField]
    private int _attack;
    public int Attack { get { return _attack; } }
    [SerializeField]
    private int _defense;
    public int Defense { get { return _defense; } }
    [SerializeField]
    private int _maxHp;
    public int MaxHp { get { return _maxHp; } }
    [SerializeField]
    private float _critChance;
    public float CritChance { get { return _critChance; } }
}