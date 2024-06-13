using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesBase : MonoBehaviour
{

	public string Name;
	public int Damage;
	public int maxHP;
	public int currentHP;
	public int maxEnergy;
	public int currentEnergy;
	public int EnergyAccumulationValue;
	public int RecoveryValue;


	public bool TakeDamage(int DamageNumber)
	{
		currentHP -= DamageNumber;

		if (currentHP <= 0)
			return true;
		else
			return false;
	} 

	public void Skill(int number)
	{
		currentHP += number;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

	public void setEnergy(int number)
	{
		currentEnergy += number;
		if (currentEnergy > maxEnergy)
			currentEnergy = maxEnergy;
	}

}
