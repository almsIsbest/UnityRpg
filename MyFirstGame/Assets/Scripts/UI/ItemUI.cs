using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;

    private ItemSO itemSo;

    public void InitItem(ItemSO itemSo)
    {
        
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
        iconImage.sprite = itemSo.icon;
        nameText.text = itemSo.name;
        typeText.text = type;
    }
}
