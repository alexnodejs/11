using UnityEngine;
using System.Collections;
using Global;

[AddComponentMenu("Global/Characters/TechBotHero")]
public class TechBotHero : Hero, IRepairable
{
    public enum TechBotControlState
    {
        Basic = 0,
        Repair
    }

    public TechBotControlState BotControlState;

    protected override void Init()
    {
        base.Init();

        BotControlState = TechBotControlState.Basic;
    }

    public void SetBotControlState(int state)
    {
        BotControlState = (TechBotControlState)state;
    }

    public void Repair()
    {
        
    }
}
