using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.name == "Player")
        {
            CompleteLevel();
        }
    }
    void CompleteLevel()
    {
        animator.SetTrigger("Finish");
    }
}
