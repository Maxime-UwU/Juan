using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class ResetGameButton : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    public float delayBeforeActivation = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.isPressed)
        {
            Debug.Log("reset");
            StartCoroutine(Reset());

        }

        if (Keyboard.current.cKey.isPressed)
        {
            Debug.Log("quit");
            StartCoroutine(QuitGame());
        }
    }

    public IEnumerator Reset()
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(delayBeforeActivation);
        SceneManager.LoadScene("SampleScene");
    }

    public IEnumerator QuitGame()
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(delayBeforeActivation);
        Application.Quit();

    }
}
