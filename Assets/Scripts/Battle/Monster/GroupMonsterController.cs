using System;

public class GroupMonsterController : MonoBehaviourService
{
    private Monster[] _monsters;
    private int _maxCount;
    public Monster[] Monsters
    {
        get => (Monster[])_monsters.Clone();
        private set
        {
            if (value.Length > _maxCount)
                throw new InvalidOperationException($"Количество элементов в массиве {nameof(Monsters)} больше максимального");
            else
                _monsters = value;
        }
    }

    public void Initialize(int maxCount, Monster[] monsters)
    {
        if (_monsters == null)
            throw new ArgumentNullException($"Аргумент { nameof(monsters)} является {null}");

        _maxCount = maxCount;
        Monsters = monsters;
    }

    public override Type ServiceType => GetType();

}