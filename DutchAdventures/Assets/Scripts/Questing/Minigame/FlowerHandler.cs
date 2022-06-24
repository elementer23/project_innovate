using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerHandler : MonoBehaviour
{

    //public enum FlowerColor { BLUE, ORANGE, PINK, PURPLE, RED, WHITE, YELLOW };

    private enum Tulips { BLUE, RED, YELLOW, PURPLE, WHITE };
    private List<Tulips> collectedTulipList = new List<Tulips>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getNotCollectedTulipColors()
    {
        string dialogue = "I still need the following colors: ";

        //Two loops are used here to properly format the dialogue with ',' and 'and';
        List<string> notCollectedTulips = new List<string>();

        foreach (Tulips tulip in Enum.GetValues(typeof(Tulips)))
        {
            if (collectedTulipList.Contains(tulip))
            {
                continue;
            }
            notCollectedTulips.Add(tulip.ToString());

        }

        for (int i = 0; i < notCollectedTulips.Count; i++)
        {
            if (i > 0)
            {
                if (i == notCollectedTulips.Count - 1)
                {
                    //Next color is last.
                    dialogue += " and ";
                }
                else
                {
                    dialogue += ", ";
                }
            }
            dialogue += notCollectedTulips[i];
        }
        dialogue += ".";
        return dialogue;
    }
}
