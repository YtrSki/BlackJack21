using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDisplayController : MonoBehaviour
{
    GameObject GAMEMAIN;
    // Start is called before the first frame update
    void Start()
    {
        GAMEMAIN = GameObject.Find("GAMEMAIN");
    }

    // Update is called once per frame
    void Update()
    {
        int getTurn = GAMEMAIN.GetComponent<GAMEMAIN>().GetTurn();

        if (GAMEMAIN.GetComponent<GAMEMAIN>().IsPlayerTurn() && getTurn == 100) //プレイヤーのターン
        {
            transform.position = new Vector3(1, 0, 0);
            GetComponent<TextMesh>().text = "Your Turn";
            GetComponent<TextMesh>().color = new Color(0, 0, 0.75f);
        }
        else if (!GAMEMAIN.GetComponent<GAMEMAIN>().IsPlayerTurn() && getTurn == -100) //コンピュータのターン
        {
            transform.position = new Vector3(1, 0, 5.5f);
            GetComponent<TextMesh>().text = "Enemy Turn";
            GetComponent<TextMesh>().color = new Color(0.75f, 0, 0);
        }
        else if (getTurn == 200) //ジャッジ
        {
            transform.position = new Vector3(1.5f, 0, 2.5f);
            GetComponent<TextMesh>().text = "Judge...";
            GetComponent<TextMesh>().color = new Color(0.75f, 0.75f, 0);
        }
        else if (getTurn == -5) //プレイヤーの勝利
        {
            transform.position = new Vector3(2, 1, 2);
            GetComponent<TextMesh>().text = "WIN!";
            GetComponent<TextMesh>().color = new Color(0, 0, 1);
        }
        else if (getTurn == -6) //コンピュータの勝利
        {
            transform.position = new Vector3(1.75f, 1, 2);
            GetComponent<TextMesh>().text = "LOSE!";
            GetComponent<TextMesh>().color = new Color(1, 0, 0);
        }
        else if (getTurn == -7) //引き分け
        {
            transform.position = new Vector3(1.5f, 1, 2);
            GetComponent<TextMesh>().text = "DRAW";
            GetComponent<TextMesh>().color = new Color(0.75f, 0.75f, 0);
        }
    }


}
