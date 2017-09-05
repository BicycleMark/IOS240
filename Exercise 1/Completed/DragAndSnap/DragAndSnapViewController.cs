using System;
using System.Drawing;

using Foundation;
using UIKit;
using CoreGraphics;

namespace DragAndSnap
{
	public partial class DragAndSnapViewController : UIViewController
	{
		bool imageIsMoving = false;

		public DragAndSnapViewController (IntPtr handle) : base (handle)
		{
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);

			var touch = touches.AnyObject as UITouch;

			if (touch == null) 
				return;

			if (imgLogo.Frame.Contains (touch.LocationInView (View)))
				imageIsMoving = true;
		}

		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			base.TouchesMoved (touches, evt);

			var touch = touches.AnyObject as UITouch;

			if (touch == null || imageIsMoving == false) 
				return;

			nfloat deltaX = touch.PreviousLocationInView(View).X - touch.LocationInView(View).X;
			nfloat deltaY = touch.PreviousLocationInView(View).Y - touch.LocationInView(View).Y;

			var newPoint = new CGPoint (imgLogo.Frame.X - deltaX, imgLogo.Frame.Y - deltaY);

			imgLogo.Frame = new CGRect(newPoint, imgLogo.Frame.Size);
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);

			var touch = touches.AnyObject as UITouch;

			if (touch == null || imageIsMoving == false) 
				return;

			if (boxOne.Frame.Contains (imgLogo.Center) == true) 
			{
				imgLogo.Center = boxOne.Center;
			} 
		
			else if (boxTwo.Frame.Contains (imgLogo.Center) == true) 
			{
				imgLogo.Center = boxTwo.Center;
			} 
			else 
			{
				imgLogo.Center = this.View.Center;
			}

			imageIsMoving = false;
		}

		public override void TouchesCancelled (NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled (touches, evt);

			imageIsMoving = false;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.View.BringSubviewToFront (imgLogo);
		}
	}
}

