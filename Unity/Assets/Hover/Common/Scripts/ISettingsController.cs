using System;

namespace Hover.Common.Util {

	/*================================================================================================*/
	public interface ISettingsController {

		string name { get; }
		bool isActiveAndEnabled { get; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		Type GetType();

	}

}