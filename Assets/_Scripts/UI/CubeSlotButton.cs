using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CubeSlotButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Cube Attributes")]
    [SerializeField] private CubeFactory cubeFactory;
    [SerializeField] CubeData cubeData;
    [SerializeField] private float timeToBuy;

    [Header("Button Attributes")]
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Image noGoldImage;
    [SerializeField] private Image timeToBuyImage;
    [SerializeField] private bool isButtonActive = true;

    void Start()
    {
        timeToBuy = cubeData.startTimeToBuy;
        cubeFactory = CubeFactory.instance;
        defaultColor = buttonImage.color;

        IsButtonActive();

        CubeFactory.OnCubeBuilt += SetButton;
        CubeCurrency.OnGoldCubeCollected += SetButton;
    }

    void Update()
    {

        if (timeToBuy <= cubeData.timeToBuy && timeToBuy > 0)
        {
            timeToBuy -= Time.deltaTime;
            timeToBuyImage.fillAmount = timeToBuy / cubeData.timeToBuy;
        }

        if (timeToBuy <= 0 && isButtonActive == false && GameManager.currentGold >= cubeData.cost)
        {
            isButtonActive = true;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameManager.isGamePause == false)
        {
            if (isButtonActive && GameManager.currentGold >= cubeData.cost)
            {
                buttonImage.color = hoverColor;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.isGamePause == false)
        {
            if (isButtonActive && GameManager.currentGold >= cubeData.cost)
            {
                cubeFactory.currentCube = cubeData;

                if (cubeFactory.currentTransparentCube == null)
                {
                    GameObject transparentCube = Instantiate(cubeData.transparentPrefab);
                    cubeFactory.currentTransparentCube = transparentCube;
                }
                else
                {
                    Destroy(cubeFactory.currentTransparentCube);
                }
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GameManager.isGamePause == false)
        {
            if (isButtonActive && GameManager.currentGold >= cubeData.cost)
            {
                buttonImage.color = defaultColor;
            }
        }
    }

    private void SetTimeToBuy()
    {
        if (cubeData == cubeFactory.currentCube)
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
            SetTimeToBuy();
        }
        else if (GameManager.currentGold < cubeData.cost)
        {
            isButtonActive = false;
            noGoldImage.enabled = true;
            SetTimeToBuy();
        }
    }

    private void IsButtonActive()
    {
        if (timeToBuy > 0)
        {
            isButtonActive = false;
        }
    }

}
