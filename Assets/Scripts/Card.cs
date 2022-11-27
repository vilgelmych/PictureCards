using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    AnimFlipCard animFlipCard;


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

    bool isOpenCard;
    /// <summary>
    /// Признак открытости картинки
    /// </summary>
    public bool IsOpenCard
    {
        set
        {
            isOpenCard = value;
            animFlipCard.FlipCard(isOpenCard, () => 
                {
                    CoverImage.sprite = isOpenCard ? FrontCardSprite : BackCardSprite;
                });            
        }

        get
        {
            return isOpenCard;
        }
    }

    private void Awake()
    {
        FrontCardSprite = CoverImage.sprite;
        animFlipCard = GetComponent<AnimFlipCard>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WebRequestHandler.GetImage(SetImage));
    }

    void SetImage(Texture texture)
    {
        CardRawImage.texture = texture;
        IsLoadedImage = true;
    }

    
    
}
