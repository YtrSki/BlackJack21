using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GAMEMAIN : MonoBehaviour
{
    private int[] deck = new int[11] {0,0,0,0,0,0,0,0,0,0,0};
    private int turn = 0;
    private int playerNumOfHand = 0;
    private int computerNumOfHand = 0;
    private int goal = 21;
    private int skipped = 0;

    private bool isPlayerTurn = true;

    private int testDelay = 0;
    public int judgeDelay = 0; //一時的にpublic

    GameObject PlayerController;
    GameObject ComputerController;
    GameObject displayTurn;
    Button button_AddCard;
    Button button_Skip;
    GameObject CameraController;

    public GameObject sumOfHand;
    private GameObject playerSumOfHand;
    private GameObject computerSumOfHand;

    // Start is called before the first frame update
    void Start()
    {
        //GameObjectを探してインポート
        PlayerController = GameObject.Find("PlayerController");
        ComputerController = GameObject.Find("ComputerController");
        displayTurn = GameObject.Find("displayTurn");
        button_AddCard = GameObject.Find("Button_AddCard").GetComponent<Button>();
        button_Skip = GameObject.Find("Button_Skip").GetComponent<Button>();
        CameraController = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        switch (turn)
        {
            default: //ジャッジターン

                /***テスト***
                if (Input.GetMouseButtonUp(0) && playerNumOfHand <= 5)
                    PlayerDrawsCard();
                if (Input.GetMouseButtonUp(1) && playerNumOfHand > 0)
                    PlayerReturnsLastCard();

                if (Input.GetKeyUp(KeyCode.Space) && computerNumOfHand <= 5)
                    ComputerDrawsCard();
                if (Input.GetKeyUp(KeyCode.Return) && computerNumOfHand > 0)
                    ComputerReturnsLastCard();
                ************/


                break;

            case 0: //開始準備、先攻・後攻の決定
                button_AddCard.interactable = true;
                button_Skip.interactable = true;

                /***初期化***/
                testDelay = 0;
                playerNumOfHand = 0;
                computerNumOfHand = 0;
                for(int i=0; i<11; i++)
                    deck[i] = 0;
                /************/

                int firstTurn = new System.Random().Next(0, 2);
                if (firstTurn == 0) //先攻がプレイヤーの時
                {
                    isPlayerTurn = true;
                    PlayerDrawsCard();
                    ComputerDrawsCard();
                    turn = 100;
                }
                else //コンピュータが先攻
                {
                    isPlayerTurn = false;
                    PlayerDrawsCard();
                    ComputerDrawsCard();
                    turn = -100;
                }

                Debug.Log("StartIsPlayerTurn = " + isPlayerTurn);

                break;

            case 100: //プレイヤーのターン
                if (skipped >= 2) turn = 200;
                break;

            case -100: //コンピュータのターン

                /*** テスト ***/
                if (skipped >= 2) turn = 200;
                else ComputerThinking();
                /**************/

                break;

            case 200: //ジャッジターン
                button_AddCard.interactable = false;
                button_Skip.interactable = false;
                Judge();
                break;

            case -5: //プレイヤーの勝利
                if (judgeDelay++ > 240 && judgeDelay <= 300)
                {
                    playerSumOfHand.GetComponent<SumOfHandDisplay>().IsBackToDeck();
                    computerSumOfHand.GetComponent<SumOfHandDisplay>().IsBackToDeck();
                    PlayerController.GetComponent<PlayerController>().ReturnAllCard();
                    ComputerController.GetComponent<ComputerController>().ReturnAllCard();
                }
                if (judgeDelay > 300)
                {
                    CameraController.GetComponent<CameraController>().ZoomOut();
                    turn = 0;
                    judgeDelay = 0;
                }
                break;

            case -6: //コンピュータの勝利
                if (judgeDelay++ > 240 && judgeDelay <= 300)
                {
                    playerSumOfHand.GetComponent<SumOfHandDisplay>().IsBackToDeck();
                    computerSumOfHand.GetComponent<SumOfHandDisplay>().IsBackToDeck();
                    PlayerController.GetComponent<PlayerController>().ReturnAllCard();
                    ComputerController.GetComponent<ComputerController>().ReturnAllCard();
                }
                if (judgeDelay > 300)
                {
                    CameraController.GetComponent<CameraController>().ZoomOut();
                    turn = 0;
                    judgeDelay = 0;
                }
                break;

            case -7: //引き分け
                if (judgeDelay++ > 240 && judgeDelay <= 300)
                {
                    playerSumOfHand.GetComponent<SumOfHandDisplay>().IsBackToDeck();
                    computerSumOfHand.GetComponent<SumOfHandDisplay>().IsBackToDeck();
                    PlayerController.GetComponent<PlayerController>().ReturnAllCard();
                    ComputerController.GetComponent<ComputerController>().ReturnAllCard();
                }
                if (judgeDelay > 300)
                {
                    CameraController.GetComponent<CameraController>().ZoomOut();
                    turn = 0;
                    judgeDelay = 0;
                }
                break;
        }
    }

    void PlayerDrawsCard()
    {
        int num = RandomDrawCard();
        PlayerController.GetComponent<PlayerController>().ReceiveCard(num);
        playerNumOfHand++;
        deck[num - 1] = 1;
        skipped = 0;
    }

    void ComputerDrawsCard()
    {
        int num = RandomDrawCard();
        ComputerController.GetComponent<ComputerController>().ReceiveCard(num);
        computerNumOfHand++;
        deck[num - 1] = 2;
        skipped = 0;
    }

    void PlayerReturnsLastCard()
    {
        if (playerNumOfHand > 1)
        {
            deck[PlayerController.GetComponent<PlayerController>().ReturnLastCard() - 1] = 0;
            playerNumOfHand--;
        }

    }

    void ComputerReturnsLastCard()
    {
        if (computerNumOfHand > 1)
        {
            deck[ComputerController.GetComponent<ComputerController>().ReturnLastCard() - 1] = 0;
            computerNumOfHand--;
        }
    }

    int RandomDrawCard() //1-11の中から山札にない数字をランダムに選んで返す
    {
        Top:
        System.Random rnd = new System.Random();
        int selected = rnd.Next(1,12);
        if (deck[selected - 1] != 0) goto Top; //山札になかった(値が0以外)なら選びなおし
        return selected;
    }

    void PlayerSkipped()
    {
        skipped++;
        TurnChange();
    }

    /*
    void ComputerSkipped()
    {
        TurnChange();
        //isPlayerTurn = true;
    }
    */

    void TurnChange() {
        if (skipped >= 2) turn = 200;
        else
        {
            turn *= -1;

            testDelay = 0;

            isPlayerTurn = isPlayerTurn ? false : true;
            Debug.Log("isPlayerTurn(TurnChange()) = " + isPlayerTurn);
        }
    }

    public void TappedPlusButton()
    {
        if (isPlayerTurn && playerNumOfHand <= 5 && turn == 100)
        {
            PlayerDrawsCard();
            //isPlayerTurn = false;
            TurnChange();
        }
    }

    public void TappedSkipButton()
    {
        if (isPlayerTurn && turn == 100)
        {
            //isPlayerTurn = false;
            PlayerSkipped();
        }
    }

    void ComputerThinking()
    {
        if (testDelay++ > 60)
        {
            if (ComputerController.GetComponent<ComputerController>().ComputerDrawRate()
                && computerNumOfHand <= 5) ComputerDrawsCard();
            else skipped++;
            TurnChange();
        }
    }

    void Judge()
    {
        judgeDelay++;
        if (judgeDelay == 1) CameraController.GetComponent<CameraController>().ZoomIn();
        if (judgeDelay > 120 && judgeDelay <= 300)
        {
            ComputerController.GetComponent<ComputerController>().ReveilFirstCard();

            int playerSum = PlayerController.GetComponent<PlayerController>().SumOfHandCard(),
                computerSum = ComputerController.GetComponent<ComputerController>().SumOfHandCard();

            if (playerSum == computerSum) Draw();//ドロー
            else if (playerSum <= goal && computerSum <= goal) //どちらもバーストしていない場合
            {
                if (playerSum > computerSum) PlayerWin();//プレイヤーの勝利
                if (playerSum < computerSum) ComputerWin();//コンピュータの勝利
            }
            else if (playerSum > goal && computerSum <= goal) ComputerWin();//プレイヤーがバーストした
            else if (computerSum > goal && playerSum <= goal) PlayerWin();//コンピュータがバーストした
            else if (playerSum > goal && computerSum > goal) //両方バーストした場合
            {
                if (playerSum < computerSum) PlayerWin();//プレイヤーの勝利
                else ComputerWin();//コンピュータの勝利
            }
            else Draw();//ドロー

            DisplayTheirSum();
            judgeDelay = 0;
        }
    }

    void PlayerWin()
    {
        Debug.Log("Player Win!");
        turn = -5;
    }

    void ComputerWin()
    {
        Debug.Log("Computer Win!");
        turn = -6;
    }

    void Draw()
    {
        Debug.Log("Draw");
        turn = -7;
    }

    void DisplayTheirSum()
    {
        playerSumOfHand = Instantiate(sumOfHand) as GameObject;
        computerSumOfHand = Instantiate(sumOfHand) as GameObject;
        playerSumOfHand.GetComponent<SumOfHandDisplay>().SetSum(PlayerController.GetComponent<PlayerController>().SumOfHandCard());
        computerSumOfHand.GetComponent<SumOfHandDisplay>().SetSum(ComputerController.GetComponent<ComputerController>().SumOfHandCard());
        computerSumOfHand.GetComponent<SumOfHandDisplay>().IsComputer();
        if (turn == -5) playerSumOfHand.GetComponent<SumOfHandDisplay>().DidWin();
        if (turn == -6) computerSumOfHand.GetComponent<SumOfHandDisplay>().DidWin();
    }

    /*
     * 数字カードの仕様｛
     *  数字カードのそれぞれの居場所を管理するint Number[]配列を使用する
     *  Number[]は、要素数：11で、山札にある場合は0、プレイヤーの場にある場合は1、コンピュータの場にある場合は2を代入する
     *  山札から通常ドローされるときは、要素番号0～10の、値が0であるものからランダムで選ばれたものを渡す
     *      そのときに、ドローしたのがプレイヤーだったら、渡すと同時に1を代入する。コンピュータだったら、2を代入する
     *      
     *  【山札と場を初期化】
     *  場にカードがある場合は全て退場させてデストロイし、Number配列の値を全て0にする
     * ｝
     * 
     * //プレイヤーの操作等に応じて、Update()に以下の関数呼び出しを記述//
     * 
     * void プレイヤーがカードをドローする() ｛
     *  配列Numberから値が0であるものからランダムで選ぶ
     *  選ばれた要素の値を1にする
     *  return ドローされた数字
     * ｝
     * 
     * void コンピュータがカードをドローする()｛
     *  配列Numberから値が0であるものからランダムで選ぶ
     *  選ばれた要素の値を2にする
     *  return ドローされた数字
     * ｝
     * 
     * if(プレイヤーのカードの和 == コンピュータのカードの和)　ドロー・どちらのライフも減らさない
     * else if(プレイヤーのカードの和 <= ゴール値 && コンピュータのカードの和 <= ゴール値)｛
     *  if(プレイヤーのカードの和 > コンピュータのカードの和) コンピュータのライフを減らす(ベットアップの数に応じて）
     *  if(プレイヤーのカードの和 < コンピュータのカードの和) プレイヤーのライフを減らす(ベットアップの数に応じて）
     * }
     * else if(プレイヤーのカードの和 > ゴール値 && コンピュータのカードの和 <= ゴール値) プレイヤーのライフを減らす(ベットアップの数に応じて）
     * else if(コンピュータのカードの和 > ゴール値 && プレイヤーのカードの和 <= ゴール値) コンピュータのライフを減らす(ベットアップの数に応じて）
     * else if(プレイヤーのカードの和 > ゴール値 && コンピュータのカードの和 > ゴール値)｛
     *  if(プレイヤーのカードの和 < コンピュータのカードの和) コンピュータのライフを減らす(ベットアップの数に応じて）
     *  else プレイヤーのライフを減らす(ベットアップの数に応じて）
     * ｝
     * 
     * void プレイヤーのライフを減らす(int damage)｛
     *  引数で渡された分だけプレイヤーのライフをマイナスする
     * ｝
     * 
     * void コンピュータのライフを減らす(int damage)｛
     *  引数で渡された分だけコンピュータのライフをマイナスする
     * ｝
     * 
     * void 場と山札を初期化()｛
     *  場にカードがある場合は全て退場させてデストロイ
     *  Number配列の値を全て0にする
     * ｝
     * 
     * 
     * //それぞれのオブジェクトに必要な変数（プロパティ）と関数//
     * PlayerController・ComputerController: 
     *  int life; ライフ数
     *  GameObjectまたはint hand[6]; 手札　最大6枚 (int型のときは、空の枠には0をいれて、カードを受け取ったらその数字を代入する
     *  void receiveCard(GameObjectまたはint cardNum) GAMEMAINからドローによって渡されたカードを受け取る関数
     *  void loseLife(int damage) 負けた時にライフを引数分だけ失う
     *  
     * GAMEMAIN:
     *  int deck[11];　山札　カードが山札にある:0 プレイヤーにある:1 コンピュータにある:2
     *  int turn; ジャッジターン:0 プレイヤーターン:1 コンピュータターン:2
     *  switch (turn){} ターンの状態によって動作を分岐
     *  
     * CardController:
     *  void drawToField(float startPlace) 山札から場に滑り込みながらドローされる動きを実装
     *  void backToDeck() 場から山札へ滑り込みながら退場する動きを実装
     *  
     */

    public bool IsPlayerTurn() => isPlayerTurn;

    public int GetTurn() => turn;

    public int GetGoal() => goal;

    /*
    void TestDelay()
    {
        if (testDelay++ > 60)
        {
            ComputerSkipped();
        }
    }
    */
}
