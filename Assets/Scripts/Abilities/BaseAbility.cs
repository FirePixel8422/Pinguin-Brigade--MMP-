public abstract class BaseAbility
{
    public string Id { get; protected set; }
    public float Cooldown { get; protected set; }
    public bool IsActive { get; protected set; }
    
    protected float currentCooldown;
    
    public abstract void Activate();
    public abstract void Deactivate();
    
    public virtual void UpdateAbility() {
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
        }
    }
}
