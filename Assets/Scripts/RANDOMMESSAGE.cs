using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RANDOMMESSAGE : MonoBehaviour
{

    public List<string> LossTexts = new List<string>()
    {
        "AM SCARED",
        "GOT LOST LMAO",
        "SAMPLE TEXT",
        "I SHOULD HAVE WRITTEN A LETTER",
        "CAN U TYPE?",
        "THEY DIDN'T REPLIED :(",
        "TRY YOUR BEST",
        "MAYBE TRY DOWNLOADING AN ANTIVIRUS?",
        "THAT EXPLAINS WHY NOBODY USED IT",
        "JUST WONDERING HOW EXPESIVE THIS PC WAS",
        "GAME OVER"
    };
    public List<string> PasteTexts = new List<string>()
    {
        "Sowwy, I dun knuw huw two wo dat >///<"
    };
    public Text message;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerPaste = GameObject.Find("PlayerPasted");
        if (playerPaste)
        {
            Destroy(playerPaste);
            message.text = PasteTexts[Random.Range(0, PasteTexts.Count)];
        }
        else
            message.text = LossTexts[Random.Range(0, LossTexts.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
