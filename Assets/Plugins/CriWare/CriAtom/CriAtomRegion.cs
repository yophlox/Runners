﻿/****************************************************************************
 *
 * Copyright (c) 2020 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;

/**
 * \addtogroup CRIATOM_UNITY_COMPONENT
 * @{
 */


/**
 * <summary>3D region component</summary>
 * <remarks>
 * <para header='Description'>A component that groups 3D sound sources, 3D listeners and transceivers by space.<br/>
 * Used by attaching to any GameObject.<br/>
 * This can be used as an value of region3d in CriAtomSource, CriAtomListener and CriAtomTransceiver,<br/>
 * or can be set as initial region setting.<br/>
 * Only one of this component can be attached to a GameObject.</para>
 * </remarks>
 * <seealso cref='CriAtomSource'/>
 * <seealso cref='CriAtomListener'/>
 * <seealso cref='CriAtomTransceiver'/>
 */
[AddComponentMenu("CRIWARE/CRI Atom Region"), DisallowMultipleComponent]
public class CriAtomRegion : CriMonoBehaviour
{
	#region Fields & Properties
	/**
	 * <summary>The CriAtomEx3dRegion used internally.</summary>
	 * <remarks>
	 * <para header='Description'>If you want to control CriAtomEx3dRegion directly, get CriAtomEx3dRegion from this property.</para>
	 * </remarks>
	 */
	public CriAtomEx3dRegion region3dHn { get; protected set; }
	#endregion

	#region Methods

	private void Awake()
	{
		this.InternalInitialize();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		this.InitializeParameters();
	}

	private void OnDestroy()
	{
		this.InternalFinalize();
	}

	protected virtual void InternalInitialize()
	{
		CriAtomPlugin.InitializeLibrary();
		this.region3dHn = new CriAtomEx3dRegion();
	}

	protected virtual void InternalFinalize()
	{
		region3dHn.Dispose();
		region3dHn = null;
		CriAtomPlugin.FinalizeLibrary();
	}

	protected virtual void InitializeParameters()
	{
		if (this.region3dHn == null) {
			Debug.LogError("[CRIWARE] Internal: CriAtomEx3dRegion is not created correctly.", this);
			return;
		}
	}

	public override void CriInternalUpdate() { }

	public override void CriInternalLateUpdate() { }

	#endregion
} // end of class

/** @} */
/* end of file */