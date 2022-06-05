using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IEnemy
{
    int Lifes { get; set; }
    bool CanMove { get; set; }
    Animator GetAnimator { get; }
    Rigidbody2D GetRigidbody2D { get; }
    GameObject GetSelf { get; }
    void Move();
    void OnCollisionEnter2D(Collision2D collision);
}

