using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public Animator animator;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.full[i] == false)
                {
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.full[i] = true;
                    Destroy(gameObject);
                    break;
                } 
            }
        }
    }
}
