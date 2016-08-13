﻿using System;

namespace Hover.Items.Types {

	/*================================================================================================*/
	[Serializable]
	public class HoverItemDataCheckbox : HoverItemDataSelectableBool, IItemDataCheckbox {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Select() {
			Value = !Value;
			base.Select();
		}

	}

}
