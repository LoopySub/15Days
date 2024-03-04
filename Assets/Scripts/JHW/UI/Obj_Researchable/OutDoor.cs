using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoor : Researchable
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OverallManager.Instance.PlayerManager.SelectResearchable = this;
            Action();
        }
    }

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text ���� ���� �ٸ� ���� ����
            switch (click_Text)
            {
                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "������", "���� Ž���ұ��?", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "������", "������ �����ϴ�. ���¹̳� 50 ��� / �� �̵��� ���� 2�ð� ���", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        if (OverallManager.Instance.PublicVariable.Stamina < 50)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "���¹̳��� �����մϴ�.", 1);
                            click_Text = 3;
                            break;

                        }
                        else if (OverallManager.Instance.PublicVariable.CurrentHour >= 22)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�� �ð��� ������ �� ������.", 1);
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.HideDialog();
                            resetSelectRch();
                            OverallManager.Instance.PublicVariable.Stamina -= 50;
                            click_Text = 0;
                            OverallManager.Instance.PlayerManager.transform.position = new Vector3(-8.44f, -2.46f, 0);
                        }
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�׸� ����.", 1);
                    }
                    break;
                case 4:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PlayerManager.transform.position = new Vector3(-6.52f, OverallManager.Instance.PlayerManager.transform.position.y, 0);
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
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
                // �߰����� ��쿡 ���� ó���� �̾ �ۼ�
                default:
                    // �⺻�����δ� �ƹ� ���۵� ���� ����
                    break;
            }
        }
    }
}
