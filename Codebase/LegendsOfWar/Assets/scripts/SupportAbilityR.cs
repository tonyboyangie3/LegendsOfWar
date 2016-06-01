﻿public class SupportAbilityR : AbilityRBase
{
	private Info[ ] entities;
	protected override void AbilityActivate()
	{
		base.AbilityActivate();
		entities = FindObjectsOfType<Info>();
		foreach ( Info entity in entities )
			if ( entity.team == heroInfo.team )
				entity.HP += 25.0f;
	}
}
#region OLD_CODE
#if false
public class SupportAbilityR : AbilityRBase
{
	Info[ ] entities;
	protected override void AbilityActivate()
	{
		base.AbilityActivate();
		entities = FindObjectsOfType<Info>();
		foreach ( Info entity in entities )
			if ( entity.team == heroInfo.team )
				entity.HP = entity.HP + 25.0f;
	}
}
#endif
#endregion //OLD_CODE