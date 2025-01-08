using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlateform : MonoBehaviour
{

    private Rigidbody2D plateform;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        plateform = GameObject.FindWithTag("FallingPlateform").GetComponent<Rigidbody2D>();

        plateform.gravityScale = 20;
    }
}
