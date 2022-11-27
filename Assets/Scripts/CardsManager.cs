using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{
    /// <summary>
    /// ����� ��������
    /// </summary>
    public List<Card> Cards;


    /// <summary>
    /// ����� ��������
    /// 0 - ������������
    /// 1 - ����������������
    /// 2 - �� ����������
    /// </summary>
    public Dropdown LoadingMethodDropdown;

    /// <summary>
    /// ������ ������ ��������
    /// </summary>
    public Button LoadBtn;

    /// <summary>
    /// ������ ������ ��������
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
    /// ������������ ��������
    /// </summary>
    void AllAtOnce()
    {

    }

    /// <summary>
    /// ���������������� ��������
    /// </summary>
    void OneByOne()
    {

    }

    /// <summary>
    /// �������� � ����� ����������� �� ����������
    /// </summary>
    void WhenImageReady()
    {

    }

}
