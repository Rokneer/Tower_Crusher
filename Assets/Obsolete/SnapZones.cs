using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZones : MonoBehaviour
{
    [SerializeField] private List<Transform> snapZones;
    [SerializeField] float range = 1f;
    [SerializeField] DragDrop player;

    public void DragEnd()
    {
        Transform newSnapZone = null;
        float newDistance = 0;

        foreach (Transform snapZones in snapZones)
        {
            float currentDistance = Vector2.Distance(player.transform.localPosition, snapZones.localPosition);
            if (newSnapZone == null)
            {
                newSnapZone = snapZones;
                newDistance = currentDistance;
                player.transform.localPosition = player.defaultPosition;
            }
            else if (newSnapZone != null && newDistance <= range) player.transform.localPosition = newSnapZone.localPosition;
            else player.transform.localPosition = player.defaultPosition;
        }

    }
}

