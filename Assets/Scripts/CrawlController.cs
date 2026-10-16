using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrawlController
{
    [SerializeField] private DataStorage data;
    [SerializeField] private float speedCrow;
    private CapsuleCollider2D collider2D;
    private bool isCrawl = false;
    public void IsCrawl(bool isC) => isCrawl = isC;

    public void GetCrawlPlayer()
    {
        PlayerMove.singltoneMove.ChangeSpeed(data.SpeedCraw);
    }

    public void DeackCrowPlayer()
    {
        PlayerMove.singltoneMove.ChangeSpeed(data.SpeedWalk);
    }
}
