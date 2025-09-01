using UnityEngine;

abstract public class Health
{
    [field : SerializeField] public int CurrentHeath {  get; protected set; }  
    
    public void Damage(int damage)
    {
        if (CurrentHeath - damage > 0)
        {
            CurrentHeath -= damage;
            DeathDetect();
        }
        else
            Death();
    }

    private void DeathDetect()
    {
        if (CurrentHeath > 0)
            Death();
    }

    abstract protected void Death();
}
