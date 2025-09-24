using System;

public class Health
{
    public int CurrentHeath {  get; private set; }
    public int MaxHeath {  get; private set; }
    public event Action OnDie;
    public bool IsAlive => CurrentHeath > 0;
    
    public void Damage(int damage)
    {
        if(IsAlive)
        {
            if (CurrentHeath - damage > 0)
            {
                CurrentHeath -= damage;
                DeathDetect();
            }
            else
                OnDie?.Invoke();
        }
    }

    public Health(int health)
    { CurrentHeath = health; }

    public void Heal(int heal)
    {
        if (IsAlive && MaxHeath >= CurrentHeath + heal)
            CurrentHeath += heal;
        else if(MaxHeath < CurrentHeath - heal)
            CurrentHeath = MaxHeath;
    }
    private void DeathDetect()
    {
        if (CurrentHeath > 0)
            OnDie?.Invoke();
    }
}
