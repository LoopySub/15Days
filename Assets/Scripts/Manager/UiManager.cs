using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static Public_Enum;



public class UiManager : MonoBehaviour
{
    // ============================================[↓사전 초기화 구역↓]=================================================
    [SerializeField]
    private GameObject DialogUI;

    [SerializeField]
    private Text MassageText;

    [SerializeField]
    private Text NameText;

    [SerializeField]
    private Image IconImage;

    [SerializeField]
    private Sprite IconSprite_jone;

    [SerializeField]
    private Sprite IconSprite_Rebecca;


    // ============================================[↑사전 초기화 구역↑]=================================================
    // ============================================[↓역참조 구역↓]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[↑역참조 구역↑]=================================================
    // ==============================================[↓메서드 구역↓]==================================================
    // DialogUI를 활성화하는 메서드
    public void ShowDialog(Icon_type icon, string name, string massage)
    {
        if (DialogUI != null)
        {
            IconImage.sprite = null;
            NameText.text = null;
            MassageText.text = null;

            if (icon == Icon_type.Jone)
            {
                IconImage.sprite = IconSprite_jone;
            }
            else if (icon == Icon_type.Rebecca)
            {
                IconImage.sprite = IconSprite_Rebecca;
            }
            else
            {
                IconImage.sprite = null;
            }

            DialogUI.SetActive(true);
            NameText.text = name;
            MassageText.DOText(massage, 3);
        }
    }

    // DialogUI를 비활성화하는 메서드
    public void HideDialog()
    {
        if (DialogUI != null)
        {
            DialogUI.SetActive(false);
        }
    }

    // ==============================================[↑메서드 구역↑]==================================================
}
