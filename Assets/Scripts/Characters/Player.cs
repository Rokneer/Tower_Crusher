using UnityEngine;

public class Player : Character //Hereda de Character
{
    [SerializeField]  uint lives;
    [SerializeField] TextMesh lifeText;

    public uint Lives { get => lives; set => lives = value; }

    private void Awake()
    {
        ChangePowerText(); //Actualiza el UI del poder
        LifeBarUpdate();  //Actualiza el UI de la vida
    }

    public void LifeBarUpdate()
    {
        lifeText.text = Lives.ToString();  //Toma el número de vidas y lo lleva a un string
    }
    public override void BattleDefeat() //Hace Override a la función BattleDefeat para cambiar su funcionalidad
    {
        Lives--;  //Decrementa el número de vidas
        LifeBarUpdate();  //Actualiza el UI de la vida
        if (Lives == 0) Destroy(this);  //Si las vidas son 0 destruye el Script
    }
}

