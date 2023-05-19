using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CLSManager : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<LeaderboardManager>().ClearLeaderboard();
    }
}
