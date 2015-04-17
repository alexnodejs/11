using UnityEngine;
using System.Collections;

public abstract class SkillBase
{
    public string name {get; set;}
    public string description {get; set;}
    public KeyCode keyCode {get; set;}
    public float interval {get; set;}
    public float energyConsumption {get; set;}
    public bool isAvailable {get; set;}
    public string iconName {get; set;}
    public Sprite Icon {get; set;}
}