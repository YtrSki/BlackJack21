using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumOfHandDisplay : MonoBehaviour
{
    float dy = -2;
    bool isPlayer = true;
    int sum = 0;
    bool didWin = false;
    bool isBackToDeck = false;
    float Dpos = 1.1f;

    public void IsComputer() => isPlayer = false;
    public void SetSum(int sum) => this.sum = sum;

    public void DidWin() => didWin = true;
    public void IsBackToDeck() => isBackToDeck = true;

    // Update is called once per frame
    void Update()
    {
        if (!isBackToDeck)
        {
            dy *= 0.9f;
            transform.position = new Vector3(3, 0.5f + dy, isPlayer ? 0.5f : 3.5f);
            GetComponent<TextMesh>().text = sum.ToString();
            if (!didWin) GetComponent<TextMesh>().color = new Color(1, 0, 0);
        }
        else
        {
            BackToDeck();
        }
    }

    void BackToDeck() //場から退場する動きを実装
    {
        Dpos *= 1.1f;

        if (isPlayer)
        {
            this.transform.position = new Vector3(Dpos + 1.9f, 0.5f, 0.5f);
            if (this.transform.position.x >= 10)
                Destroy(gameObject);
        }
        else
        {
            this.transform.position = new Vector3(Dpos + 1.9f, 0.5f, 3.5f);
            if (this.transform.position.x >= 10)
                Destroy(gameObject);
        }
    }
}
