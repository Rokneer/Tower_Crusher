using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Singleton del GameManager
    [SerializeField] Player playerScript;
    [SerializeField] GameObject playerObject;
    [SerializeField] Floor playerSpawnFloor;

    public Tower playerTower;
    public GameObject playerFloor;

    [SerializeField] uint enemyAmount;

    [SerializeField] GameObject VictoryUI;
    [SerializeField] GameObject DefeatUI;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this); //Se revisa que solo exista una instancia del GameManager y, de haber otras, se destruyen
        else instance = this;
    }

    private void StartBattle(Player player, Enemy enemy)
    {
        if (player.currentPowerLevel > enemy.currentPowerLevel) //El poder del jugador es mayor que el del enemigo
        {
            player.BattleVictory(enemy);  //Añade poder al jugador y actualiza el UI
            enemy.BattleDefeat();  //Destruye al enemigo derrotado
            --enemyAmount;  //Reduce la cantidad del enemigos del nivel
            StartCoroutine(RespawnPlayer());  //Regresa el jugador a su piso original
            if (enemyAmount == 0) 
            {
                VictoryUI.SetActive(true);  //Activa el UI de victoria
                StartCoroutine(RestartLevel());  //Reinicia el nivel
                Debug.Log("Player Won!");
            }

        }
        else if (player.currentPowerLevel <= enemy.currentPowerLevel) //El poder del enemigo es mayor o igual que el del jugador
        {
            enemy.BattleVictory(player);  //Añade poder al enemigo y actualiza el UI
            player.BattleDefeat();  //Reducen las vidas del jugador al ser derrotado
            StartCoroutine(RespawnPlayer());  //Regresa el jugador a su piso original

            if (player.Lives == 0)
            {
                DefeatUI.SetActive(true); //Activa el UI de derrota
                StartCoroutine(RestartLevel());  //Reinicia el nivel
                Debug.Log("Enemy Won!");
            }
        }
    }
    public void GetUpgrade(Player player, Upgrade upgrade)
    {
        player.BattleVictory(upgrade);  //Añade poder al jugador y actualiza el UI
        upgrade.BattleDefeat();  //Destruye la mejora usada
        Debug.Log("Upgraded!");
    }

    public void MoveToFloor(Floor targetFloor)
    {
        playerObject.transform.SetParent(targetFloor.playerPosition);  //Cambia el Parent del Jugador actualizando su transform al Player Position establecido
        playerObject.transform.localPosition = new Vector3(0, 0, 0);  //Actualiza el transform local del Jugador a 0,0,0

        if (targetFloor.character is Enemy) StartBattle(playerScript, targetFloor.character as Enemy);  //Si el personaje del piso es un enemigo se invoca la pelea entre jugador y enemigo
        else if (targetFloor.character is Upgrade) GetUpgrade(playerScript, targetFloor.character as Upgrade);  //Si el personaje del piso es una mejora se invoca la el obtener mejora
    }
    public IEnumerator RestartLevel() //Espera 5 segundos y se recarga la escena para reiniciar el nivel
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(0.2f);  //Espera 0.2 segundos
        playerObject.transform.SetParent(playerSpawnFloor.playerPosition);  //Cambia el Parent del Jugador devolviendolo a su piso original
        playerObject.transform.localPosition = new Vector3(0, 0, 0);  //Actualiza el transform local del Jugador a 0,0,0
    }
}
