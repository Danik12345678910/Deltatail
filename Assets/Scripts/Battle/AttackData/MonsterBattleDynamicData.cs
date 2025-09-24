using UnityEngine;

public struct GroupMonsterBattleDynamicData
{
    public MonsterBattleDynamicData[] Monsters { get; private set; }

    public GroupMonsterBattleDynamicData(GroupMonsterBattleData monsters)
    {
        this.Monsters = new MonsterBattleDynamicData[monsters.Monsters.Length];
        for (int i = 0; i < monsters.Monsters.Length; i++)
        {
            this.Monsters[i] = new MonsterBattleDynamicData(monsters.Monsters[i]);
        }
    }
}

public struct MonsterBattleDynamicData
{
    public MonsterPhaseBattleDynamicData[] Phases { get; private set; }

    public MonsterBattleDynamicData(MonsterBattleData data)
    {
        Phases = new MonsterPhaseBattleDynamicData[data.Phases.Length];
        for (int i = 0; i < data.Phases.Length; i++)
        {
            Phases[i] = new MonsterPhaseBattleDynamicData(data.Phases[i]);
        }
    }

    //public MonsterBattleDynamicData(string name, DefaultMonsterBattleVisualData visual, AudioClip battleClip, Health health, AttackData[] attackDates)
    //{
    //    Name = name;
    //    Visual = visual;
    //    Attacks = attackDates;
    //    BattleClip = battleClip;
    //    Health = health;
    //    Attacks = attackDates;
    //}


}

public struct MonsterPhaseBattleDynamicData
{
    public string Name { get; private set; }
    public DefaultMonsterBattleVisualData Visual { get; private set; }
    public Health Health { get; private set; }
    public AttackData[] AttackDates { get; private set; }
    public IMonsterActionableOnTakeDamaged TakeDamageAction { get; private set; }
    public IMonsterActionableOnStart StartAction { get; private set; }
    public IMonsterActionableOnDie DieAction { get; private set; }
    public MonsterPhaseBattleDynamicData(MonsterPhaseBattleData data)
    {
        Name = data.Name;
        Visual = data.Visual;
        Health = new Health(data.StartHealth);
        AttackDates = data.Attacks;
        DieAction = data.DieAction;
        TakeDamageAction = data.TakeDamageAction;
        StartAction = data.StartAction;
    }
}