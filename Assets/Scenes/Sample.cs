using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField]
    private Vector3[] _rotations;



    private GameObject[] _cubes;

    void Start()
    {
        _cubes = new GameObject[_rotations.Length];
        for (var i = 0; i < _cubes.Length; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(-4 + i * 2, 0, 0);
            
            _cubes[i] = cube;
            
        }
    }

    private void Update()
    {
        /*  foreach ( var cube in _cubes)
          {
              cube.transform.Rotate(0, 500, 0);
          }*/
        // ��ԍ��Ƌ����ԍ��ŉ�]�̌�����ς���
        /* for (var i = 0; i < _cubes.Length; i++)
         {
             var cube = _cubes[i];
             if (i % 2 == 0)
             {
                 cube.transform.Rotate(0, 1, 0);
             }
             else
             {
                 cube.transform.Rotate(0, -1, 0);
             }
         }*/
        for (var i = 0; i < _cubes.Length; i++)
        {
            var cube = _cubes[i];
            var rot = _rotations[i]; // ���s���ɕҏW�����ƃG���[�o�邩��
            cube.transform.Rotate(rot);
        }

    }
    // Start is called before the first frame update
    /*  void Start()
      {
          *//*  // # �z��
            // �����^�̃f�[�^�𕡐����ׂ�����
            // �z�񂪎��ʂ̃f�[�^�̎���v�f�Ƃ���

            // ## �z��錾
            // �v�f�^[] �ϐ����G
            int[] iAry; // �Ⴆ�� int �^�̔z��

            // �z��^�̕ϐ������l�� null �i���g���Ȃ��j
            // �Ȃ̂ŏ������i���̉��j���Ȃ���Ύg���Ȃ�

            // ## �z��C���X�^���X�̐���
            // new �v�f�^[�v�f��]
             iAry = new int[3]; // �Ⴆ�� int �^�z�񐶐�

            // �z��̏ꍇ���^���_�͗L��
            // var iAry = new int[3]; // ok
            // ## �z��̗v�f�ւ̃A�N�Z�X
            // �z��͐擪�� 0 �Ƃ���ԍ��ŗv�f�ɃA�N�Z�X����
            // �v�f�ւ̃A�N�Z�X�͔z��^�ϐ��� [ ] ���Z�q���g��

            // �z��̊e�v�f�ɒl��������
            iAry[0] = 10;
            iAry[1] = 20;
            iAry[2] = 30;

            // �z��̊e�v�f�̒l�����o��
            Debug.Log($"iAry[0]={iAry[0]}");
            Debug.Log($"iAry[0]={iAry[1]}");
            Debug.Log($"iAry[0]={iAry[2]}");
    */
    /*       // # �z�񏉊����q
           // �z��͐����Ɠ����Ɋe�v�f�̒l���������ł���
           // `new �v�f�^[�v�f��] { �v�f1, �v�f2, �v�f3, ... }`
           // var iAry = new int[3] { 10, 20, 30 };
           // iAry[0] = 10; iAry[1] = 20; iAry[2] = 30; �Ɠ��`

           // ## �v�f���͏�������l�̐��͈�v���Ȃ���΂Ȃ�Ȃ�
           // �������q�̗v�f���v�f���ɑ΂��ď��Ȃ��Ă������Ă��_��
           // var iAry = new int[3] { 10, 20 }; // �G���[
           // var iAry = new int[3] { 10, 20, 30, 40 }; // �G���[

           // ## �������q�����ꍇ�A�v�f�����ȗ��\
           // var iAry = new int[] { 10, 20, 30 };

           // ## �������q�����ꍇ�A�v�f�^���ȗ��\
           var iAry = new[] { 10, 20, 30 };

           Debug.Log($"iAry[0]={iAry[0]}");
           Debug.Log($"iAry[1]={iAry[1]}");
           Debug.Log($"iAry[2]={iAry[2]}");

   */
    /*   // # �z��Ɣ�������
       // �z��̐擪���炷�ׂĂ̗v�f�����o���E��������Ȃ�
       // �z�񂠂�Ƃ���ɌJ��Ԃ�������

       // ## �W���I�� for ���ɂ��z�񏈗�
       var iAry = new int[] { 10, 20, 30 };
       var len = iAry.Length; // �z��̗v�f�����擾����
       for (var i = 0; i < len; i++)
       {
           Debug.Log($"iAry[{i}]={iAry[i]}");
       }

       // ## foreach ��
       // �z��I�ȃf�[�^��擪���珇�ɗv�f�����o���J��Ԃ���
       // �z��̃C���f�b�N�X�Ǘ����s�v�Ȃ炱�������g��
       // `foreach(�v�f�^ �ϐ��� in �z��) ��;`
       foreach (var i in iAry)
       {
           Debug.Log($"foreach i={i}");
       }*//*
   }*/
}
