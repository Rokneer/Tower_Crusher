using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected uint basePowerLevel;
    [SerializeField] TextMesh powerText;

    [HideInInspector] public uint currentPowerLevel;

    private void Awake()
    {
        currentPowerLevel = basePowerLevel;
        ChangePowerText();
    }

    public void BattleVictory(Character target)
    {
        currentPowerLevel += target.currentPowerLevel;
        ChangePowerText();
    }

    public virtual void BattleDefeat()
    {
        if (gameObject != null) Destroy(gameObject);
    }
    public void ChangePowerText()
    {
        powerText.text = currentPowerLevel.ToString();
    }
}

