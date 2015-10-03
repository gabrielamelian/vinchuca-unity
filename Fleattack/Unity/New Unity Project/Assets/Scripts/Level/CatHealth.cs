using UnityEngine;
using System.Collections;

public class CatHealth : MonoBehaviour {

	public int CatMaxHealth;
	public int CatCurrentHealth;
	
	void Start () {
		CatCurrentHealth = CatMaxHealth;
	}

	public void ReceiveDamage(int Damage)
	{
		CatCurrentHealth -= Damage;
		Debug.Log ("Health: " + CatCurrentHealth);

		if (CatCurrentHealth <= 0)
		{
			KillCat();
		}
	}

	void KillCat()
	{
		Debug.Log ("THE CAT IS DEAD");
	}

}
