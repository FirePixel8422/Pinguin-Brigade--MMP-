using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] directionalSprites;


    
    [SerializeField] private CharacterStats characterStats;

    [SerializeField] private float baseMoveSpeed;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private Vector2 moveDir;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveDir = ctx.ReadValue<Vector2>();
    }



    private void Update()
    {
        if (moveDir.y < 0)
        {
            spriteRenderer.sprite = directionalSprites[0];
        }
        else if(moveDir.y > 0)
        {
            spriteRenderer.sprite = directionalSprites[1];
        }


        Vector2 vel = moveDir * baseMoveSpeed;

        rb.velocity = vel;
    }
}
