using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    public GameObject sword;
    public int currentHealth;
    public CharacterController2D controller;
    public ParticleSystem dust;
    public Animator animator;
    public Animator animatorsword;
    public Slider healthslider;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();


    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
    void FixedUpdate()
    {
        // MOVE CHARACTER
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void CreateDust()
    {
        dust.Play();
    }
    void Attack()
    {
        if (inventory.slots[0].transform.childCount > 0)
        {
            sword.SetActive(true);
            animatorsword.SetTrigger("Attack");
            return;
        }
        if (inventory.slots[1].transform.childCount > 0)
        {
            //ADD NEW WEAPON(S)
            // sword.SetActive(true);
            return;
        }
        else
        {
            return;
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    public void SetMaxHealth(int health)
    {
        healthslider.maxValue = health;
        healthslider.value = health;
    }
    public void SetHealth(int health)
    {
        healthslider.value = health;
    }
}

