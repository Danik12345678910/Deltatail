using System;

public struct PlayerBattleData
{
    public PlayerBattleData(Health health, ArmorItemData armor, AttackItemData attack)
    {
        Armor = default;
        Attack = default;
        Health = default;

        ChangeHealth(health);
        ChangeArmor(armor);
        ChangeAttack(attack);
    }

    public Health Health { get; private set; }
    public ArmorItemData Armor { get; private set; }
    public AttackItemData Attack { get; private set; }

    public void ChangeArmor(ArmorItemData armor)
    {
        if(armor == null) 
            throw new ArgumentNullException($"в методе {nameof(ChangeArmor)}, аргумент {armor} - null");

        Armor = armor;
    }

    public void ChangeHealth(Health health)
    {
        if (health == null)
            throw new ArgumentNullException($"в методе {nameof(ChangeHealth)}, аргумент {health} - null");

        Health = health;
    }

    public void ChangeAttack(AttackItemData attack)
    {
        if (attack == null)
            throw new ArgumentNullException($"в методе {nameof(ChangeAttack)}, аргумент {attack} - null");


        Attack = attack;
    }
}
