using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researchable : MonoBehaviour
{
    public int click_Text = 0;
    public void Update()
    {
        if (OverallManager.Instance.PlayerManager.SelectResearchable == this)
        {
            if (OverallManager.Instance.PublicVariable.IsDialog == true)
            {
                if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == true)
                {
                    //엔터키나 왼쪽클릭 감지
                    if (Input.GetMouseButtonDown(0))
                    {
                        //마우스가 이미지 위에 있을 경우
                        if (OverallManager.Instance.UiManager.IsMouseOverAnyImage())
                        {
                            OverallManager.Instance.UiManager.HideChoiceBox();
                            Action();
                        }
                    }
                    //키보드 방향키 입력 감지
                    OverallManager.Instance.UiManager.HandleKeyboardInput();
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //마우스가 이미지 위에 있을 경우
                        if (OverallManager.Instance.UiManager.IsMouseOver(OverallManager.Instance.UiManager.zButtonBox))
                        {
                            Action();
                        }
                    }
                }
            }
        }
    }

    public void resetSelectRch()
    {
        OverallManager.Instance.PlayerManager.SelectResearchable = null;
    }


    public virtual void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text 값에 따라 다른 동작 수행
            switch (click_Text)
            {

                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "", 2);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "존", "..", 2);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    OverallManager.Instance.UiManager.HideDialog();
                    break;
                /*
                case 17:
                    Prologue_Text.DOText("", 3);
                    break;
                case 18:
                    Prologue_Text.DOText("", 3);
                    break;
                case 19:
                    Prologue_Text.DOText("", 3);
                    break;
                case 20:
                    Prologue_Text.DOText("", 3);
                    break;
                case 21:
                    Prologue_Text.DOText("", 3);
                    break;
                case 22:
                    Prologue_Text.DOText("", 3);
                    break;
                case 23:
                    Prologue_Text.DOText("", 3);
                    break;
                case 24:
                    Prologue_Text.DOText("", 3);
                    break;
                case 25:
                    Prologue_Text.DOText("", 3);
                    break;
                case 26:
                    Prologue_Text.DOText("", 3);
                    break;
                case 27:
                    Prologue_Text.DOText("", 3);
                    break;
                case 28:
                    Prologue_Text.DOText("", 3);
                    break;
                case 29:
                    Prologue_Text.DOText("", 3);
                    break;
                case 30:
                    Prologue_Text.DOText("", 3);
                    break;
                */
                // 추가적인 경우에 대한 처리도 이어서 작성
                default:
                    // 기본적으로는 아무 동작도 하지 않음
                    break;
            }
        }
    }

}
