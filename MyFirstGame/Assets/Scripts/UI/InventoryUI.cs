using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    
    private GameObject uiGameObject;
    public static InventoryUI instance { get; private set; }

    private GameObject content;
    public GameObject itemPrefab;
    public ItemDetailUI itemDetailUI;

    public bool isShow = false;
    
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject; 
        content = transform.Find("UI/ListBg/Scroll View/Viewport/Content").gameObject;
        hide();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isShow)
            {
                hide();
                isShow = false;
            }
            else
            {
                show();
                isShow = true;
            }
        }
    }

    public void show()
    {
        uiGameObject.SetActive(true);
    }

    public void hide()
    {
        uiGameObject.SetActive(false);
    }
    
    
    public void AddItem(ItemSO itemSo)
    {
        GameObject itemGo = GameObject.Instantiate(itemPrefab);
        itemGo.transform.parent  = content.transform;
        ItemUI itemUi = itemGo.GetComponent<ItemUI>();

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

        Debug.Log("itemSo.icon : " + itemSo.icon + " itemSo.name : " + itemSo.name + " type : " + type);
        Debug.Log("itemUI :" + itemUi);
        itemUi.InitItem(itemSo);
    }


    public void OnItemClick(ItemSO itemSo , ItemUI itemUI)
    {
        itemDetailUI.UpdateItemDetailUI(itemSo , itemUI);
    }
    
    
    public void onItemUse(ItemSO itemSo , ItemUI itemUI)
    {
        Destroy(itemUI.gameObject);
        InventoryManager.instance.RemoveItem(itemSo);
        
    }
  
}
