using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stagemanager : MonoBehaviour {
    [SerializeField]
    public Button[] stagebutton;
    public static bool[] stage= { true,false,false,false};
    public string[] sceenname;

    // Use this for initialization
    void Start () {
        

		for(int i=0;i<stagebutton.Length;i++)
        {
            if(stage[i])
            {
                stagebutton[i].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);//色変更
                stagebutton[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                stagebutton[i].GetComponent<Image>().color = new Color(178.0f / 255.0f, 178.0f / 255.0f, 178.0f / 255.0f, 255.0f / 255.0f);
                stagebutton[i].GetComponent<Button>().interactable = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Button(int i)
    {

        fadeout.fade_ok = true;
        fadeout.next = sceenname[i];
        clear.nowstage = i;

    }
}
