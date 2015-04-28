using UnityEngine;
using System.Collections;

public interface ISkillActivatedListener
{
    void OnSkillActivated(object source, SkillEventArgs e);
}