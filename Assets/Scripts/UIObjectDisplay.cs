using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectDisplay : MonoBehaviour
{
	public TMP_Text nameText;
	public TMP_Text damageText;
	public TMP_Text hpText;
	public TMP_Text energyText;
	int MaxHp, MaxEnergy;
    public void SetData(AttributesBase data)
	{
		MaxHp = data.maxHP;
		MaxEnergy = data.maxEnergy;

		nameText.text = data.Name;
		damageText.text = "�����O: "+data.Damage.ToString();
		hpText.text = "HP: " + data.currentHP.ToString() + " / " + data.maxHP.ToString();
		energyText.text = "��q: " + data.currentEnergy.ToString() + " / " + data.maxEnergy.ToString();
	}

	public void SetHP(int hp)
	{
		hpText.text = "HP: " + hp.ToString() + " / " + MaxHp.ToString();
	}

	public void setEnergy(int number)
	{
		energyText.text = "��q: " + number.ToString() + " / " + MaxEnergy.ToString();
	}

}
