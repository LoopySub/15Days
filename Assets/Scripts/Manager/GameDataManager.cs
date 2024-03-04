using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Public_Enum;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GameDataManager : BaseMonoBehaviour    // ���� �����͸� ���������� �����ϴ� �޼���� ���۵��� �ִ� ��ũ��Ʈ
{
    // ============================================[�鿪���� ������]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[�迪���� ������]=================================================
    // =======================================[����� ������ �޼ҵ� ������]==========================================
    
    
    //��ħ �� ��θ��� ���� ���¹̳� ȸ��
    public void RecoverStaminaAfterSleep()
    {
        if (OverallManager.Instance.PublicVariable.Fullness >= 100)
            OverallManager.Instance.PublicVariable.Stamina = 120.0f;
        else if (OverallManager.Instance.PublicVariable.Fullness >= 75)
            OverallManager.Instance.PublicVariable.Stamina = 100.0f;
        else
            OverallManager.Instance.PublicVariable.Stamina = (OverallManager.Instance.PublicVariable.Fullness >= 70) ? 90.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 65) ? 80.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 60) ? 70.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 55) ? 60.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 50) ? 50.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 45) ? 40.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 40) ? 30.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 35) ? 20.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 30) ? 10.0f : 0.0f;

        if (OverallManager.Instance.PublicVariable.IsRest == true)
        {
            OverallManager.Instance.PublicVariable.Stamina += 20;
        }
    }

    // ���� ���� �� ��Ʈ ����
    public void DecreaseHeartsOnAttack()
    {
        OverallManager.Instance.PublicVariable.Hearts -= -1;
    }

    //��ħ�� ��Ʈ ������
    public void ResetHearts()
    {
        OverallManager.Instance.PublicVariable.Hearts = OverallManager.Instance.PublicVariable.MaxHearts;
    }

    //��ħ�� ������ ����
    public void Contamination_Increases()
    {
        if (OverallManager.Instance.PublicVariable.IsRebeccaCured != true)
        {
            OverallManager.Instance.PublicVariable.Contamination += Random.Range(25, 36);
        }
    }

    //������ 1. ����ī ������. �׻��� ��� ���� üũ��. 3�ð� �Һ�. ���¹̳� 30 �Һ�.
    public void Care_Rebecca(bool antibiotic_use)
    {
        if (Time_And_Stamina_Check(3,30))
        {
            {
                if (antibiotic_use == true)
                {
                    OverallManager.Instance.PublicVariable.Contamination -= Random.Range(25, 31);
                }
                else
                {
                    if (OverallManager.Instance.PublicVariable.Contamination <= 81)
                    {
                        OverallManager.Instance.PublicVariable.Contamination -= Random.Range(10, 21);
                    }
                    else
                    {

                    }
                }
                Time_And_Stamina_Increase(3, 30);
            }
        }
    }

    //������ 2. ���� Ž��. 3�ð� �Һ�. ���¹̳� 20 �Һ�.
    public void Gather_Info(bool laptop_use)
    {
        if (Time_And_Stamina_Check(3, 20))
        {
            {
                if (laptop_use == true)
                {
                }
                else
                {
                }
                Time_And_Stamina_Increase(3, 20);
            }
        }
    }

    //������ 3. �ٱ� Ž���ϱ�. �ּ� 1�ð� �Һ�. ���¹̳� 50 �Һ�.
    public void Exploring_Outside()
    {
        if (Time_And_Stamina_Check(1, 50))
        {
            {
                OverallManager.Instance.PublicVariable.Am_I_outside = true;
                Time_And_Stamina_Increase(1, 50);
            }
        }
    }

    //������ 4. �޽��ϱ�. 2�ð� �Һ�. ���¹̳� 10 ȸ��.
    public void Rest()
    {
        if (Time_And_Stamina_Check(1, 0))
        {
            {
                if (OverallManager.Instance.PublicVariable.Fullness >= 40)
                {
                    Time_And_Stamina_Increase(1, -10);
                }
                else
                {
                    Time_And_Stamina_Increase(1, 10);
                }
            }
        }
    }

    //������ 5. ��ϱ�. 5�ð� �Һ�. ���¹̳� 40 �Һ�. �ִ� ��Ʈ 1 ����.
    public void Exercise()
    {
        if (Time_And_Stamina_Check(5, 40))
        {
            {
                OverallManager.Instance.PublicVariable.MaxHearts += 1;
                OverallManager.Instance.PublicVariable.Hearts += 1;
                Time_And_Stamina_Increase(5, 40);
            }
        }
    }

    //����ī ���� Ȯ��
  public void Check_Rebecca_status()
    {
        RebeccaStatus rebeccaStatus = OverallManager.Instance.PublicVariable.RebeccaStatus;

        if (rebeccaStatus == RebeccaStatus.Cold)
        {
            // Cold ���¿� ���� ó��
        }
        else if (rebeccaStatus == RebeccaStatus.Unstable)
        {
            // Unstable ���¿� ���� ó��
            if (Random.Range(0f, 100f) < 5f)
            {
                Attacked_From_Rebecca();
            }
        }
        else if (rebeccaStatus == RebeccaStatus.Violent)
        {
            // Violent ���¿� ���� ó��
            if (Random.Range(0f, 100f) < 25f)
            {
                Attacked_From_Rebecca();
            }
        }
        else if (rebeccaStatus == RebeccaStatus.ZombieLike)
        {
            // ZombieLike ���¿� ���� ó��
            if (Random.Range(0f, 100f) < 50f)
            {
                Attacked_From_Rebecca();
            }
        }
        else if (rebeccaStatus == RebeccaStatus.AlmostZombie)
        {
            // AlmostZombie ���¿� ���� ó��
                Attacked_From_Rebecca();
        }
        else if (rebeccaStatus == RebeccaStatus.Zombie)
        {
            Ending(Ending_type.Infection);
        }
    }

    private void Attacked_From_Rebecca()
    {
        OverallManager.Instance.PublicVariable.Stamina -= 10;
        if (OverallManager.Instance.PublicVariable.Stamina < 0)
        {
        }
    }

    //���� �� �̵� �޼���
    public void Ending(Ending_type end)
    {
        if(OverallManager.Instance.PublicVariable.GameState != GameState.Cutscene)
        {
         OverallManager.Instance.UiManager.HideDialog();
         OverallManager.Instance.PlayerManager.ResetRch();
        OverallManager.Instance.UiManager.HideStateUI();
            OverallManager.Instance.UiManager.ShowRebeccaUI(false);
         OverallManager.Instance.PublicVariable.Ending_Type = end;
        OverallManager.Instance.PublicVariable.GameState = GameState.Cutscene;
        OverallManager.Instance.PublicVariable.NextCoordinate = new Vector3 (0,0, 0);
        OverallManager.Instance.SceneTransition.TransitToNextScene("Ending Scene");
        }
        /*
        if(end == Ending_type.GameOver)
        {

        }
        else if(end == Ending_type.Infection)
        {

        }
        else if(end == Ending_type.Starvation)
        {

        }
        else if(end == Ending_type.Normal)
        {

        }
        else if(end == Ending_type.True)
        {

        }
        else if(end == Ending_type.OverNight)
        {

        }
        */
    }


    //�ð� �� ���׹̳� üũ
    private bool Time_And_Stamina_Check(int time, float stamina)
    {
        if ((OverallManager.Instance.PublicVariable.CurrentHour + time) > 24)
        {
            Debug.Log("�� �۾��� �ϱ⿡�� �ð��� ������ �� ����.");
            return false;
        }
        if ((OverallManager.Instance.PublicVariable.Stamina - stamina < 0))
        {
            Debug.Log("���¹̳��� �����ϴ�.");
            return false;
        }
        return true;
    }

    //�ð� �� ���¹̳� ����
    private void Time_And_Stamina_Increase(int time, float stamina)
    {
        OverallManager.Instance.PublicVariable.CurrentHour += time;
        OverallManager.Instance.PublicVariable.Stamina -= stamina;
    }

    //���� ���ƿ��� �޼���
    public void Comeback_Home()
    {
        OverallManager.Instance.PublicVariable.Am_I_outside = false;
    }


    //


    // =======================================[����� ������ �޼ҵ� ������]==========================================
}
