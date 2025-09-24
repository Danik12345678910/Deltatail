public interface IMonsterActionableOnTakeDamaged
{
    void Action();
}

public interface IMonsterActionableOnStart
{
    void Action();
}

public interface IMonsterActionableOnDie
{
    void Action();
}

//interface IMonsterActionable : IMonsterActionableOnStart, IMonsterActionableOnTakeDamaged, IMonsterActionableOnDie  {    }