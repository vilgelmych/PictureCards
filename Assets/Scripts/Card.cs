using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��������
/// </summary>
public class Card : MonoBehaviour
{
    /// <summary>
    /// �������� �� ��������
    /// </summary>
    public RawImage CardRawImage;

    /// <summary>
    /// ������� ��������
    /// </summary>
    public Image CoverImage;

    /// <summary>
    /// ������ ������� ������� ��������
    /// </summary>
    Sprite FrontCardSprite;

    /// <summary>
    /// ������ �������� ������� ��������
    /// </summary>
    public Sprite BackCardSprite;

    AnimFlipCard animFlipCard;


    bool isLoadedImage;

    /// <summary>
    /// ������� ������������� ��������
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
    /// ������� ���������� ��������
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
