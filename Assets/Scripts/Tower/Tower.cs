using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private List<Floor> floors;

    public List<Floor> TowerFloors { get => floors; set => floors = value; }

    public void ExecuteHideFloor() //Se encapsula la corrutina para que pueda ser ejecutada por botones
    {
        StartCoroutine(HideFloor());
    }
    private IEnumerator HideFloor()
    {
        yield return new WaitForSeconds(0.4f); //Se esperan 0.4 segundos
        for (int i = 0; i < TowerFloors.Count; i++)  //Se recorre la lista de pisos
        {
            if (TowerFloors[i].character == null)  //Se revisa si hay un dentro del piso
            {
                TowerFloors[i].gameObject.SetActive(false);  //Se desactiva el piso de la torre
                TowerFloors.RemoveAt(i);  //Se remueve el piso de la lista de pisos
            }
        }
    }
}
