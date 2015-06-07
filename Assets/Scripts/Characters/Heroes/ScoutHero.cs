using UnityEngine;
using System.Collections;
using Global;
using ICode;

[AddComponentMenu("Global/Characters/ScoutHero")]
public class ScoutHero : Hero
{
    public enum MoveState
    {
        Walk,
        Run,
        Duck
    }

    private float walkSpeed = 2f;
    private float runSpeed = 5f;
    private bool isRunMode = false;
    private ICodeBehaviour behavior;

    protected override void Init()
    {
        base.Init();

        behavior = gameObject.GetBehaviour();
    }

    public void DuckModeToggle()
    {
        StopNavAgent();

        if (behavior.ActiveNode.Equals(behavior.stateMachine.GetNode("Duck")))
        {
            behavior.SetNode("Walk");
        }
        else
        {
            behavior.SetNode("Duck");
        }
    }

    public void ScoutRunToggle()
    {
        StopNavAgent();

        if (behavior.ActiveNode.Equals(behavior.stateMachine.GetNode("Run")))
        {
            behavior.SetNode("Walk");
        }
        else
        {
            behavior.SetNode("Run");
        }
    }
}
