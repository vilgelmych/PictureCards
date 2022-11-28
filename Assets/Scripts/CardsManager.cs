using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{
    /// <summary>
    /// Размер загружаемых картинок
    /// </summary>
    const int sizeImg = 200;

    public int CardsCount = 6;

    /// <summary>
    /// Префаб карточки
    /// </summary>
    public GameObject CardPrefab;

    /// <summary>
    /// Родитель карточек
    /// </summary>
    public GameObject CardsParent;

    /// <summary>
    /// Список карточек
    /// </summary>
    List<Card> Cards;

    /// <summary>
    /// Методы загрузки
    /// 0 - Параллельная
    /// 1 - Последовательная
    /// 2 - По готовности
    /// </summary>
    public Dropdown MethodLoadingDropdown;

    /// <summary>
    /// Кнопка старта загрузки
    /// </summary>
    public Button LoadBtn;

    /// <summary>
    ///Кнопка отмены загрузки
    /// </summary>
    public Button CancelBtn;

    // Start is called before the first frame update
    void Start()
    {
        Cards = new List<Card>();
        for (int i = 0; i < CardsCount; i++)
        {
            GameObject go = Instantiate(CardPrefab, CardsParent.transform);
            Cards.Add(go.GetComponent<Card>());
        }
      
        Cards.ForEach(c => c.IsOpenCard = false);

        CancelBtn.onClick.AddListener(CancelLoad);
    }


    public void CancelLoad()
    {
        StopAllCoroutines();
        UnloadAllCard();
        FlipAllCard(false);
        InteractUIControls(true);
    }

    public void LoadCardsImage()
    {
        FlipAllCard(false);
        UnloadAllCard();
        InteractUIControls(false);

        switch (MethodLoadingDropdown.value)
        {
            case 0:
                StartCoroutine( AllAtOnce());
                break;
            case 1:
                StartCoroutine(OneByOne());
                break;               
            case 2:
                StartCoroutine(WhenImageReady());
                break;
        }
    }

    /// <summary>
    /// Параллельная загрузка
    /// </summary>
    IEnumerator AllAtOnce()
    {
        foreach (var card in Cards)
        {
            card.StartImageLoad(ResourcesAssets.ImageUrl, sizeImg);
        }
        while (Cards.Find(c =>!c.IsLoadedImage))
            yield return null;
        FlipAllCard(true);
        InteractUIControls(true);
    }

    /// <summary>
    /// Последовательная загрузка
    /// </summary>
    IEnumerator OneByOne()
    {
        foreach (var card in Cards)
        {
            card.StartImageLoad(ResourcesAssets.ImageUrl, sizeImg);
            while (!card.IsLoadedImage)
                yield return null;
            card.IsOpenCard = true;
        }
        
        InteractUIControls(true);
    }

    /// <summary>
    /// Загрузка и показ изображений по готовности
    /// </summary>
    IEnumerator WhenImageReady()
    {
        foreach (var card in Cards)
        {
            card.StartImageLoad(ResourcesAssets.ImageUrl, sizeImg);
            card.IsOpenLoadedImage = true;
        }

        while (Cards.Find(c => !c.IsOpenCard))
            yield return null;        
        InteractUIControls(true);
    }


    /// <summary>
    /// Переворот всех карточек
    /// </summary>
    /// <param name="isopen"></param>
    void FlipAllCard(bool isopen)
    {
        foreach (var card in Cards)
        {          
            card.IsOpenCard = isopen;
        }
    }

    /// <summary>
    ///Разгрузить все картинки
    /// </summary>
    void UnloadAllCard()
    {
        Cards.ForEach(c => c.UnloadImage());
    }

    /// <summary>
    /// Интерактивность UI контролов
    /// </summary>
    /// <param name="isInteractable"></param>
    void InteractUIControls(bool isInteractable)
    {
        LoadBtn.interactable = MethodLoadingDropdown.interactable = isInteractable;
    }

}
