using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    private GameObject unitychan;
    private float difference;
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private float posRange = 3.4f;
    private float uTime;

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.difference = unitychan.transform.position.z - this.transform.position.z;
        uTime = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        uTime += Time.deltaTime;
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
        if (uTime > 1 && this.transform.position.z < 120)
        {
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.transform.position.z);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.transform.position.z + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.transform.position.z + offsetZ);
                    }
                }
            }
            uTime = 0f;
        }
    }
}