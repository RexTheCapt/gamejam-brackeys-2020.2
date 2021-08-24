using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperTexts : MonoBehaviour
{
    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            UpdateText();
        }
    }
    [SerializeField]
    private int _currentLevel = 0;
    public bool ForceUpdateText;
    [SerializeField]
    public TextData[] TextDatas = new TextData[0];

    private void UpdateText()
    {
        Text text = gameObject.GetComponentInChildren<Text>();
        
        text.text = TextDatas[_currentLevel % TextDatas.Length].Text;
        text.fontSize = TextDatas[_currentLevel % TextDatas.Length].FontSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (ForceUpdateText)
        {
            UpdateText();
            ForceUpdateText = false;
        }
    }

    [Serializable]
    public class TextData
    {
        [TextArea]
        public string Text;
        public int FontSize = 50;
    }
}
