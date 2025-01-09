using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField]
    private Transform m_Player;

    [SerializeField]
    public Animator animator;

    public float delayBeforeActivation = 1f;

    [SerializeField]
    public AudioSource sourceDeath;


    // Start is called before the first frame update
    void Start()
    {
        //sourceDeath = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Player.position.y <= -7)
        {
            StartCoroutine(DeathReload());

        }
    }

    public IEnumerator DeathReload()
    {
        sourceDeath.Play();
        animator.SetTrigger("End");
        yield return new WaitForSeconds(delayBeforeActivation);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
