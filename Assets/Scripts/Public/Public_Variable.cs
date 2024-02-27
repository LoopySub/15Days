using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public_Variable : BaseMonoBehaviour
{
    // ��������Ʈ �� �̺�Ʈ ����
    public delegate void TimeIncreaseEventHandler(int hoursIncreased);
    public static event TimeIncreaseEventHandler OnTimeIncreased;

    // ============================================[�鿪���� ������]=================================================

    private IOverallManager _overallManager;

    public IOverallManager OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[�迪���� ������]=================================================

    // ============================================[����� ���� ������]=================================================

    // 1. �ð� ��ġ
    private int currentHour = 0;
    public int CurrentHour
    {
        get { return currentHour; }
        set { currentHour = Mathf.Clamp(value, 0, 24); }
    }

    // ���� �ð� ��ġ
    private int accumulatedHours = 0;
    public int AccumulatedHours
    {
        get { return accumulatedHours; }
        set
        {
            int hoursIncreased = value - accumulatedHours;
            accumulatedHours = value;

            // ���� �ð��� ������ �� �̺�Ʈ �߻�
            OnTimeIncreased?.Invoke(hoursIncreased);
        }
    }

    // 2. float ���¹̳� ��ġ 0~100
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set { stamina = Mathf.Clamp(value, 0f, 120f); }
    }

    // 3. float ��θ� fullness ��ġ 0~100
    private float fullness = 100.0f;
    public float Fullness
    {
        get { return fullness; }
        set
        {
            fullness = Mathf.Clamp(value, 0f, 100f);
        }
    }
    // ��ħ �� ���¹̳� ȸ���� ���
    public void RecoverStaminaAfterSleep()
    {
        if (fullness >= 100)
            Stamina = 120.0f;
        else if (fullness >= 75)
            Stamina = 100.0f;
        else
            Stamina = (fullness >= 70) ? 90.0f :
                        (fullness >= 65) ? 80.0f :
                        (fullness >= 60) ? 70.0f :
                        (fullness >= 55) ? 60.0f :
                        (fullness >= 50) ? 50.0f :
                        (fullness >= 45) ? 40.0f :
                        (fullness >= 40) ? 30.0f :
                        (fullness >= 35) ? 20.0f :
                        (fullness >= 30) ? 10.0f : 0.0f;
    }

    // 4. ����ī�� ������ ��ġ 0~100
    private float contamination = 0.0f;
    public float Contamination
    {
        get { return contamination; }
        set { contamination = Mathf.Clamp(value, 0f, 100f); }
    }

    // 5. �ٱ� Ž�� �� ü�� ��ġ
    private float hearts = 3;
    private float maxHearts = 3; 

    public float Hearts
    {
        get { return hearts; }
        set { hearts = Mathf.Max(value, 0); }
    }

    public float MaxHearts
    {
        get { return maxHearts; }
        set { maxHearts = Mathf.Max(value, 1); }
    }

    // ���� ���� üũ
    public bool IsGameOver()
    {
        return Hearts <= 0;
    }

    // ���� ���� �� ��Ʈ ����
    public void DecreaseHeartsOnAttack()
    {
        Hearts = Mathf.Max(hearts - 1, 0);
    }

    // ��Ʈ �ʱ�ȭ
    public void ResetHearts()
    {
        Hearts = maxHearts;
    }

    private void Start()
    {
        // �̺�Ʈ �ڵ鷯 ���
        OnTimeIncreased += HandleTimeIncrease;
    }

    private void HandleTimeIncrease(int hoursIncreased)
    {
        // ��θ� ����
        Fullness -= 1.5f * hoursIncreased;
    }
    // ============================================[����� ���� ������]=================================================
}


