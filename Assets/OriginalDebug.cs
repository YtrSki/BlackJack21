using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OriginalDebug : MonoBehaviour
{
    GameObject GAMEMAIN;
    GameObject debugCaseNum;

    // Start is called before the first frame update
    void Start()
    {
        debugCaseNum = GameObject.Find("Debug_CaseNumber");
        GAMEMAIN = GameObject.Find("GAMEMAIN");
    }

    // Update is called once per frame
    void Update()
    {
        /****デバッグ****/
        debugCaseNum.GetComponent<Text>().text = "turn = " + GAMEMAIN.GetComponent<GAMEMAIN>().GetTurn() + " jD = " + GAMEMAIN.GetComponent<GAMEMAIN>().judgeDelay;
        /****************/
    }
}
