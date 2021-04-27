using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quickplay_TutorialCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isQuickplay = true;

    public static Quickplay_TutorialCheck instance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuickplaySelected()
    {
        isQuickplay = true;
    }

    public void TutorialSelected()
    {
        isQuickplay = false; 
    }
}
