using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Карточка
/// </summary>
public class Card : MonoBehaviour
{
    /// <summary>
    /// Картинка на карточке
    /// </summary>
    public RawImage CardRawImage;

    /// <summary>
    /// Обложка карточки
    /// </summary>
    public Image CoverImage;

    /// <summary>
    /// Спрайт лицевой стороны карточки
    /// </summary>
    Sprite FrontCardSprite;

    /// <summary>
    /// Спрайт обратной стороны карточки
    /// </summary>
    public Sprite BackCardSprite;


    /// <summary>
    /// Анимация переворота карточки
    /// </summary>
    AnimFlipCard animFlipCard;

    /// <summary>
    /// Признак открытия при окончании загрузки картинки
    /// </summary>
    public bool IsOpenLoadedImage;

    bool isLoadedImage;

    /// <summary>
    /// Признак загруженности картинки
    /// </summary>
    public bool IsLoadedImage
    {
        private set
        {
            isLoadedImage = value;
           
        }

        get
        {
            return isLoadedImage;
        }
    }

    /// <summary>
    /// Разгрузка картинки
    /// </summary>
    public void UnloadImage()
    {
        IsLoadedImage = false;
        IsOpenLoadedImage = false;
        CardRawImage.texture = null;
        Resources.UnloadUnusedAssets();
    }

    bool isOpenCard = true;
    /// <summary>
    /// Признак открытости картинки
    /// </summary>
    public bool IsOpenCard
    {
        set
        {
            if (isOpenCard != value)
            {
                isOpenCard = value;
                animFlipCard.FlipCard(isOpenCard, () =>
                    {
                        CoverImage.sprite = isOpenCard ? FrontCardSprite : BackCardSprite;
                    });
            }
        }

        get
        {
            return isOpenCard;
        }
    }


    public void OpenCard()
    {
        IsOpenCard = true;
    }
    private void Awake()
    {
        FrontCardSprite = CoverImage.sprite;
        animFlipCard = GetComponent<AnimFlipCard>();
    }

    // Start is called before the first frame update
    public void StartImageLoad(string url, int size, UnityAction callback = null)
    {
        StartCoroutine(WebRequestHandler.GetImage(url, size, SetImage));
    }

    void SetImage(Texture texture)
    {
        CardRawImage.texture = texture;
        IsLoadedImage = true;
        if(IsOpenLoadedImage)
            IsOpenCard = true;
    }
       
    
    
}
