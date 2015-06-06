using UnityEngine;
using System.Collections;
using Global;

[AddComponentMenu("Global/Characters/ScoutHero")]
public class ScoutHero : Hero
{
    private float walkSpeed = 2f;
    private float runSpeed = 5f;
    private bool isRunMode = false;

    public void DuckModeToggle()
    {
        StopNavAgent();
        CharacterAnimator.SetBool("Duck", !CharacterAnimator.GetBool("Duck"));
    }

    public void ScoutRunToggle()
    {
        isRunMode = !isRunMode;
        if (isRunMode)
        {
            NavAgent.speed = runSpeed;
        }
        else
        {
            NavAgent.speed = walkSpeed;
        }
    }
}
