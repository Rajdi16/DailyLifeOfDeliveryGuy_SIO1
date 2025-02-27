using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] int firstItemPrice;
    [SerializeField] int secondItemPrice;
    [SerializeField] int thirdItemPrice;

    int money;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject interactButton;
    bool gameIsPaused;

    [SerializeField] TextMeshProUGUI shopType, item1, item2, item3, price1, price2, price3;
    [SerializeField] string shopTypeName, item1Name, item2Name, item3Name;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
        }
        money = PickUpBox.instance.money ;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            shop.SetActive(true);
            shopType.text = shopTypeName;
            item1.text = item1Name;
            item2.text = item2Name;
            item3.text = item3Name;
            price1.text = firstItemPrice.ToString(); 
            price2.text = secondItemPrice.ToString(); 
            price3.text = thirdItemPrice.ToString();
            Time.timeScale = 0f;
            PickUpBox.instance.firstItemPricePUB = firstItemPrice;
            PickUpBox.instance.secondItemPricePUB = secondItemPrice;
            PickUpBox.instance.thirdItemPricePUB = thirdItemPrice;
        }
        interactButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        shop.SetActive(false);
        interactButton.SetActive(false);
    }


    //Shop
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shop.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void BuyFirstItem()
    {
        if (money >= firstItemPrice)
        {
            PickUpBox.instance.money -= firstItemPrice;
        }
    }
    public void BuySecondItem()
    {
        if (money >= secondItemPrice)
        {
            PickUpBox.instance.money -= secondItemPrice;

        }
    }
    public void BuyThirdItem()
    {
        if (money >= thirdItemPrice)
        {
            PickUpBox.instance.money -= thirdItemPrice;

        }
    }

}
