/// <summary>
/// Interface for all the objects that have health
/// </summary>
public interface IDamagable {
    void Damage(int amount, HitDirection dir = 0);
}