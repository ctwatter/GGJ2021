using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateTimer : MonoBehaviour
{
    
    public TextMeshProUGUI text;
    void Start()
    {
        text.text = "You only wasted " + PersitentData.Instance.globalTimeLeft + " seconds on this. Splendid.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
