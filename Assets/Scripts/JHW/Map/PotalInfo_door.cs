using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalInfo_door : MonoBehaviour
{
    [SerializeField] private string NextMap;
    [SerializeField] private Vector3 NextCoordinate;
    [SerializeField] private bool In_Or_Out;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌한 경우
            OverallManager.Instance.PublicVariable.NextCoordinate = NextCoordinate; //플레이어의 다음 맵 위치 전달
            OverallManager.Instance.PublicVariable.Am_I_outside = In_Or_Out;
            OverallManager.Instance.SceneTransition.TransitToNextScene(NextMap);
        }
    }
}
