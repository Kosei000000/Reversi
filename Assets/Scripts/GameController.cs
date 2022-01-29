using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour
{
    int[,] board = new int[8, 8];
    [SerializeField]
    GameObject blackObject = null;
    [SerializeField]
    GameObject boardDisplay = null;
    [SerializeField]
    GameObject whiteObject = null;
    [SerializeField]
    GameObject emptyObject = null;
   
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

    }
}