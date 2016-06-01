﻿using UnityEngine;
using System.Collections.Generic;
public class AttackScript : MonoBehaviour
{
	[SerializeField]
	protected Detector attackTrigger;
	[SerializeField]
	protected GameObject weapon, projectile;
	private ProjectileBehaviour p;
	protected void FireAtTarget( Transform _target, float _damage )
	{
		if ( _target && !GameManager.GameEnded )
		{
			if ( Team.BLUE_TEAM == _target.gameObject.GetComponent<Info>().team )
				weapon.transform.LookAt( _target, _target.up );
			p = ( Instantiate( projectile, weapon.transform.position, weapon.transform.rotation ) as
				GameObject ).GetComponent<ProjectileBehaviour>();
			p.speed = 120.0f;
			p.damage = _damage;
			p.target = _target;
			p.Fire();
		}
	}
}
public class ProximityCompare : IComparer<Transform>
{
	public int Compare( Transform _obja, Transform _objb )
	{
		if ( _obja && _objb )
			return ( int )Vector3.Distance( _obja.position, _objb.position );
		return 0;
	}
}
#region OLD_CODE
#if false
using UnityEngine;
using System.Collections.Generic;

public class ProximityCompare : IComparer<Transform>
{
    public int Compare(Transform _obja, Transform _objb)
    {
        if (_obja && _objb)
            return (int)Vector3.Distance(_obja.position, _objb.position);
        else
            return 0;
    }
}

public class AttackScript : MonoBehaviour
{
    protected MinionInfo Minioninfo;
    protected HeroInfo Heroinfo;
	[SerializeField]
	protected Detector attackTrigger;
    [SerializeField]
    protected GameObject weapon, projectile;

	ProjectileBehaviour p;
    protected void FireAtTarget(Transform _target, float _speed, float _damage)
    {
        if (_target&&!GameManager.GameEnded)
        {
            if(_target.gameObject.GetComponent<Info>().team == Team.BLUE_TEAM)
                weapon.transform.LookAt(_target, _target.up);
            p = (Instantiate(projectile, weapon.transform.position, weapon.transform.rotation) as GameObject).GetComponent<ProjectileBehaviour>();
            p.speed = _speed;
            p.damage = _damage;
            p.target = _target;
            //p.transform.parent = info.projectileSpawnPoint.transform;
            p.Fire();
            //AudioManager.Instance.PlaySoundEffect("TowerProjectile", transform.position);
        }
    }
}
#endif
#endregion //OLD_CODE