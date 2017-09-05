using System;
using System.Drawing;

using Foundation;
using UIKit;

namespace DragAndSnap
{
	public partial class DragAndSnapViewController : UIViewController
	{
		public DragAndSnapViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            View.UserInteractionEnabled = true;
		}
	}
}

