using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int life;
    int[] hand = new int[6] { 0, 0, 0, 0, 0, 0 };
    GameObject GAMEMAIN;
    public GameObject CardPrefab1;
    public GameObject CardPrefab2;
    public GameObject CardPrefab3;
    public GameObject CardPrefab4;
    public GameObject CardPrefab5;
    public GameObject CardPrefab6;
    public GameObject CardPrefab7;
    public GameObject CardPrefab8;
    public GameObject CardPrefab9;
    public GameObject CardPrefab10;
    public GameObject CardPrefab11;
    private GameObject newCard1;
    private GameObject newCard2;
    private GameObject newCard3;
    private GameObject newCard4;
    private GameObject newCard5;
    private GameObject newCard6;
    private GameObject newCard7;
    private GameObject newCard8;
    private GameObject newCard9;
    private GameObject newCard10;
    private GameObject newCard11;

    void Start()
    {
        this.GAMEMAIN = GameObject.Find("GAMEMAIN");
    }


    void Update()
    {
    }

    public void ReceiveCard(int num) //GAMEMAINからドローによって渡されたカードを受け取る関数
    {
        switch (num) {
            case 1:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard1 = Instantiate(CardPrefab1) as GameObject;
                        newCard1.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 2:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard2 = Instantiate(CardPrefab2) as GameObject;
                        newCard2.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 3:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard3 = Instantiate(CardPrefab3) as GameObject;
                        newCard3.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 4:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard4 = Instantiate(CardPrefab4) as GameObject;
                        newCard4.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 5:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard5 = Instantiate(CardPrefab5) as GameObject;
                        newCard5.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 6:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard6 = Instantiate(CardPrefab6) as GameObject;
                        newCard6.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 7:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard7 = Instantiate(CardPrefab7) as GameObject;
                        newCard7.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 8:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard8 = Instantiate(CardPrefab8) as GameObject;
                        newCard8.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 9:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard9 = Instantiate(CardPrefab9) as GameObject;
                        newCard9.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 10:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard10 = Instantiate(CardPrefab10) as GameObject;
                        newCard10.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
            case 11:
                for (int i = 0; i < 6; i++) //0番目から値が0の要素を探してそこに受け取った数字を代入
                    if (hand[i] == 0)
                    {
                        hand[i] = num;

                        newCard11 = Instantiate(CardPrefab11) as GameObject;
                        newCard11.GetComponent<CardController>().setStartPos(i);
                        break;
                    }
                break;
        }

        Debug.Log("Player's Hand : " + hand[0]+","+hand[1]+","+hand[2]+","+hand[3]+","+hand[4]+","+hand[5]);
    }

    public int ReturnLastCard() //一番右側にある表向きのカードを山札に戻す
    {
        int returned = 0;
        for (int i = 5; i >= 0; i--) //一番右側(末尾)の5番目から値が0以外の要素を探して0に戻す
            if (hand[i] > 0)
            {
                switch (hand[i])
                {
                    case 1:
                        newCard1.GetComponent<CardController>().DestroyOn();
                        break;
                    case 2:
                        newCard2.GetComponent<CardController>().DestroyOn();
                        break;
                    case 3:
                        newCard3.GetComponent<CardController>().DestroyOn();
                        break;
                    case 4:
                        newCard4.GetComponent<CardController>().DestroyOn();
                        break;
                    case 5:
                        newCard5.GetComponent<CardController>().DestroyOn();
                        break;
                    case 6:
                        newCard6.GetComponent<CardController>().DestroyOn();
                        break;
                    case 7:
                        newCard7.GetComponent<CardController>().DestroyOn();
                        break;
                    case 8:
                        newCard8.GetComponent<CardController>().DestroyOn();
                        break;
                    case 9:
                        newCard9.GetComponent<CardController>().DestroyOn();
                        break;
                    case 10:
                        newCard10.GetComponent<CardController>().DestroyOn();
                        break;
                    case 11:
                        newCard11.GetComponent<CardController>().DestroyOn();
                        break;
                }

                returned = hand[i];
                hand[i] = 0;
                break;
            }
        return returned;
    }

    public void ReturnAllCard() //マッチが終わった際に手札を初期化する
    {
        for (int i = 0; i < 6; i++)
        {
            if (hand[i] != 0)
                switch (hand[i])
                {
                    case 1:
                        newCard1.GetComponent<CardController>().DestroyOn();
                        break;
                    case 2:
                        newCard2.GetComponent<CardController>().DestroyOn();
                        break;
                    case 3:
                        newCard3.GetComponent<CardController>().DestroyOn();
                        break;
                    case 4:
                        newCard4.GetComponent<CardController>().DestroyOn();
                        break;
                    case 5:
                        newCard5.GetComponent<CardController>().DestroyOn();
                        break;
                    case 6:
                        newCard6.GetComponent<CardController>().DestroyOn();
                        break;
                    case 7:
                        newCard7.GetComponent<CardController>().DestroyOn();
                        break;
                    case 8:
                        newCard8.GetComponent<CardController>().DestroyOn();
                        break;
                    case 9:
                        newCard9.GetComponent<CardController>().DestroyOn();
                        break;
                    case 10:
                        newCard10.GetComponent<CardController>().DestroyOn();
                        break;
                    case 11:
                        newCard11.GetComponent<CardController>().DestroyOn();
                        break;
                }
            hand[i] = 0;
        }
    }

    public int SumOfHandCard() => hand[0] + hand[1] + hand[2] + hand[3] + hand[4] + hand[5];
}
