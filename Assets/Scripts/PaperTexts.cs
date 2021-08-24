using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperTexts : MonoBehaviour
{
    public Level CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            UpdateText();
        }
    }
    public bool ForceUpdateText;
    [SerializeField]
    public TextData[] TextDatas = new TextData[0];
    
    private Level _currentLevel = Level.L0;

    private void UpdateText()
    {
        Text text = gameObject.GetComponentInChildren<Text>();
        
        text.text = TextDatas[((int)_currentLevel)].Text;
        text.fontSize = TextDatas[((int)_currentLevel)].FontSize;
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

    public enum Level
    {
        L0 = 0
    }

    [Serializable]
    public class TextData
    {
        [TextArea]
        public string Text;
        public int FontSize = 50;
    }
}
