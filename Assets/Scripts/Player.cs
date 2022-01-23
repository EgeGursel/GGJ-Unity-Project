using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    public GameObject sword;
    public ParticleSystem dust;
    public Animator animator;
    public Animator animatorsword;
    bool end = false;

    // HEALTH
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;

    // MOVEMENT
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // ATTACK
    public Transform attackArea;
    public float attackRange = 1.05f;
    public LayerMask enemyLayer;
    public int attackDamage = 30;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        // DELETE TO SKIP DIALOGUE
        

        // PLAYER MOVEMENT
        if (end == false) {return; }
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

            // DETECT ENEMIES IN RANGE OF ATTACK
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemyLayer);

            // DAMAGE ENEMIES
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().Damage(attackDamage);
            }
            CameraShake.Instance.Shake(2f, .1f);
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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    public void DialogueEnd()
    {
        end = true;
    }
}

