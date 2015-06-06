using UnityEngine;
using System.Collections;
using Global;

[AddComponentMenu("Global/Characters/ScoutHero")]
public class ScoutHero : Hero
{
    public void DuckModeToggle()
    {
        StopNavAgent();
        CharacterAnimator.SetBool("Duck", !CharacterAnimator.GetBool("Duck"));
    }
}
