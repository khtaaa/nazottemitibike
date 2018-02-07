using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nazoru : MonoBehaviour {
    public GameObject line;//lineオブジェクト
    public GameObject damy;//lineダミーオブジェクト
    public float lineL = 0.2f;//長さ
    public float lineW = 0.1f;//幅
    Vector3 Tpos;
    public float linegaze;


    void Start()
    {

    }

    void Update()
    {
        //クリックした場所をTposに代入
        if (Input.GetMouseButtonDown(0))
        {
            Tpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Tpos.z = 0;
        }

        if (Input.GetMouseButton(0))
        {
            //スタート地点（spos）にtposを代入
            Vector3 Spos = Tpos;

            //現在の座標を最終地点（epos）に代入
            Vector3 Epos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Epos.z = 0;

            //スタート地点と最終地点の差がlineの長さより長かったらlineを生成
            if ((Epos - Spos).magnitude > lineL)
            {
                //lineの容量が0以上ならline作成
                if (linegaze > 0)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();
                    GameObject obj = Instantiate(line, (Spos + Epos) / 2 + Vector3.back * 5f, transform.rotation) as GameObject;
                    obj.transform.right = (Epos - Spos).normalized;
                    obj.transform.localScale = new Vector3((Epos - Spos).magnitude, lineW, lineW);
                    obj.transform.parent = this.transform;
                    //プレイヤー、エネミーとlineが重なっていたならlineをダミーに変更
                    if (Physics.Raycast(ray,out hit))
                    {
                        if (hit.collider.CompareTag("player"))
                        {
                            Destroy(obj);
                            obj = Instantiate(damy, (Spos + Epos) / 2 + Vector3.back * 5f, transform.rotation) as GameObject;
                            obj.transform.right = (Epos - Spos).normalized;
                            obj.transform.localScale = new Vector3((Epos - Spos).magnitude, lineW, lineW);
                            obj.transform.parent = this.transform;
                        }
                    }
                }
                Tpos = Epos;
            }
        }
    }

}
