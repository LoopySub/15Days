using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Public_Utility : BaseMonoBehaviour
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

    // ============================================[↓공용 기능성 메서드 구역↓]=================================================

    public static float Clamp(float value, float min, float max)  // 범위 제한 메서드
    {
        return Mathf.Clamp(value, min, max);
    }

    public static float CalculateDistance(Vector3 point1, Vector3 point2)  // 거리 계산 메서드
    {
        return Vector3.Distance(point1, point2);
    }

    public static int RandomRangeInt(int min, int max) // 랜덤 범위에서 정수 생성 메서드
    {
        return Random.Range(min, max + 1);
    }

    public static T Clone<T>(T original) where T : MonoBehaviour // 오브젝트 복제 메서드
    {
        return Instantiate(original);
    }

    public static void ChangeScene(string sceneName) // 씬 전환 메서드
    {
        SceneManager.LoadScene(sceneName);
    }

    public static IEnumerator Timer(float seconds, Action callback) // 타이머 메서드
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }

    public static void SetObjectActive(GameObject obj, bool isActive) // 오브젝트 활성화/비활성화 메서드
    {
        obj.SetActive(isActive);
    }

    public static Vector3 ScreenToWorldPoint(Vector3 screenPosition) // 화면 좌표를 월드 좌표로 변환 메서드
    {
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }


    // ============================================[↑공용 기능성 메서드 구역↑]=================================================


}
