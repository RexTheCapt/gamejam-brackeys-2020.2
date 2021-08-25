using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RANDOMMESSAGE : MonoBehaviour
{

    public List<string> messagetexts = new List<string>();
    public Text message;
    
    // Start is called before the first frame update
    void Start()
    {
        messagetexts.Add("AM SCARED");
        messagetexts.Add("GOT LOST LMAO");
        messagetexts.Add("SAMPLE TEXT");
        messagetexts.Add("I SHOULD HAVE WRITTEN A LETTER");
        messagetexts.Add("CAN U TYPE?");
        messagetexts.Add("THEY DIDN'T REPLIED :(");
        messagetexts.Add("TRY YOUR BEST");
        messagetexts.Add("MAYBE TRY DOWNLOADING AN ANTIVIRUS?");
        messagetexts.Add("THAT EXPLAINS WHY NOBODY USED IT");
        messagetexts.Add("JUST WONDERING HOW EXPESIVE THIS PC WAS");
        messagetexts.Add("GAME OVER");

        message.text = messagetexts[Random.Range(0, messagetexts.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
