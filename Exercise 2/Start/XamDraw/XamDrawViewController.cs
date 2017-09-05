using System;
using CoreGraphics;

using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace XamDraw
{
	public partial class XamDrawViewController : UIViewController
	{
		public XamDrawViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void TouchesCancelled (NSSet touches, UIEvent evt)
		{
			TouchesEnded (touches, evt);
		}

		Random rand = new Random ();
		UIColor GetRandomColor ()
		{
			return new UIColor ((float)rand.NextDouble (), (float)rand.NextDouble (), (float)rand.NextDouble (), 1.0f);
		} 

		void BtnClear_TouchUpInside (object sender, EventArgs e)
		{
			if (imgDraw != null && imgDraw.Image != null)
				imgDraw.Image.Dispose ();

			imgDraw.Image = new UIImage ();					
		}

		void DrawLine (CGPoint pt1, CGPoint pt2, UIColor color)
		{
			UIGraphics.BeginImageContext (imgDraw.Frame.Size);

			using (var g = UIGraphics.GetCurrentContext ())
			{
				imgDraw.Layer.RenderInContext (g);

				var path = new CGPath ();

				path.AddLines (new CGPoint[] { pt1, pt2 });

				g.SetLineWidth (3);
				color.SetStroke ();

				g.AddPath (path);
				g.DrawPath (CGPathDrawingMode.Stroke);

				imgDraw.Image = UIGraphics.GetImageFromCurrentImageContext ();
			}

			UIGraphics.EndImageContext ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			btnClear.TouchUpInside += BtnClear_TouchUpInside;
		}
	}
}

