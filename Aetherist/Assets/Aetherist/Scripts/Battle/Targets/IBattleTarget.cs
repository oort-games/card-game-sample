using UnityEngine;

public interface IBattleTarget
{
    void TakeDamage(uint amount);

    void Heal(uint amount);
}
