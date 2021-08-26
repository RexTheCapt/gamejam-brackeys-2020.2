using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleId : MonoBehaviour
{
    public TMPro.TMP_Text TitleText;
    public string Id;

    // Start is called before the first frame update
    void Start()
    {
        string s = "";
        string chars = "abcdefghkmnopqrstuvwxyzABCDEFGHKMNOPQRSTUVWXYZ0123456789";

        for (int i = 0; i < 6; i++)
        {
            s += $"{chars[Random.Range(0, chars.Length)]}";
        }

        Id = s;

        TitleText.text = $"{Id}";

        gameObject.name = $"Terminal {Id}";
    }
}
