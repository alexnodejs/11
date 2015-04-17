using UnityEngine;
using System.Collections;

public class SkillHero : SkillBase
{
    public SkillHero(string name, string icon)
    {
        this.name = name;
        this.Icon = Resources.Load<Sprite>(icon);
    }
}