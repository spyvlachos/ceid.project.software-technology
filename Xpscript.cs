using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xpscript : MonoBehaviour
{
    private List<Transform> coinList;
    private float coinspawntimer;
    private float coinspawntimermax;
    private float newcoinposition;
    public int coinscore;
    private Transform pfpcoin;
    public float coin_WIDTH = 3f;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            coinscore.coinAmount += 1;
          
            Destroy(gameObject);
           
            
        }
    }
  
    void Update()
    {

        handlecoinspawning();
    }

    private void Createcoin(float height, float xPosition)
    {
        Transform coin = Instantiate(GameAssets.GetInstance().pfpcoin);
        coin.position = new Vector3(xPosition, 0f);
        coinList.Add(coin);
        SpriteRenderer coinSpriteRenderer = coin.GetComponent<SpriteRenderer>();
        coinSpriteRenderer.size = new Vector2(coin_WIDTH, height);
    }
    private void handlecoinspawning()
    {
        coinspawntimer -= Time.deltaTime;
        if (coinspawntimer < 0)
        {
            coinspawntimer += coinspawntimermax;
            CreateCoin(-5f, newcoinposition);
            newcoinposition += 4f;
        }
    }
}
