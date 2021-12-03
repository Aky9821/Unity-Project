using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    Animator anim;
    private float dirX = 0f, dirY = 0f;
    private SpriteRenderer sprite;
    private float moveSpeed = 7f, jumpforce = 14f;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpablePrompt;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        if (Input.GetKeyDown("space") && isGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpforce);

        }

        updateAnnimation();
    }
    private void updateAnnimation()
    {


        if (dirX > 0f)
        {
            anim.SetBool("walk", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("walk", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (player.velocity.y > 0.0001f)
        {
            anim.SetBool("jump", true);

        }
        else if (player.velocity.y < -0.0001f)
        {
            anim.SetBool("jump", true);

        }
        else
        {
            anim.SetBool("jump", false);
        }

    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpablePrompt);

    }

}
