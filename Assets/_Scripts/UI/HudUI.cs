using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentGoldText;

    void Start()
    {
        CubeCurrency.OnGoldCubeCollected += UpdatecCurrentGold;
        CubeFactory.OnCubeBuilt += UpdatecCurrentGold;
    }

    void UpdatecCurrentGold()
    {
        currentGoldText.text = GameManager.currentGold.ToString();
    }

}
