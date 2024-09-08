using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class ItemDetailUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid;
    public GameObject propertyTemplate;
    
    private ItemSO itemSo;
    private ItemUI itemUI;
    
    
    private void Start()
    {
        propertyTemplate.SetActive(false);
        this.gameObject.SetActive(false);
    }

     public void UpdateItemDetailUI(ItemSO itemSo , ItemUI itemUI)
    {
        this.gameObject.SetActive(true);
        this.itemUI = itemUI;
        this.itemSo = itemSo;
        string type = "";
        switch (itemSo.itemType)
        {
            case ItemType.Weapon:
                type = "武器";
                break;
            case ItemType.Consumable:
                type = "消耗品";
                break;
            
        }

        foreach (Transform child in propertyGrid.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }


        iconImage.sprite = itemSo.icon;
        nameText.text = itemSo.name;
        typeText.text = type;
        descriptionText.text = itemSo.description;
        foreach (var property in itemSo.propertyList)
        {
            string propertyStr = "";
            string propertyName ="";
            switch (property.propertyType)
            {
                case ItemPropertyType.HP:
                    propertyName = "生命值";
                    break;
                case ItemPropertyType.Energy:
                    propertyName = "能量值";
                    break;
                case ItemPropertyType.MentalValue:
                    propertyName = "精神值";
                    break;
                case ItemPropertyType.SpeedValue:
                    propertyName = "速度值";
                    break;
                case ItemPropertyType.AttackValue:
                    propertyName = "攻击值";
                    break;
            }
            
            propertyStr += propertyName + " : " + property.value; 
            GameObject propertyGo = GameObject.Instantiate(propertyTemplate, propertyGrid.transform);
            propertyGo.SetActive(true);
            TextMeshProUGUI proUGUI = propertyGo.transform.Find("Property").GetComponent<TextMeshProUGUI>();
            proUGUI.text = propertyStr;
            proUGUI.enabled = true;
        }
    }


    public void OnUseButtonClick()
    {
        InventoryUI.instance.onItemUse(itemSo , itemUI);
        this.gameObject.SetActive(false);
    }
    
}
