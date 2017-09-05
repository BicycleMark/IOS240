using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Group
{
	partial class MyView : UIView
	{
		public MyView (IntPtr handle) : base (handle)
		{
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);

			Console.WriteLine ("TouchesBegan");
		}

		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			base.TouchesMoved (touches, evt);

			Console.WriteLine ("TouchesMoved");
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);

			Console.WriteLine ("TouchesEnded");
		}

		public override void TouchesCancelled (NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled (touches, evt);

			Console.WriteLine ("TouchesCancelled");
		}
	}
}
