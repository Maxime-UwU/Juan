using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<HealthManager>().Heal(20);

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }


    }
}
