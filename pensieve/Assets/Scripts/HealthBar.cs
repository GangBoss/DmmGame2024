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

        // RectTransform rectTransform = GetComponent<RectTransform>();
        // rectTransform.anchorMin = new Vector2(0, 0);
        // rectTransform.anchorMax = new Vector2(0, 0);
        // rectTransform.pivot = new Vector2(0, 0);
        // rectTransform.anchoredPosition = new Vector2(10, 10);
    }
}