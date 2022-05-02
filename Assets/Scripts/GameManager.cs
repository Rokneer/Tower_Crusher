using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player playerScript;
    [SerializeField] GameObject playerObject;
    [SerializeField] Floor playerSpawnFloor;

    public Tower playerTower;
    public GameObject playerFloor;

    [SerializeField] uint enemyAmount;
    //private Floor currentEnemyFloor;

    [SerializeField] GameObject VictoryUI;
    [SerializeField] GameObject DefeatUI;

    /*private void Update()
    {
        currentEnemyFloor = playerObject.GetComponentInParent<Floor>();
    }*/

    private void StartBattle(Player player, Enemy enemy)
    {
        if (player.currentPowerLevel > enemy.currentPowerLevel)
        {
            player.BattleVictory(enemy);  //AÑADE PODER AL JUGADOR Y ACTUALIZA EL UI
            enemy.BattleDefeat();
            --enemyAmount;
            //playerTower.RemoveDefeatedFloors(currentEnemyFloor); No funciona bien :C
            if (enemyAmount == 0)
            {
                VictoryUI.SetActive(true);
                StartCoroutine(RestartLevel());
                Debug.Log("Player Won!");
            }

        }
        else if (player.currentPowerLevel <= enemy.currentPowerLevel)
        {
            enemy.BattleVictory(player); //AÑADE PODER AL ENEMIGO Y ACTUALIZA EL UI
            player.BattleDefeat();
            StartCoroutine(RespawnPlayer());

            if (player.Lives == 0)
            {
                DefeatUI.SetActive(true);
                Debug.Log("Enemy Won!");
                StartCoroutine(RestartLevel());
            }
        }
    }
    public void GetUpgrade(Player player, Upgrade upgrade)
    {
        player.BattleVictory(upgrade);
        upgrade.BattleDefeat();
        Debug.Log("Upgraded!");
    }

    public void MoveToFloor(Floor targetFloor)
    {
        playerObject.transform.SetParent(targetFloor.playerPosition);
        playerObject.transform.localPosition = new Vector3(0, 0, 0);

        if (targetFloor.character is Enemy && targetFloor.character != null) StartBattle(playerScript, targetFloor.character as Enemy);
        else if (targetFloor.character is Upgrade && targetFloor.character != null) GetUpgrade(playerScript, targetFloor.character as Upgrade);
    }

    public IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public IEnumerator RespawnPlayer()
    {
        if(playerObject != null)
        {
            yield return new WaitForSeconds(0.2f);
            playerObject.transform.SetParent(playerSpawnFloor.playerPosition);
            playerObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
