using UnityEngine;

public interface IDamageable
{
    public void Damage(int damage, RaycastHit2D hit);

    public void Destroy();
}