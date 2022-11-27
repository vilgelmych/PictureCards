using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{
    /// <summary>
    /// Набор карточек
    /// </summary>
    public List<Card> Cards;


    /// <summary>
    /// Метод загрузки
    /// 0 - Параллельный
    /// 1 - Последовательный
    /// 2 - По готовности
    /// </summary>
    public Dropdown LoadingMethodDropdown;

    /// <summary>
    /// Кнопка старта загрузки
    /// </summary>
    public Button LoadBtn;

    /// <summary>
    /// Кнопка отмены загрузки
    /// </summary>
    public Button CancelBtn;

    // Start is called before the first frame update
    void Start()
    {
        Cards = FindObjectsOfType<Card>().ToList();
        Cards.ForEach(c => c.IsOpenCard = false);
    }


    public void LoadCardImage()
    {
        switch (LoadingMethodDropdown.value)
        {
            case 0:
                AllAtOnce();
                break;
            case 1:
                OneByOne();
                break;               
            case 2:
                WhenImageReady();
                break;
        }
    }

    /// <summary>
    /// Параллельная загрузка
    /// </summary>
    void AllAtOnce()
    {

    }

    /// <summary>
    /// Последовательная загрузка
    /// </summary>
    void OneByOne()
    {

    }

    /// <summary>
    /// Загрузка и показ изображений по готовности
    /// </summary>
    void WhenImageReady()
    {

    }

}
