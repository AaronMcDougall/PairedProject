using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    //When entity takes damage
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DeathEventFunction();
        }
    }

    public void AddHealth(int health)
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        else currentHealth += health;
    }

    public delegate void Death();
    public event Death DeathEvent;

    public void DeathEventFunction()
    {
        print("OUCH!");
        //Short Version
        DeathEvent?.Invoke();
        if (DeathEvent != null)
        {
            print("OUCH!");
            DeathEvent();
            
        }
    }
    
        //print("Player DIES!");
        //this.transform.rotation = Quaternion.Euler(0, 0, 90);
        //EventManager.DeathEventFunction();
        //other.gameObject.GetComponent<Health>().TakeDamage(100);
    

    

}
