using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameManager : MonoBehaviour
{
    public static CharacterGameManager instance;

    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }
}