using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInfo : BaseMonoBehaviour
{
    [SerializeField] private string NextMap;
    [SerializeField] private Vector3 NextCoordinate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("다음 맵 이동");
            // 플레이어와 충돌한 경우
            OverallManager.Instance.PublicVariable.NextCoordinate = NextCoordinate; //플레이어의 다음 맵 위치 전달
            UnityEngine.SceneManagement.SceneManager.LoadScene(NextMap);
        }
    }
}