using UnityEngine;

public abstract class BaseAbility
{
    public string Id { get; protected set; }
    public float Cooldown { get; protected set; }
    public bool IsActive { get; protected set; }
    
    protected float currentCooldown;
    protected ParticleSystem particleEffect;
    protected TrailRenderer trailEffect;
    protected SpriteRenderer abilitySprite;
    protected Color originalColor;
    
    public abstract void Activate();
    public abstract void Deactivate();
    
    public virtual void UpdateAbility() {
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
        }
    }
    
    public virtual void SetupVisuals(GameObject owner) {
        particleEffect = owner.GetComponentInChildren<ParticleSystem>();
        trailEffect = owner.GetComponentInChildren<TrailRenderer>();
        abilitySprite = owner.GetComponentInChildren<SpriteRenderer>();
        
        if (abilitySprite != null) {
            originalColor = abilitySprite.color;
        }
    }

    protected virtual void PlayEffects() {
        if (particleEffect != null) {
            particleEffect.Play();
        }
        if (trailEffect != null) {
            trailEffect.enabled = true;
        }
    }

    protected virtual void StopEffects() {
        if (particleEffect != null) {
            particleEffect.Stop();
        }
        if (trailEffect != null) {
            trailEffect.enabled = false;
        }
    }
}