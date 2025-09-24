public class BattleStartedContextData : GameContextData<BattleData>
{
    public BattleStartedContextData(BattleData contextValue) : base(contextValue) { }
}
public struct BattleData
{
    public PlayerBattleData PlayerBattleData {  get; private set; }
    public GroupMonsterBattleDynamicData Monsters {  get; private set; }
    
    public BattleData(PlayerBattleData playerBattleData, GroupMonsterBattleData monsters)
    {
        PlayerBattleData = playerBattleData;
            Monsters = new GroupMonsterBattleDynamicData(monsters);
    }
    public BattleData(PlayerBattleData playerBattleData, GroupMonsterBattleDynamicData monsterBattleData)
    {
        PlayerBattleData = playerBattleData;
        Monsters = monsterBattleData;
    }
}