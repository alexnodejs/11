﻿using UnityEngine;
using System.Collections;

using Global;

public class EnemyBehavior
{
	private IEnemyBehavior _enemyBehavior;

	public EnemyBehavior(IEnemyBehavior enemyBehavior)
	{
		_enemyBehavior = enemyBehavior;
	}

	public void SetBehavior(IEnemyBehavior enemyBehavior)
	{
		_enemyBehavior = enemyBehavior;
	}

	public bool CanIMove()
	{
		return _enemyBehavior.CanIMove();
	}

	public bool CanIRotate()
	{
		return _enemyBehavior.CanIRotate();
	}
}
