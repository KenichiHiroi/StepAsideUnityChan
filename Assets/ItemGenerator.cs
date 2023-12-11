using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab
    public GameObject coinPrefab;
    //conePrefab
    public GameObject conePrefab;
    //�v���C���[�L�����N�^
    GameObject playerChara;

    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;
    //�A�C�e�������ʒu
    private int diffPositionZ = 40;
    //�A�C�e�������ʒu
    private int generatePos;
    //�A�C�e�������̊Ԋu
    private int generateInterval = 15;

    // Start is called before the first frame update
    void Start()
    {
        //unity�����̃I�u�W�F�N�g���擾
        playerChara = GameObject.Find("unitychan");
        //�ŏ��̐����ʒu
        generatePos = startPos - diffPositionZ;
    }

    // Update is called once per frame
    void Update()
    {
        //�����ʒu�Ɠ�������@���@�ŏI�����n�_���O
        if (generatePos <= playerChara.transform.position.z && generatePos <= goalPos - diffPositionZ)
        {
            //Debug.Log("GenerateItem ���s");
            int num = Random.Range(1, 11);
            int generatePositionZ = generatePos + diffPositionZ;

            //Debug.Log("�����_���l" + num);

            if (num <= 2)
            {
                //Debug.Log("��Q��������");

                //��Q�@�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generatePositionZ);
                }
            }
            else
            {
                //Debug.Log("�A�C�e����������");

                //�A�C�e��
                for (int j = -1; j <= 1; j++)
                {
                    //�����_���Ȓl�ɂ���ăA�C�e���̎�ނ����߂�@1�`10�͈̔�
                    int item = Random.Range(1, 11);
                    //�A�C�e���̑O��(z��)�I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);

                    //�l�ɉ����ĕ���@6�� �R�C���@3�� �ԁ@1�� �z�u�Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //Debug.Log("�R�C��");

                        //�R�C��
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(j * posRange, coin.transform.position.y, generatePositionZ + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // Debug.Log("��");

                        //��
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(j * posRange, car.transform.position.y, generatePositionZ + offsetZ);
                    }
                }
            }

            //�����ʒu��15m��ɐݒ�
            generatePos += generateInterval;
        }   
    }
}
