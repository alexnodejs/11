using UnityEngine;
using System.Collections;

public interface IHeroCollision
{
    void OnHeroCollisionEnter(object source, CollisionEventArgs e);
}
