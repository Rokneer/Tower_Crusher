using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    public Character character;
    public Transform playerPosition;
    public Button moverButton;

    public void MoveToFloor()  //Mueve el jugador a el piso deseado al presionar el botón
    {
        GameManager.instance.MoveToFloor(this);  //Hace referencia a la función del GameManager a través de su Singleton
    }
}
