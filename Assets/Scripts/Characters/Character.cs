using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int basePowerLevel;
    [SerializeField] TextMesh powerText;

    [HideInInspector] public int currentPowerLevel;

    private void Start()
    {
        int powerDelta = Random.Range(1, 6);  //Crea un rango aleatorio entre 1 y 5
        currentPowerLevel = basePowerLevel + powerDelta;  //Establece el nivel de poder sumando el poder base con el delta aleatorio
        ChangePowerText();  //Actualiza el UI
    }

    public void BattleVictory(Character target)
    {
        currentPowerLevel += target.currentPowerLevel;  //Suma el poder del target al poder actual
        ChangePowerText();  //Actualiza el UI
    }

    public virtual void BattleDefeat()
    {
        if (gameObject != null) Destroy(gameObject);  //Destruye el GameObject si este no está vacio
    }
    public void ChangePowerText()
    {
        powerText.text = currentPowerLevel.ToString(); //Toma el número de poder y lo lleva a un string
    }
}

