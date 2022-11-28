using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;


/// <summary>
/// Анимация переворачивания карточки
/// </summary>
public class AnimFlipCard : MonoBehaviour
{
    /// <summary>
    /// Общее время анимации 
    /// </summary>
    float time = 0.2f;

    /// <summary>
    /// Стартовый угол (лицевая сторона каторчки)
    /// </summary>
    Vector3 zeroTurn = Vector3.zero;

    /// <summary>
    /// Половина поворота
    /// </summary>
    Vector3 halfTurn = new Vector3(0, 90, 0);

    /// <summary>
    /// Полный поворот (обратная сторона карточки)
    /// </summary>
    Vector3 fullTurn = new Vector3(0, 180, 0);

   /// <summary>
   /// Переворот карточки
   /// </summary>
   /// <param name="isFront"> открыта (лицевая сторона)/закрыта карточка</param>
   /// <param name="action"> событие при открытии/закрытии карточки</param>
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
