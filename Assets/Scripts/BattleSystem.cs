using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {
	StartBattle,
	isPlayerTurn, 
	isEnemyTurnTurn,
	Win,
	Lost 
}

public class BattleSystem : MonoBehaviour
{
	public BattleState battleState;
	public GameObject playerObject;
	public GameObject enemyObject;
	public Transform playerBattlePosition;
	public Transform enemyBattlePosition;
	public UIObjectDisplay playerUIDisplay;
	public UIObjectDisplay enemyUIDisplay;
	public TMP_Text ShowTurnText;

	Player playerAttributes;
	Enemy enemyAttributes;

    // Start is called before the first frame update
    public void Start()
    {
		battleState = BattleState.StartBattle;
		StartCoroutine(InitBattle());
    }

	public IEnumerator InitBattle()
	{
		GameObject playerGO = Instantiate(playerObject, playerBattlePosition);
		playerAttributes = playerGO.GetComponent<Player>();

		GameObject enemyGO = Instantiate(enemyObject, enemyBattlePosition);
		enemyAttributes = enemyGO.GetComponent<Enemy>();

		ShowTurnText.text = " 遇到" + enemyAttributes.Name;

		playerUIDisplay.SetData(playerAttributes);
		enemyUIDisplay.SetData(enemyAttributes);

		yield return new WaitForSeconds(2f);

		battleState = BattleState.isPlayerTurn;
		PlayerTurn();
	}
	public void PlayerTurn()
	{
		ShowTurnText.text = "選擇你的行動:";
	}

	public IEnumerator PlayerAttack()
	{
		bool isDead = enemyAttributes.TakeDamage(playerAttributes.Damage);

		enemyUIDisplay.SetHP(enemyAttributes.currentHP);
		ShowTurnText.text = "攻擊成功!!";

		playerAttributes.setEnergy(playerAttributes.EnergyAccumulationValue);
		playerUIDisplay.setEnergy(playerAttributes.currentEnergy);

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			battleState = BattleState.Win;
			EndBattle();
		} else
		{
			battleState = BattleState.isEnemyTurnTurn;
			StartCoroutine(EnemyTurn());
		}
	}

	public IEnumerator PlayerSkill()
	{
		playerAttributes.Skill(playerAttributes.RecoveryValue);
		playerUIDisplay.SetHP(playerAttributes.currentHP);

		playerAttributes.setEnergy(-playerAttributes.maxEnergy);
		playerUIDisplay.setEnergy(playerAttributes.currentEnergy);

		ShowTurnText.text = "使用了技能!!";

		yield return new WaitForSeconds(2f);
		StartCoroutine(PlayerAttack());
	}

	public IEnumerator EnemyTurn()
	{
		if(enemyAttributes.currentEnergy == enemyAttributes.maxEnergy)
        {
			enemyAttributes.Skill(enemyAttributes.RecoveryValue);
			enemyUIDisplay.SetHP(enemyAttributes.currentHP);

			enemyAttributes.setEnergy(-enemyAttributes.maxEnergy);
			enemyUIDisplay.setEnergy(enemyAttributes.currentEnergy);

			ShowTurnText.text = enemyAttributes.Name + " 使用了技能!!";
		}

		yield return new WaitForSeconds(2f);

		ShowTurnText.text = enemyAttributes.Name + " 使用了攻擊!!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerAttributes.TakeDamage(enemyAttributes.Damage);
		playerUIDisplay.SetHP(playerAttributes.currentHP);
		enemyAttributes.setEnergy(enemyAttributes.EnergyAccumulationValue);
		enemyUIDisplay.setEnergy(enemyAttributes.currentEnergy);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			battleState = BattleState.Lost;
			EndBattle();
		} else
		{
			battleState = BattleState.isPlayerTurn;
			PlayerTurn();
		}

	}

	public void EndBattle()
	{
		if(battleState == BattleState.Win)
		{
			ShowTurnText.text = "你贏了!";
		} else if (battleState == BattleState.Lost)
		{
			ShowTurnText.text = "你輸了!";
		}
	}

	


	public void OnAttackButton()
	{
		if (battleState != BattleState.isPlayerTurn)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnSkillButton()
	{
		Debug.Log("OnSkillButton/F:");
		if (battleState != BattleState.isPlayerTurn)
			return;

		Debug.Log("OnSkillButton/F2:");
		if (playerAttributes.currentEnergy == playerAttributes.maxEnergy)
        {
			Debug.Log("OnSkillButton/E1:");
			StartCoroutine(PlayerSkill());
		}
		else
        {
			Debug.Log("OnSkillButton/E2:");
			ShowTurnText.text =  "使用技能失敗!!";
			Invoke("PlayerTurn", 1f);
		}
		
	}

}
