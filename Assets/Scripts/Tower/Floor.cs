using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    public Character character;
    public Transform playerPosition;
    public Button moverButton;

    public void MoveToFloor()  //Mueve el jugador a el piso deseado al presionar el bot�n
    {
        GameManager.instance.MoveToFloor(this);  //Hace referencia a la funci�n del GameManager a trav�s de su Singleton
    }
}
