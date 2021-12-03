using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
            Die();
        if (collision.gameObject.CompareTag("Finish"))
            Win();

    }
    private void Die()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }
    private void Win()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Win");
    }


    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
