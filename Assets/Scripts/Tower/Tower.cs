using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Floor> floors;
    [SerializeField] float delta = 1f;
    [SerializeField] private GameManager gameManager;

    public List<Floor> TowerFloors { get => floors; set => floors = value; }
    private void ReorderTower(int floorNumber)
    {
        foreach (Floor floor in TowerFloors)
        {
            int i = 0;
            if (i > floorNumber)
            {
                TowerFloors[i].gameObject.transform.position -= new Vector3(0, -delta, 0);
                --TowerFloors[i].floorIndex;
            }
            i++;
        }
    }
    public void RemoveDefeatedFloors(Floor floor)
    {
        for (int i = (int)floor.floorIndex; i < TowerFloors.Count; i++)
        {
            if(TowerFloors[i].character == null)
            {
                Destroy(TowerFloors[i].gameObject);
                TowerFloors.RemoveAt(i);
                ReorderTower(i);

                int playerFloorAmount = gameManager.playerTower.TowerFloors.Count - 1;
                Vector3 playerFloorPosition = gameManager.playerTower.TowerFloors[playerFloorAmount].transform.localPosition;

                GameObject extraPlayerFloor = Instantiate(gameManager.playerFloor,new Vector3(0, playerFloorPosition.y + delta, 0), Quaternion.identity, gameManager.playerTower.transform);
                gameManager.playerTower.TowerFloors.Add(extraPlayerFloor.GetComponent<Floor>());
                Debug.Log("Added Floor");
            }
        }
    }
}
