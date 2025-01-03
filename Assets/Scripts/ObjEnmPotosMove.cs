using UnityEngine;

[AddComponentMenu("Scripts/Runners/Object/Enemy/ObjEnmPotosMove")]
public class ObjEnmPotosMove : ObjEnemyConstant
{
	protected override ObjEnemyUtil.EnemyType GetOriginalType()
	{
		return ObjEnemyUtil.EnemyType.NORMAL;
	}

	protected override string[] GetModelFiles()
	{
		return ObjEnmPotosData.GetModelFiles();
	}

	protected override ObjEnemyUtil.EnemyEffectSize GetEffectSize()
	{
		return ObjEnmPotosData.GetEffectSize();
	}
}
