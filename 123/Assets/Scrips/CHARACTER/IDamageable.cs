using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void OnHit(int aggresive, Vector2 konckback);
    public void OnAttack();
     
   
}
