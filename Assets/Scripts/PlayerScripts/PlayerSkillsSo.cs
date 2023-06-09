using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using SkillEnums;
using UnityEngine;
using Image = UnityEngine.UI.Image;

[CreateAssetMenu]
public class PlayerSkillsSo : ScriptableObject
{
    public string skillId;
    public string skillName;
    public string skillDescription;
    public Sprite skillImage;
    public int skillManaCost;
    public float skillCooldown;
    public int skillRadius;
    public int skillPower;
    public float skillCastingTime;
    public bool isCooldownOn = false;
    public SkillTypes SkillTypes;

}
