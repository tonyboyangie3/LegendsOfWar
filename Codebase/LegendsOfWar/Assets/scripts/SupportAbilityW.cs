﻿using UnityEngine;
using System.Collections.Generic;
public class SupportAbilityW : AbilityWBase
{
	[SerializeField]
	private GameObject Icon = null;
	private List<MinionInfo> applied = new List<MinionInfo>();
	private SupportRange supprang;
	private MarkedEnemyIcon mei;
	private MinionInfo temp;
	protected override void Start()
	{
		base.Start();
		supprang = heroInfo.GetComponentInChildren<SupportRange>();
	}
	protected override void AbilityActivate()
	{
		base.AbilityActivate();
		supprang.ApplyToAlliesInRange( SoulDefense );
	}
	protected override void AbilityDeactivate()
	{
		base.AbilityDeactivate();
		foreach ( MinionInfo minion in applied )
			if ( minion )
			{
				minion.soulDefense = false;
				mei = minion.GetComponentInChildren<MarkedEnemyIcon>();
				if ( mei )
					Destroy( mei.gameObject );
			}
	}
	private void SoulDefense( Info entity )
	{
		temp = entity as MinionInfo;
		if ( temp )
		{
			if ( !temp.soulDefense )
			{
				temp.soulDefense = true;
				applied.Add( temp );
				( Instantiate( Icon, temp.transform.position, temp.transform.rotation ) as
					GameObject ).transform.parent = temp.transform;
			}
		}
	}
}
#region OLD_CODE
#if false
using UnityEngine;
using System.Collections.Generic;
public class SupportAbilityW : AbilityWBase
{
	[SerializeField]
	GameObject Icon = null;
	List<MinionInfo> applied = new List<MinionInfo>();
	SupportRange supprang;
	protected override void Start()
	{
		base.Start();
		supprang = heroInfo.GetComponentInChildren<SupportRange>();
	}
	protected override void AbilityActivate()
	{
		base.AbilityActivate();
		supprang.ApplyToAlliesInRange( SoulDefense );
	}
	MarkedEnemyIcon mei;
	protected override void AbilityDeactivate()
	{
		base.AbilityDeactivate();
		foreach ( MinionInfo minion in applied )
			if ( minion )
			{
				minion.soulDefense = false;
				mei = minion.GetComponentInChildren<MarkedEnemyIcon>();
				if ( mei )
					Destroy( mei.gameObject );
			}
	}
	MinionInfo temp;
	void SoulDefense( Info entity )
	{
		temp = entity as MinionInfo;
		if ( temp )
		{
			if ( !temp.soulDefense )
			{
				temp.soulDefense = true;
				applied.Add( temp );
				( Instantiate( Icon, temp.transform.position,
					temp.transform.rotation ) as GameObject )
					.transform.parent = temp.transform;
			}
		}
	}
}
#endif
#endregion //OLD_CODE