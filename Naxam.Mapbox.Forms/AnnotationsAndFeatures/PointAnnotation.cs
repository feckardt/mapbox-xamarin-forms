using System;
namespace Naxam.Controls.Mapbox.Forms
{
	public class PointAnnotation: Annotation
	{
		public PointAnnotation()
		{
		}

		public Position Coordinate
		{
			get;
			set;
		}

		public EventHandler<string> FinishDragged { get; set; }

	}
}
