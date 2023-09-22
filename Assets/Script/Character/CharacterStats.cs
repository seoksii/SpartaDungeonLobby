using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public SO_CharacterBasicStat BasicStat;

    [SerializeField]
    private int _level;
    public int Level { get { return _level; } }
    [SerializeField]
    private int _exp;
    public int Exp { get { return _exp; } }
    [SerializeField]
    private int _maxExp;
    public int MaxExp { get { return _maxExp; } }
    [SerializeField]
    private int _gold;
    public int gold { get { return _gold; } }
    [SerializeField]
    private int _currentHp;
    public int CurrentHp { get { return _currentHp; } }
    
    public int ExternalStat_Attack;
    public int ExternalStat_Defense;
    public int ExternalStat_MaxHp;
    public float ExternalStat_CritChance;

    public int TotalStat_attack { get { return BasicStat.Attack + ExternalStat_Attack; } }
    public int TotalStat_Defense { get { return BasicStat.Defense + ExternalStat_Defense; } }
    public int TotalStat_MaxHp { get { return BasicStat.MaxHp + ExternalStat_MaxHp; } }
    public float TotalStat_CritChance { get { return BasicStat.CritChance + ExternalStat_CritChance; } }

    private void Start()
    {
        _level = 1;
        _exp = 9;
        _currentHp = TotalStat_MaxHp;
    }

    public void AddStats(ItemInfo item)
    {
        ExternalStat_Attack += item.BasicInfo.Attack;
        ExternalStat_Defense += item.BasicInfo.Defense;
        ExternalStat_MaxHp += item.BasicInfo.MaxHp;
        ExternalStat_CritChance += item.BasicInfo.CritChance;
    }

    public void RemoveStats(ItemInfo item)
    {
        ExternalStat_Attack -= item.BasicInfo.Attack;
        ExternalStat_Defense -= item.BasicInfo.Defense;
        ExternalStat_MaxHp -= item.BasicInfo.MaxHp;
        ExternalStat_CritChance -= item.BasicInfo.CritChance;
    }
}
