using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour
{
    enum COLOR
    {
        EMPTY,  //空欄 = 0
        BLACK,  //黒色 = 1
        WHITE   //白色 = 2
    }
    const int WIDTH = 8;
    const int HEIGHT = 8;
    [SerializeField]
    GameObject blackObject = null;
    [SerializeField]
    GameObject boardDisplay = null;
    [SerializeField]
    GameObject whiteObject = null;
    [SerializeField]
    GameObject emptyObject = null;
    COLOR[,] board = new COLOR[WIDTH, HEIGHT]; // 8x8の2次元配列

    // Start is called before the first frame update
    void Start()
    {
        Initialize(); //盤面の初期値を設定
        ShowBoard(); //盤面を表示
    }


    // Update is called once per frame
    void Update()
    {

    }
}