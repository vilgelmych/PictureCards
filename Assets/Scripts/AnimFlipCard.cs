using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;


/// <summary>
/// �������� ��������������� ��������
/// </summary>
public class AnimFlipCard : MonoBehaviour
{
    /// <summary>
    /// ����� ����� ��������
    /// </summary>
    float time = 1f;

    /// <summary>
    /// ��������� ���� (������� ������� ��������)
    /// </summary>
    Vector3 zeroTurn = Vector3.zero;

    /// <summary>
    /// �������� ��������
    /// </summary>
    Vector3 halfTurn = new Vector3(0, 90, 0);

    /// <summary>
    /// ������ ������� (�������� ������� ��������)
    /// </summary>
    Vector3 fullTurn = new Vector3(0, 180, 0);

   /// <summary>
   /// ��������� ��������
   /// </summary>
   /// <param name="isFront"> ������� (������� �������)/������� ��������</param>
   /// <param name="action"> ������� ��� ��������/�������� ��������</param>
    public void FlipCard(bool isFront , UnityAction action)
    {
        transform.DOLocalRotate(halfTurn, time / 2).OnComplete( () =>               
            {
                if(action !=null)
                    action.Invoke();
                transform.DOLocalRotate(isFront ? zeroTurn : fullTurn, time / 2);
            });
    }
  
}
