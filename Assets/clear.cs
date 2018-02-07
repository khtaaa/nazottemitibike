using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour {
    public static int nowstage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    //オブジェクトが衝突したとき
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            fadeout.fade_ok = true;
            fadeout.next = "home";
            stagemanager.stage[nowstage + 1] = true;
        }
    }

}
