using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!TimerOn)
        {
            source.Play();
            TimeLeft = 2f;
            TimerOn = true;
            collision.GetComponent<HealthManager>().TakeDamage(10);
        }
    }
}
