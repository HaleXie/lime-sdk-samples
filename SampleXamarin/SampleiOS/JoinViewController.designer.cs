﻿// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HelpLightning.SDK.Sample.iOS
{
	[Register ("JoinViewController")]
	partial class JoinViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UISwitch camOnSwitch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField gssServerURLTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIImageView imagePreview { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIActivityIndicatorView indicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIButton joinButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UISwitch micOnSwitch { get; set; }

		[Outlet]
		UIKit.UIView minimizedCallContainer { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField sessionIDTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField sessionPINTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextView sessionTokenTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UISegmentedControl themColorPicker { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField userAvatarTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField userNameTextField { get; set; }

		[Action ("OnCancel:")]
		partial void OnCancel (UIKit.UIBarButtonItem sender);

		[Action ("OnJoinCall:")]
		partial void OnJoinCall (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (camOnSwitch != null) {
				camOnSwitch.Dispose ();
				camOnSwitch = null;
			}

			if (gssServerURLTextField != null) {
				gssServerURLTextField.Dispose ();
				gssServerURLTextField = null;
			}

			if (imagePreview != null) {
				imagePreview.Dispose ();
				imagePreview = null;
			}

			if (indicator != null) {
				indicator.Dispose ();
				indicator = null;
			}

			if (joinButton != null) {
				joinButton.Dispose ();
				joinButton = null;
			}

			if (micOnSwitch != null) {
				micOnSwitch.Dispose ();
				micOnSwitch = null;
			}

			if (sessionIDTextField != null) {
				sessionIDTextField.Dispose ();
				sessionIDTextField = null;
			}

			if (sessionPINTextField != null) {
				sessionPINTextField.Dispose ();
				sessionPINTextField = null;
			}

			if (sessionTokenTextView != null) {
				sessionTokenTextView.Dispose ();
				sessionTokenTextView = null;
			}

			if (themColorPicker != null) {
				themColorPicker.Dispose ();
				themColorPicker = null;
			}

			if (userAvatarTextField != null) {
				userAvatarTextField.Dispose ();
				userAvatarTextField = null;
			}

			if (userNameTextField != null) {
				userNameTextField.Dispose ();
				userNameTextField = null;
			}

			if (minimizedCallContainer != null) {
				minimizedCallContainer.Dispose ();
				minimizedCallContainer = null;
			}
		}
	}
}
