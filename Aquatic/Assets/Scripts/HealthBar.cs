using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Volume healthVolume;
    private Vignette healthVignette;
    public float health, maxHealth, healthVignetteIntensity, maxIntensity;
    public static HealthBar _instance;


    void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

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
