using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarManager : MonoBehaviour
{
    [SerializeField] TextMesh lifeText;
    [SerializeField] Player player;

    void Awake()
    {
        LifeBarUpdate();
    }

    public void LifeBarUpdate()
    {
        lifeText.text = player.Lives.ToString();
    }
}
