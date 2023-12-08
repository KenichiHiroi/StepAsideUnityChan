using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefab
    public GameObject coinPrefab;
    //conePrefab
    public GameObject conePrefab;
    //checkPointPrefab
    public GameObject checkPointPrefab;

    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //アイテム生成位置
    private int diffPositionZ = 40;

    // Start is called before the first frame update
    void Start()
    {
        //アイテム生成位置の40m前にチェックポイントのPrefabを生成する
        int generatePos = startPos - diffPositionZ;
        for(int i = generatePos;i < goalPos - diffPositionZ;i += 15)
        {
            GameObject checkPoint = Instantiate(checkPointPrefab);
            checkPoint.transform.position = new Vector3(checkPoint.transform.position.x, checkPoint.transform.position.y, i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテム生成を実行する
    public void GenerateItem(int passingPoint)
    {
        //Debug.Log("GenerateItem 実行");

        int num = Random.Range(1, 11);
        int generatePositionZ = passingPoint + diffPositionZ;

        //Debug.Log("ランダム値" + num);

        if (num <= 2)
        {
            //Debug.Log("障害生成分岐");

            //障害　コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generatePositionZ);
            }
        }
        else
        {
            //Debug.Log("アイテム生成分岐");

            //アイテム
            for (int j = -1; j <= 1; j++)
            {
                //ランダムな値によってアイテムの種類を決める　1～10の範囲
                int item = Random.Range(1, 11);
                //アイテムの前後(z軸)オフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);

                //値に応じて分岐　6割 コイン　3割 車　1割 配置なし
                if (1 <= item && item <= 6)
                {
                    //Debug.Log("コイン");

                    //コイン
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(j * posRange, coin.transform.position.y, generatePositionZ + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                   // Debug.Log("車");

                    //車
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(j * posRange, car.transform.position.y, generatePositionZ + offsetZ);
                }
            }
        }
    }
}
