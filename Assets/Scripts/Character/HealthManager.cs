using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 100f;
    public AudioSource sourceHeal;

    private float DamageTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        sourceHeal = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (DamageTimer > 0)
        {
            DamageTimer -= Time.deltaTime;
        }
        else
        {
            DamageTimer = 5f;
            TakeDamage(5);

        }

        if (healthAmount <= 0)
        {
            //_rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    public void TakeDamage(float _damage)
    {
        healthAmount -= _damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float _healingAmmount)
    {
        sourceHeal.Play();
        healthAmount += _healingAmmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
