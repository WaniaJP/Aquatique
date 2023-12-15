using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Volume healthVolume;
    private Vignette healthVignette;
    public float health, maxHealth, healthVignetteIntensity, maxIntensity;

    void Start()
    {
        healthVolume = GetComponent<Volume>();
        healthVolume.profile.TryGet(out healthVignette);
        healthVignetteIntensity = 0f;
        healthVignette.intensity.value = healthVignetteIntensity;
    }

    public void setMaxHealth(float maxHealthValue) {
        maxHealth = maxHealthValue;
        maxIntensity = 0.5f;
    }
    public void setHealth (float healthValue) {
        health = healthValue;
        healthVignette.intensity.value = ((health * maxIntensity) / maxHealth);
    }
}
