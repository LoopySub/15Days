using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Public_Enum;

public class RebeccaCheck : Researchable
{
    private int _random;

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text ���� ���� �ٸ� ���� ����
            switch (click_Text)
            {
                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "Ŀư", "�ϴ��� ����ī�� �ݸ��� �ξ���.", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "Ŀư", "����ī�� ���¸� Ȯ���ұ�?", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        OverallManager.Instance.UiManager.ContainRenewal();
                        OverallManager.Instance.UiManager.ShowRebeccaUI(true);
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "Ŀư", "Ŀư�� ���߰� ���� ���캻��..", 1);
                        click_Text = 4;
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..���� ����.", 1);
                    }
                    break;
                case 4:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 5:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Cold)
                    {
                        _random = Random.Range(0, 4);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�ݷ��ݷ�, ��.. �ƺ�..", 1);
                            click_Text = 8;
                        }
                        else if( _random == 1)
                        { 
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���´� ������ ����ī?", 1);
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(����ī�� ���̳��� ��ħ�� �ϰ� �ִ�.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�ݷ��ݷ�, ������ �ƺ�.. ������ ���� ������..", 1);
                            click_Text = 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {
                        _random = Random.Range(0, 3);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "....", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, ���� �ʿ��� �Ŷ�..", 1);
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, ������..", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Violent)
                    {
                        _random = Random.Range(0, 6);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�Ͼ�.. �Ͼ�..", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(���� �帴�ϰ� ħ�� �기��.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�ɸ�����... ũ�ƾ�!", 1);
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "��.. ��...!! ", 1);
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�ƺ�.. ���ݸ� �� ������ ����..", 1);
                        }
                        else if (_random == 5)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�߱��߱�.. ���, ����..", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                        _random = Random.Range(0, 5);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "����.. �׸���.. ��..", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "����, ������...", 1);
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(���� ��, �Կ��� �ǰ� ���� ���´�.)", 1);
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "��..��.. ", 1);
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī?", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.AlmostZombie)
                    {
                        _random = Random.Range(0, 8);
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī... ", 1);
                            click_Text = 8;
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�׸�������.. ", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(���� ��, �Կ��� ���� �ǰ� ����� ���´�.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(���� ���ݾ� ���� �ִ�.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "(�濡�� ���� ���� ����.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 5)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "ļ�ƾƾƾ�!! ", 1);
                            click_Text = 8;
                        }
                        else if (_random == 6)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "(��ȭ�� �� �� ���� �� ����.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 7)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "(������ ���� �ʴ°� ���� �� ����.)", 1);
                            click_Text = 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Zombie)
                    {
                        OverallManager.Instance.UiManager.HideDialog();
                        resetSelectRch();
                        OverallManager.Instance.GameDataManager.Ending(Ending_type.Infection);
                    }
                    break;
                case 6:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Cold)
                    {
                        if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "��.. ���� �� ������ �����ƿ�.. ", 1);
                            click_Text = 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {
                       
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī..?", 1);
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", ".... (�鸮�� �ʴ� �� ����)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "..�ƺ�.. ��.. �Ӹ��� ����������..", 1);
                            click_Text= 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Violent)
                    {
                      
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�׸���.. ����..!", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�Ƴ�, �װ� ���� �Ƴ�..!", 1);
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(���� �Ӹ��� �ڰ� �ִ�.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�ƴ�, ������... ���� �ȵ�...!.", 1);
                            click_Text = 8;
                        }
                        else if (_random == 5)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(ħ�븦 ���� ����ִ�.)", 1);
                            click_Text= 8;
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                       
                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī.. ���ݸ� ������, �ƺ��� ��Ե�..", 1);
                            click_Text = 8;
                        }
                        else if (_random == 1)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(���� ���� ��ó�� ���� �������� �ܰ� �ִ�.  �ճ����� �ǰ� �귯������.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 2)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(���� �߰�����, ���հ��� ���� ���� ������ �ٶ󺻴�.)", 1);
                            click_Text = 8;
                        }
                        else if (_random == 3)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "��.. �����...", 1);
                            click_Text= 8;
                        }
                        else if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "ļ�ƾƾ�-!!", 1);
                        }
                    }
                    break;
                case 7:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {

                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�԰�;�.. ������;�.. ", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                        if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���?!", 1);
                        }
                    }
                    break;
                case 8:
                    if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.Unstable)
                    {

                        if (_random == 0)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "(����ī�� ���� ǫ ���̰� ������ ������ �߾�Ÿ��� �ִ�)", 1);
                        }
                    }
                    else if (OverallManager.Instance.PublicVariable.RebeccaStatus == RebeccaStatus.ZombieLike)
                    {
                        if (_random == 4)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "(�ϸ��͸� ���� �� �߾�..)", 1);
                        }
                    }
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī�� �����ٱ�?", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "����ī�� ��ȣ�մϴ�. 3�ð� / ���¹̳� 30 ���", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 11:
                        if (OverallManager.Instance.PublicVariable.IsChoice == true)
                        {
                            if (OverallManager.Instance.PublicVariable.Stamina < 30)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "���¹̳��� �����մϴ�.", 1);
                                click_Text = 3;
                                break;

                            }
                            else if (OverallManager.Instance.PublicVariable.CurrentHour >= 22)
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �ʹ� �ʾ���. �ڰ� ����.", 1);
                                click_Text = 3;
                                break ;
                            }
                            else
                            {
                            if (OverallManager.Instance.PublicVariable.IsGetAntibiotic == true) // �׼��� ������ >=1
                            {
                                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "�׻����� ����ұ�?", 1);
                                OverallManager.Instance.UiManager.ShowChoiceBox();
                                click_Text = 13; 
                                break;
                            }
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...(��ȣ��)", 1);
                        }
                        }
                        else
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "������ ���ϰ� ����..", 1);
                            click_Text = 3;
                        }
                    break;
                case 12:
                    if (OverallManager.Instance.PublicVariable.Contamination <= 80)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "����ī�� ���°� ���� �����ƴ�.", 1);
                        OverallManager.Instance.PublicVariable.Contamination -= Random.Range(10, 21);
                        OverallManager.Instance.UiManager.ContainRenewal();
                        
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "����ī�� ���� ���൵�� �ɰ��ؼ� �׳� ��ȣ�ϴ� �͸����δ� ȿ���� ������..", 1);
                        OverallManager.Instance.PublicVariable.Contamination -= Random.Range(4, 7);
                    }
                    break;
                case 13:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 30;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 14:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...(�׻��� ������)", 1);
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...(��ȣ��)", 1);
                        click_Text =11;
                    }
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "����ī�� ���°� �׷����� ȣ���ƴ�.", 1);
                    OverallManager.Instance.Inventory.useHangSengJe();
                    OverallManager.Instance.PublicVariable.Contamination -= Random.Range(25, 36);
                    OverallManager.Instance.UiManager.ContainRenewal();
                    break;
                case 16:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 30;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    resetSelectRch();
                    click_Text = 0;
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