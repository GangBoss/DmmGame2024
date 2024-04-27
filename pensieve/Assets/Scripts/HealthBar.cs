using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider healthSlider;

    public GameObject healthProvider;
    private Health health;

    void Start()
    {
        health=healthProvider.GetComponent<Health>();
        healthSlider.maxValue = health.maxHealth;
        health.OnDamage += ()=>healthSlider.value=health.currentHealth;
    }
}