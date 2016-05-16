﻿using UnityEngine;
using System;

namespace Hover.Common {

	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Field)]
	public class DisableWhenControlledAttribute : PropertyAttribute {

		public string ControllerMapName { get; private set; }
		public bool DisplayMessage { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DisableWhenControlledAttribute(string pControllerMapName="Controllers") {
			ControllerMapName = pControllerMapName;
		}

	}

}