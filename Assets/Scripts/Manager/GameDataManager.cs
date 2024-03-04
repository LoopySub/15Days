using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Public_Enum;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GameDataManager : BaseMonoBehaviour    // 게임 데이터를 직접적으로 관리하는 메서드와 동작들이 있는 스크립트
{
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
    // =======================================[↓게임 데이터 메소드 구역↓]==========================================
    
    
    //취침 시 배부름에 따라 스태미나 회복
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

    // 공격 받을 시 하트 감소
    public void DecreaseHeartsOnAttack()
    {
        OverallManager.Instance.PublicVariable.Hearts -= -1;
    }

    //취침시 하트 재충전
    public void ResetHearts()
    {
        OverallManager.Instance.PublicVariable.Hearts = OverallManager.Instance.PublicVariable.MaxHearts;
    }

    //취침시 오염도 증가
    public void Contamination_Increases()
    {
        if (OverallManager.Instance.PublicVariable.IsRebeccaCured != true)
        {
            OverallManager.Instance.PublicVariable.Contamination += Random.Range(25, 36);
        }
    }

    //선택지 1. 레베카 돌보기. 항생제 사용 유무 체크함. 3시간 소비. 스태미나 30 소비.
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

    //선택지 2. 정보 탐색. 3시간 소비. 스태미나 20 소비.
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

    //선택지 3. 바깥 탐사하기. 최소 1시간 소비. 스태미나 50 소비.
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

    //선택지 4. 휴식하기. 2시간 소비. 스태미나 10 회복.
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

    //선택지 5. 운동하기. 5시간 소비. 스태미나 40 소비. 최대 하트 1 증가.
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

    //레베카 상태 확인
  public void Check_Rebecca_status()
    {
        RebeccaStatus rebeccaStatus = OverallManager.Instance.PublicVariable.RebeccaStatus;

        if (rebeccaStatus == RebeccaStatus.Cold)
        {
            // Cold 상태에 대한 처리
        }
        else if (rebeccaStatus == RebeccaStatus.Unstable)
        {
            // Unstable 상태에 대한 처리
            if (Random.Range(0f, 100f) < 5f)
            {
                Attacked_From_Rebecca();
            }
        }
        else if (rebeccaStatus == RebeccaStatus.Violent)
        {
            // Violent 상태에 대한 처리
            if (Random.Range(0f, 100f) < 25f)
            {
                Attacked_From_Rebecca();
            }
        }
        else if (rebeccaStatus == RebeccaStatus.ZombieLike)
        {
            // ZombieLike 상태에 대한 처리
            if (Random.Range(0f, 100f) < 50f)
            {
                Attacked_From_Rebecca();
            }
        }
        else if (rebeccaStatus == RebeccaStatus.AlmostZombie)
        {
            // AlmostZombie 상태에 대한 처리
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

    //엔딩 씬 이동 메서드
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


    //시간 및 스테미나 체크
    private bool Time_And_Stamina_Check(int time, float stamina)
    {
        if ((OverallManager.Instance.PublicVariable.CurrentHour + time) > 24)
        {
            Debug.Log("이 작업을 하기에는 시간이 부족할 것 같다.");
            return false;
        }
        if ((OverallManager.Instance.PublicVariable.Stamina - stamina < 0))
        {
            Debug.Log("스태미나가 부족하다.");
            return false;
        }
        return true;
    }

    //시간 및 스태미나 증가
    private void Time_And_Stamina_Increase(int time, float stamina)
    {
        OverallManager.Instance.PublicVariable.CurrentHour += time;
        OverallManager.Instance.PublicVariable.Stamina -= stamina;
    }

    //집에 돌아오는 메서드
    public void Comeback_Home()
    {
        OverallManager.Instance.PublicVariable.Am_I_outside = false;
    }


    //


    // =======================================[↑게임 데이터 메소드 구역↑]==========================================
}
