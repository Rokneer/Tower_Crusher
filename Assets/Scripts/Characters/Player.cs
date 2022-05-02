using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField]  uint lives;
    [SerializeField] TextMesh lifeText;

    public uint Lives { get => lives; set => lives = value; }

    private void Awake()
    {
        currentPowerLevel = basePowerLevel;
        ChangePowerText();
        LifeBarUpdate();
    }

    public void LifeBarUpdate()
    {
        lifeText.text = Lives.ToString();
    }
    public override void BattleDefeat()
    {
        Lives--;
        LifeBarUpdate();
        if(Lives == 0) Destroy(this);
    }
}

