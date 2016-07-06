using System.Collections.Generic;
using Hover.Renderers.Elements.Sliders;
using Hover.Renderers.Elements.Shapes;
using Hover.Renderers.Utils;
using Hover.Utils;
using UnityEngine;

namespace Hover.Renderers.Elements.Sliders {

	/*================================================================================================*/
	[ExecuteInEditMode]
	[RequireComponent(typeof(HoverFillSlider))]
	[RequireComponent(typeof(HoverShape))]
	public abstract class HoverFillSliderUpdater : MonoBehaviour, ITreeUpdateable, ISettingsController {

		public ISettingsControllerMap Controllers { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected HoverFillSliderUpdater() {
			Controllers = new SettingsControllerMap();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			//do nothing...
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TreeUpdate() {
			UpdateFillMeshes();
			UpdateTickMeshes();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void UpdateFillMeshes() {
			HoverFillSlider fillSlider = gameObject.GetComponent<HoverFillSlider>();

			if ( fillSlider.SegmentInfo == null ) {
				return;
			}

			List<SliderUtil.SegmentInfo> segInfoList = fillSlider.SegmentInfo.SegmentInfoList;
			int segCount = fillSlider.GetChildMeshCount();
			int segIndex = 0;
			float startPos = segInfoList[0].StartPosition;
			float endPos = segInfoList[segInfoList.Count-1].EndPosition;

			for ( int i = 0 ; i < segCount ; i++ ) {
				ResetFillMesh(fillSlider.GetChildMesh(i));
			}

			for ( int i = 0 ; i < segInfoList.Count ; i++ ) {
				SliderUtil.SegmentInfo segInfo = segInfoList[i];

				if ( segInfo.Type != SliderUtil.SegmentType.Track ) {
					continue;
				}

				UpdateFillMesh(fillSlider.GetChildMesh(segIndex++), segInfo, startPos, endPos);
			}

			for ( int i = 0 ; i < segCount ; i++ ) {
				ActivateFillMesh(fillSlider.GetChildMesh(i));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void ResetFillMesh(HoverMesh pSegmentMesh);

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void UpdateFillMesh(HoverMesh pSegmentMesh,
			SliderUtil.SegmentInfo pSegmentInfo, float pStartPos, float pEndPos);

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void ActivateFillMesh(HoverMesh pSegmentMesh);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void UpdateTickMeshes() {
			HoverFillSlider fillSlider = gameObject.GetComponent<HoverFillSlider>();

			if ( fillSlider.SegmentInfo == null ) {
				return;
			}

			List<SliderUtil.SegmentInfo> tickInfoList = fillSlider.SegmentInfo.TickInfoList;

			for ( int i = 0 ; i < tickInfoList.Count ; i++ ) {
				UpdateTickMesh(fillSlider.Ticks[i], tickInfoList[i]);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void UpdateTickMesh(HoverMesh pTickMesh, SliderUtil.SegmentInfo pTickInfo);

	}

}