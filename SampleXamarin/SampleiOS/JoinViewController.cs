﻿using System;

using UIKit;
using System.Threading.Tasks;
using CoreFoundation;
using System.Collections.Generic;

namespace HelpLightning.SDK.Sample.iOS
{
    public partial class JoinViewController : UIViewController, ICallClientDelegate
    {
        private static readonly string DefaultUserName = "small_u13";
        private static readonly string HLApiKey = "[YOUR_HL_API_KEY]";

        public JoinViewController(IntPtr handle) : base(handle)
        {
            CallClientFactory.Instance.CallClient.Delegate = this;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            sessionPINTextField.Text = CallManager.Instance.SessionPIN;
            sessionIDTextField.Text = CallManager.Instance.SessionID;
            sessionTokenTextView.Text = CallManager.Instance.SessionToken;
            userNameTextField.Text = CallManager.Instance.UserName;
            userAvatarTextField.Text = CallManager.Instance.UserAvatar;
            gssServerURLTextField.Text = CallManager.Instance.GssServerURL;
            userNameTextField.Text = DefaultUserName;

            camOnSwitch.On = CallManager.Instance.AutoEnableCamera;
            micOnSwitch.On = CallManager.Instance.AutoEnableMicrophone;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void OnJoinCall(UIButton sender)
        {
            SetupTheme();
            CallManager.Instance.SessionID = sessionIDTextField.Text.Trim();
            CallManager.Instance.SessionToken = sessionTokenTextView.Text.Trim();
            CallManager.Instance.UserName = userNameTextField.Text.Trim();
            CallManager.Instance.UserAvatar = userAvatarTextField.Text.Trim();
            CallManager.Instance.GssServerURL = gssServerURLTextField.Text.Trim();
            CallManager.Instance.AutoEnableCamera = camOnSwitch.On;
            CallManager.Instance.AutoEnableMicrophone = micOnSwitch.On;
            Call call = new Call(CallManager.Instance.SessionID,
                CallManager.Instance.SessionToken,
                CallManager.Instance.UserToken,
                CallManager.Instance.GssServerURL,
                HLApiKey,
                CallManager.Instance.UserName,
                CallManager.Instance.UserAvatar,
                CallManager.Instance.AutoEnableCamera,
                CallManager.Instance.AutoEnableMicrophone
                );

            joinButton.Enabled = false;
            indicator.Hidden = false;

            Task<IDictionary<string, object>> task = CallClientFactory.Instance.CallClient.StartCall(call, this);
            task.ContinueWith(t =>
            {
                DispatchQueue.MainQueue.DispatchAsync(() =>
                {
                    if (!t.IsFaulted)
                    {
                        Console.WriteLine("The call has started: " + t.Result[Call.HLCallInfoCallIDKey]);
                    }
                    else
                    {
                        Console.Error.WriteLine("Cannot start the call: " + t.Exception);
                    }

                    joinButton.Enabled = true;
                    indicator.Hidden = true;
                });
            });
        }

        partial void OnCancel(UIBarButtonItem sender)
        {
            this.PresentingViewController.DismissViewController(true, null);
        }

        private void SetupTheme()
        {
            var index = themColorPicker.SelectedSegment;
            Theme theme = null;
            switch (index)
            {
                case 1:
                    theme = new Theme();
                    theme.SetColor(Theme.ColorMain, UIColor.DarkGray);
                    break;

                case 2:
                    theme = new Theme();
                    theme.SetColor(Theme.ColorMain, UIColor.Orange);
                    break;
                case 3:
                    theme = new Theme();
                    theme.SetColor(Theme.ColorMain, UIColor.Purple);
                    theme.SetImage(Theme.ImageMainMenuDocumentOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageMainMenuDocumentOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageMainMenuTorchOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageMainMenuTorchOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageMainMenu, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.ImageModeMenuFaceToFaceOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageModeMenuFaceToFaceOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageModeMenuReceiverOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageModeMenuReceiverOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageModeMenuGiverOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageModeMenuGiverOff, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.ImageCameraMenuPhotoOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuPhotoOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuFreezeOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuFreezeOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuCameraOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuSwitchCamera, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuFrontCameraOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuFrontCameraOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuBackCameraOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuBackCameraOff, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.ImageMicOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageMicOff, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.ImageTelestrationMenuColorUnselected, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationMenuColorSelected, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationMenuArrowOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationMenuArrowOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationMenuPenOn, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationMenuPenOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationUndo, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationClearAll, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.ImageEndCall, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.imageScreenCaptureButton1, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.imageScreenCaptureButton2, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.imageScreenCaptureButton3, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.ImageTelestrationMenuArrowSelected, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageTelestrationMenuPenSelected, UIImage.FromBundle("Lightning"));

                    theme.SetImage(Theme.ImageCameraMenuLiveVideoOff, UIImage.FromBundle("Lightning"));
                    theme.SetImage(Theme.ImageCameraMenuLiveVideoOn, UIImage.FromBundle("Lightning"));
                    break;
                default:
                    break;
            }
            CallClientFactory.Instance.CallClient.Theme = theme;
        }

        public void OnCallEnded(Call call, string reason)
        {
            Console.WriteLine("Call Ended");
        }

        public void OnScreenCaptureCreated(Call call, object image)
        {
            Console.WriteLine("Screen Captured");
            imagePreview.Image = (UIImage)image;
        }
    }
}

