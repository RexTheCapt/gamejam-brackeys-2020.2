using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallpaper : MonoBehaviour
{
    public bool ForceUpdateWallPaper = false;
    public Sprite[] WallPapers;

    public int amountofwallpapers;
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

        if (WallPaperIndex > amountofwallpapers)
        {
            WallPaperIndex = amountofwallpapers;
        }

        if (WallPaperIndex < 0)
        {
            WallPaperIndex = 0;
        }
    }

    public void addindex()
    {
        if(WallPaperIndex != amountofwallpapers)
        {
            WallPaperIndex += 1;
            UpdateWallPaper();
        }

        if (WallPaperIndex > amountofwallpapers)
        {
            WallPaperIndex = amountofwallpapers;
        }

        
    }

    public void subindex()
    {
        
        if(WallPaperIndex != 0)
        {
            WallPaperIndex -= 1;
            UpdateWallPaper();
        }

        if (WallPaperIndex < 0)
        {
            WallPaperIndex = 0;
        }
    }

    private void UpdateWallPaper()
    {
        gameObject.GetComponent<Image>().sprite = WallPapers[_wallpaperIndex];
    }

    [SerializeField]
    private int _wallpaperIndex = 0;
}
