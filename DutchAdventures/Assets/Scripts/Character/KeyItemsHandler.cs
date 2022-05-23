using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemsHandler : MonoBehaviour
{
    // Start is called before the first frame 
    public Dictionary<string, bool> items = new Dictionary<string, bool>();
    
    //Add items to keyItemsHandler
    void Start()
    {
        items.Add("Jerrycan", false);
        items.Add("Wrench", false);

    }
}
