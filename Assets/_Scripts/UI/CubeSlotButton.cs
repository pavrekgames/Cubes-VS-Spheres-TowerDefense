using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CubeSlotButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private CubeFactoryTest cubeFactory;
    [SerializeField] CubeData cubeData;
    [SerializeField] private bool isButtonActive = true;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Image noGoldImage;
    [SerializeField] private Image timeToBuyImage;

    [SerializeField] private float timeToBuy;

    void Start()
    {
        timeToBuy = 0;
        cubeFactory = CubeFactoryTest.instance;
        defaultColor = buttonImage.color;

        CubeFactoryTest.OnCubeBuilt += SetTimeToBuy;
        CubeFactoryTest.OnCubeBuilt += SetButton;
        CubeCurrency.OnGoldCubeCollected += SetButton;
    }

    
    void Update()
    {

        if(timeToBuy <= cubeData.timeToBuy && timeToBuy > 0)
        {
            timeToBuy -= Time.deltaTime;
            timeToBuyImage.fillAmount = timeToBuy / cubeData.timeToBuy;
        }

        if(timeToBuy <= 0 && isButtonActive == false && GameManager.currentGold >= cubeData.cost)
        {
            isButtonActive = true;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isButtonActive && GameManager.currentGold >= cubeData.cost)
        {
            buttonImage.color = hoverColor;
        } 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isButtonActive && GameManager.currentGold >= cubeData.cost)
        {
            cubeFactory.currentCube = cubeData;
        }  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isButtonActive && GameManager.currentGold >= cubeData.cost)
        {
            buttonImage.color = defaultColor;
        }
        
    }

    private void SetTimeToBuy()
    {
        if(cubeData == cubeFactory.currentCube)
        {
            timeToBuy = cubeData.timeToBuy;
            isButtonActive = false;
        }
    }

    private void SetButton()
    {
        if (GameManager.currentGold >= cubeData.cost)
        {
            isButtonActive = true;
            noGoldImage.enabled = false;
        }
        else if (GameManager.currentGold < cubeData.cost)
        {
            isButtonActive = false;
            noGoldImage.enabled = true;
        }
    }
  
}
