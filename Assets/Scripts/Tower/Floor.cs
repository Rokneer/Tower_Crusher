using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    public Character character;
    public Transform playerPosition;
    public Button moverButton;
    public uint floorIndex;
    [SerializeField] private GameManager gameManager;

    public void MoveToFloor()
    {
        gameManager.MoveToFloor(this);
    }
}
