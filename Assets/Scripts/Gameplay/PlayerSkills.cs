using System;
using System.Collections;
using System.Collections.Generic;
using SkillEnums;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Constants;
public class PlayerSkills : MonoBehaviour
{
    
    public List<PlayerSkillsSo> playerSkills = new List<PlayerSkillsSo>();
    private int selectedSkillIndex;
    [SerializeField] private GameObject player;
    #region skillProperties
    public float radius;
    public int manaCost;
    public float cooldown;
    public int power;
    public float castingTime;
    #endregion
    #region TimerVariables
    
    private bool isCasting = false;
    private float cooldownTimer;
    private float castingTimer;
    #endregion
#region Functions

private void Start()
{
    player = GameObject.FindGameObjectWithTag("Player");
    if (playerSkills.Count >Constants.Constants.minNumber)
    {
        PlayerSkillsSo playerSkillsSo = playerSkills[Constants.Constants.minNumber];
        radius = playerSkillsSo.skillRadius;
        manaCost = playerSkillsSo.skillManaCost;
        cooldown = playerSkillsSo.skillCooldown;
        power = playerSkillsSo.skillPower;
        castingTime = playerSkillsSo.skillCastingTime;
    }
    Debug.Log(manaCost);
}

private void Update()
{
    HandleInput();
}
private void UseSkill(PlayerSkillsSo playerSkillsSo)
{Debug.Log("girdi");
    isCasting = true;
    castingTimer = castingTime;
    gameObject.GetComponent<PlayerStats>().currentMana -= manaCost;
    if (playerSkillsSo.SkillTypes ==SkillTypes.Damage)
    {
        ApplyingDamage(playerSkillsSo);
    }
    StartCoroutine(StartSkillCoolDown(playerSkillsSo));
    isCasting = false;

}

private void HandleInput()
{
    if (Input.GetKeyDown(KeyCode.Q))
    {
        if (!isCasting && !playerSkills[0].isCooldownOn)
        {
            StartCoroutine(CheckPlayerCanUseSkill(0));
        }

    }
}

private IEnumerator CheckPlayerCanUseSkill(int skillIndex)
{
    var skill = playerSkills[skillIndex];
    if (skill!=null)
    {
        isCasting = true;
        yield return new WaitForSeconds(skill.skillCastingTime);
        isCasting = false;
        bool isSkillUsable = !isCasting && !skill.isCooldownOn;
        bool isPlayerHasEnoughMana = gameObject.GetComponent<PlayerStats>().currentMana > manaCost;
        if (isSkillUsable && isPlayerHasEnoughMana)
        {
            UseSkill(skill);
            
        }
        //TODO skill casting tamamlandıktan sonra cooldown timer başlat coroutine olarak .  
    }
}
private IEnumerator StartSkillCoolDown(PlayerSkillsSo playerSkillsSo)
{
    yield return new WaitForSeconds(playerSkillsSo.skillCooldown);
    playerSkillsSo.isCooldownOn = false;
}

private void ApplyingDamage(PlayerSkillsSo playerSkillsSo)
{
    float radius = playerSkillsSo.skillRadius;
    int power = playerSkillsSo.skillPower;
    Collider2D[] colliders = Physics2D.OverlapBoxAll(player.transform.position, new Vector2(radius, radius), 0f);
    foreach (Collider2D collider in colliders)
    {
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage(power);
        }
    }
}
#endregion
}
