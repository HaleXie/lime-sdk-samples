//
//  JoinViewController.swift
//  SampleSwift
//
//  Created by Hale Xie on 2020/1/21.
//  Copyright © 2020 Helplightning. All rights reserved.
//

import UIKit
import HLSDK
import HLSDKSwift

let kDefaultUserName = "small_u13";

class JoinViewController: UIViewController {
    @IBOutlet private var gssServerURLTextField: UITextField!
    @IBOutlet private var sessionIDTextField: UITextField!
    @IBOutlet private var sessionPINTextField: UITextField!
    @IBOutlet private var sessionTokenTextView: UITextView!
    @IBOutlet private var userAvatarTextField: UITextField!
    @IBOutlet private var userNameTextField: UITextField!
    @IBOutlet private weak var joinButton: UIButton!
    @IBOutlet private weak var indicator: UIActivityIndicatorView!
    @IBOutlet private weak var themColorPicker: UISegmentedControl!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        sessionPINTextField.text = CallManager.sharedInstance().sessionPIN
        sessionIDTextField.text = CallManager.sharedInstance().sessionID
        sessionTokenTextView.text = CallManager.sharedInstance().sessionToken
        userNameTextField.text = CallManager.sharedInstance().userName;
        userAvatarTextField.text = CallManager.sharedInstance().userAvatar;
        gssServerURLTextField.text = CallManager.sharedInstance().gssServerURL;
        userNameTextField.text = kDefaultUserName;
    }
    
    @IBAction func OnCancel(_ sender: Any) {
        HLClientSwift.shared.stopCurrentCall().always {
            self.presentingViewController?.dismiss(animated: true, completion: nil);
        };
    }
    
    @IBAction func OnJoinCall(_ sender: Any) {
        _setupTheme()
        
        CallManager.sharedInstance().sessionID = sessionIDTextField.text
        CallManager.sharedInstance().sessionToken = sessionTokenTextView.text
        CallManager.sharedInstance().userName = userNameTextField.text
        CallManager.sharedInstance().userAvatar = userAvatarTextField.text
        CallManager.sharedInstance().gssServerURL = gssServerURLTextField.text

        guard let call = HLCall(sessionId: CallManager.sharedInstance().sessionID, sessionToken: CallManager.sharedInstance().sessionToken, userToken: CallManager.sharedInstance().userToken, gssUrl: CallManager.sharedInstance().gssServerURL, localUserDisplayName: CallManager.sharedInstance().userName, localUserAvatarUrl: CallManager.sharedInstance().userAvatar) else { return; }
        
        //  Converted to Swift 5.1 by Swiftify v5.1.33915 - https://objectivec2swift.com/
        joinButton.isEnabled = false
        indicator.isHidden = false
        HLClientSwift.shared.startCall(call: call, viewController: self).then({ value in
            print("The call has started")
        }).catch({ error in
            print("Cannot start the call:\(error)")
        }).always({
            self.indicator.isHidden = true
            self.joinButton.isEnabled = true
        })

    }
    
    func _setupTheme () {
        let index = themColorPicker.selectedSegmentIndex
        var theme: HLTheme? = nil
        switch index {
            case 1:
                theme = HLTheme()
                theme?.setColor(kHLMainColor, color: UIColor.darkGray)
                theme?.setImage(kHLImageModeMenuFaceToFaceOn, image: UIImage(named: "Lightning"))
            case 2:
                theme = HLTheme()
                theme?.setColor(kHLMainColor, color: UIColor.orange)
                theme?.setImage(kHLImageModeMenuFaceToFaceOn, image: UIImage(named: "03_contacts"))
            case 3:
                theme = HLTheme()
                theme?.setColor(kHLMainColor, color: UIColor.purple)
                theme?.setImage(kHLImageModeMenuFaceToFaceOn, image: UIImage(named: "03_contacts_active"))
                theme?.setImage(kHLImageModeMenuFaceToFaceOff, image: UIImage(named: "Lightning"))
            default:
                break
        }
        HLClientSwift.shared.setTheme(theme: theme);
    }

}