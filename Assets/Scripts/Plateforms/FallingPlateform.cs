using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPlateform : MonoBehaviour
{

    private Rigidbody2D plateform;

    private GameObject Player;

    [SerializeField]
    public Animator animator;

    public float delayBeforeActivation = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player = GameObject.FindWithTag("Player");
        Player.GetComponent<Death>().enabled = false;
        plateform = GameObject.FindWithTag("FallingPlateform").GetComponent<Rigidbody2D>();
        plateform.gravityScale = 20;

        StartCoroutine(SwitchScene());
    }

    public IEnumerator SwitchScene()
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(delayBeforeActivation);
        SceneManager.LoadScene("EndingScreen");
    }
}
