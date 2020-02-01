using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private float basis = 9.0f;
    private float startPos = 0;
    private bool isDestroy = false;
    private float Dpos = 1.1f;
    private bool isComputer = false;

    private bool isHiddenToAppear = false;

    public void DestroyOn() => isDestroy = true;

    public void setStartPos(int n) => startPos = n;

    public void IsComputer() => isComputer = true;

    public void IsHiddenToAppear() => isHiddenToAppear = true;

    void Start()
    {
        
    }

    void Update()
    {
        switch (isHiddenToAppear)
        {
            case false:
                basis /= 1.15f;

                if (!isComputer)
                    this.transform.position = new Vector3(startPos + basis + 0.5f, 0.2f, 0.5f);
                else
                    this.transform.position = new Vector3(startPos + basis + 0.5f, 0.2f, 3.5f);

                if (isDestroy) BackToDeck();
                break;
            case true:
                Appear();
                if (isDestroy) BackToDeck(true);
                break;
        }
    }

    void BackToDeck() //場から退場する動きを実装
    {
        Dpos *= 1.1f;

        if (!isComputer)
        {
            this.transform.position = new Vector3(Dpos + startPos + -0.5f, 0.2f, 0.5f);
            if (this.transform.position.x >= 10)
                Destroy(gameObject);
        }
        else
        {
            this.transform.position = new Vector3(Dpos + startPos + -0.5f, 0.2f, 3.5f);
            if (this.transform.position.x >= 10)
                Destroy(gameObject);
        }
    }

    void BackToDeck(bool isAppeared) //場から退場する動きを実装
    {
        Dpos *= 1.1f;

            this.transform.position = new Vector3(Dpos - 0.5f, 0.2f, 3.5f);
            if (this.transform.position.x >= 10)
                Destroy(gameObject);
    }

    public void HiddenCardDestroy() => Destroy(gameObject);

    public void Appear() => this.transform.position = new Vector3(0.5f, 0.2f, 3.5f);
}
