using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI nameText; //对话的名字组件

    [SerializeField] private TextMeshProUGUI contentText; //内容的组件

    [SerializeField] private Button ContinueButton;

    [SerializeField] private List<string> contentList;

    private int contentIndex = 0;
    private GameObject uiGameObject;
    
    
    private void Awake()
    {
        Debug.Log("初始化dialogueUI");
        instance = this;
        Debug.Log("instace" + instance);
        
    }
    
    private void Start()
    {
        Debug.Log("单例模式进来了");
        // gameObject.SetActive(false);
        nameText = transform.Find("UI/NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/ContentText").GetComponent<TextMeshProUGUI>();
        ContinueButton = transform.Find("UI/ContinueButton").GetComponent<Button>();
        ContinueButton.onClick.AddListener(OnContinueButtonClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }


    public void show()
    {
        gameObject.SetActive(true);
    }

    public void show(string name, string[] content)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentText.text = contentList[0];
        uiGameObject.SetActive(true);
    }


    public void Hide()
    {
        uiGameObject.SetActive(false);
    }
    
    
    private void OnContinueButtonClick()
    {
        contentIndex++;
        if (contentIndex >= contentList.Count)
        {
            Hide();
            contentIndex = 0;
            return;
        }
        contentText.text = contentList[contentIndex];
    }
    
}