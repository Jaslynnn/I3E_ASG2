using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public bool Ui;
    public SamplePlayer player;
    // Start is called before the first frame update
     void Start()
    {
        player.TapToPause();
    }


    public void UIOnScreen()
    {
        Ui = true;
    }
    public void UINotOnScreen()
    {
        player.TapToStart();
    }

}
