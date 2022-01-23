using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject alive;

    public ParticleSystem blood;
    public int maxHP;
    int currHP;
    void Start()
    {
        currHP = maxHP;
        alive = transform.Find("Alive").gameObject;
    }
    public void TakeDamage (int damage)
    {
        currHP -= damage;
        // ADD HURT ANIMATION

        if (currHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        blood.Play();
        Destroy(gameObject);
    }

    // MOVEMENT
    private enum State
    {
        Walking,
        Knockback,
        Dead
    }
    
    private void Update()
    {
        switch(currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.Knockback:
                UpdateKnockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }
    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance;
    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;
    [SerializeField]
    private LayerMask whatIsGround;
    private int facingDirection;
    private bool
        groundDetected,
        wallDetected;

    // WALKING STATE
    private void EnterWalkingState()
    {

    }
    private void UpdateWalkingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatIsGround);

        if (!groundDetected || wallDetected)
        {
            Flip();
        }
    }
    private void ExitWalkingState()
    {

    }
    // KNOCKBACK STATE
    private void EnterKnockbackState()
    {

    }
    private void UpdateKnockbackState()
    {

    }
    private void ExitKnockbackState()
    {

    }
    // DEAD STATE
    private void EnterDeadState()
    {

    }
    private void UpdateDeadState()
    {

    }
    private void ExitDeadState()
    {

    }

    // OTHER FUNCTIONS
    private void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f)
    }
    private void SwitchState(State state)
    {
        switch(currentState)
        {
            case State.Walking:
                ExitWalkingState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Walking:
                EnterWalkingState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }
    }
}
