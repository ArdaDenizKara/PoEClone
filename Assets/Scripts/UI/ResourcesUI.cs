using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{ public PlayerStats playerstats;
    [SerializeField] private GameObject player;
    [SerializeField]
    private Text currentHealthText;
    [SerializeField]
    private Text currentManaText;
    [SerializeField]
    private Text currentExperinceText;
    [SerializeField]
    private Image healthBarImage;
    [SerializeField]
    private Image manaBarImage;
    [SerializeField]
    private Image experienceBarImage;

    [SerializeField] private Image skillImage1;
    // [SerializeField] private Image skillImage2;
    // [SerializeField] private Image skillImage3;
    private void Start()
    {
        var skillImage = player.GetComponent<PlayerSkills>().playerSkills[0].skillImage;
        skillImage1.sprite = skillImage;
    }

    private void Update()
    {
        currentHealthText.text = playerstats.currentHealth.ToString() + " / " + playerstats.maxHealth.ToString();
        currentManaText.text = playerstats.currentMana.ToString() + " / " + playerstats.maxMana.ToString();
        healthBarImage.fillAmount = (float)playerstats.currentHealth /  (float)playerstats.maxHealth;
        manaBarImage.fillAmount = (float)playerstats.currentMana / (float)playerstats.maxMana;
        currentExperinceText.text =" Experience " + playerstats.currentExperience.ToString() + " / " + playerstats.neededExperince.ToString();
        experienceBarImage.fillAmount = (float)playerstats.currentExperience / (float)playerstats.neededExperince;
        
    }
}
