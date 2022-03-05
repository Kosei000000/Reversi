using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController: MonoBehaviour
{
    // enumを使って数字に名前をつける
    enum COLOR
    {
        EMPTY,  //空欄 = 0
        BLACK,  //黒色 = 1
        WHITE   //白色 = 2
    }

    const int WIDTH = 8;
    const int HEIGHT = 8;

    //黒い駒
    [SerializeField]         //変数をインスペクターに表示
    GameObject blackObject = null;  //blackObjectという名前のGameObjectを宣言
    //白い駒
    [SerializeField]
    GameObject whiteObject = null;  //whiteObjectという名前のGameObjectを宣言
    //盤
    [SerializeField]
    GameObject emptyObject = null;  //emptyObjectという名前のGameObjectを宣言

    //盤面のGameObject
    [SerializeField]
    GameObject boardDisplay = null;

    //盤面
    COLOR[,] board = new COLOR[WIDTH, HEIGHT]; // 8x8の2次元配列
    COLOR player = COLOR.BLACK;
    public void PutStone(string position)
    {
        //positionをカンマで分ける
        int h = int.Parse(position.Split(',')[0]);
        int v = int.Parse(position.Split(',')[1]);
        //クリックされた座標に駒を置く
        board[h, v] = player;
        ShowBoard();
        //駒の色を変更
        player = (player == COLOR.BLACK) ? COLOR.WHITE : COLOR.BLACK;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize(); //盤面の初期値を設定
        ShowBoard(); //盤面を表示
    }

    //盤面の初期値を設定
    void Initialize()
    {
        board[3, 3] = COLOR.WHITE;
        board[3, 4] = COLOR.BLACK;
        board[4, 3] = COLOR.BLACK;
        board[4, 4] = COLOR.WHITE;
    }

    //盤面を表示する
    void ShowBoard()
    { //boardDisplayの全ての子オブジェクトを削除
        foreach (Transform child in boardDisplay.transform)
        {
            Destroy(child.gameObject); //削除
        }
        for (int v = 0; v < HEIGHT; v++)
        {
            for (int h = 0; h < WIDTH; h++)
            {
                // boardの色に合わせて適切なPrefabを取得
                GameObject piece = GetPrefab(board[h, v]);
                if (board[h, v] == COLOR.EMPTY)
                {
                    int x = h;//座標を一時的に保持
                    int y = v;
                    //pieceにイベントを設定
                    piece.GetComponent<Button>().onClick.AddListener(() => { PutStone(x + "," + y); });

                    
                }
                //取得したPrefabをboardDisplayの子オブジェクトにする
                piece.transform.SetParent(boardDisplay.transform);
            }
        }
    }
   
    //色によって適切なprefabを取得して返す
    GameObject GetPrefab(COLOR color)
    {
        GameObject prefab;
        switch (color)
        {
            case COLOR.EMPTY:   //空欄の時
                prefab = Instantiate(emptyObject);
                break;
            case COLOR.BLACK:   //黒の時
                prefab = Instantiate(blackObject);
                break;
            case COLOR.WHITE:   //白の時
                prefab = Instantiate(whiteObject);
                break;
            default:            //それ以外の時(ここに入ることは想定していない)
                prefab = null;
                break;
        }
        return prefab; //取得したPrefabを返す
    }
}