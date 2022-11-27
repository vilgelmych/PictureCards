using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;


/// <summary>
/// јнимаци€ переворачивани€ карточки
/// </summary>
public class AnimFlipCard : MonoBehaviour
{
    /// <summary>
    /// ќбщее врем€ анимации
    /// </summary>
    float time = 1f;

    /// <summary>
    /// —тартовый угол (лицева€ сторона каторчки)
    /// </summary>
    Vector3 zeroTurn = Vector3.zero;

    /// <summary>
    /// ѕоловина поворота
    /// </summary>
    Vector3 halfTurn = new Vector3(0, 90, 0);

    /// <summary>
    /// ѕолный поворот (обратна€ сторона карточки)
    /// </summary>
    Vector3 fullTurn = new Vector3(0, 180, 0);

   /// <summary>
   /// ѕереворот карточки
   /// </summary>
   /// <param name="isFront"> открыта (лицева€ сторона)/закрыта карточка</param>
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
