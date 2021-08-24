using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallpaper : MonoBehaviour
{
    public bool ForceUpdateWallPaper = false;
    public Sprite[] WallPapers;
    public int WallPaperIndex
    {
        get => _wallpaperIndex;
        set
        {
            _wallpaperIndex = value;
            UpdateWallPaper();
        }
    }

    public void Start()
    {
        UpdateWallPaper();
    }

    public void Update()
    {
        if (ForceUpdateWallPaper)
        {
            UpdateWallPaper();
            ForceUpdateWallPaper = false;
        }
    }
    private void UpdateWallPaper()
    {
        gameObject.GetComponent<Image>().sprite = WallPapers[_wallpaperIndex];
    }

    [SerializeField]
    private int _wallpaperIndex = 0;
}
