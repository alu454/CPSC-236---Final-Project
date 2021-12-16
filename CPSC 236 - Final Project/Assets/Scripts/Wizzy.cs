using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizzy : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public GameObject FloatingScorePrefab;
	public GameObject DamageEffect;


	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		Instantiate(FloatingScorePrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
		Instantiate(DamageEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z+10), Quaternion.identity);
		healthBar.SetHealth(currentHealth);
	}

	public bool CheckIfHealthZero()
    {
		if (currentHealth <= 0)
			return true;
		return false;
    }
}
