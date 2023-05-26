using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public UnityEvent<int> OnPlayerHpChanged;

    private int player_hp;

    public void ChangePlayerHp(int player_hp)
    {
        OnPlayerHpChanged?.Invoke(player_hp);
    }
}
