using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
    void Kill();
    void healPlayer(int heal);
}
