namespace TestProject.Localization
{
    public static class L
    {
        public static class Alert
        {
            public static string HybridAlerts
            {
                get { return Ioc.Get<ITranslator>().Translate("t_alert_Hybrid_alerts"); }
            }
            public static string NoFeedback
            {
                get { return Ioc.Get<ITranslator>().Translate("t_alert_No_feedback"); }
            }
            public static string Ok
            {
                get { return Ioc.Get<ITranslator>().Translate("t_alert_Ok"); }
            }
            public static string VisibleInfo
            {
                get { return Ioc.Get<ITranslator>().Translate("t_alert_Visible_Info"); }
            }
        }
        
        public static class Availability
        {
            public static string AvailabilityDetails
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Availability_Details"); }
            }
            public static string AvailabilityOverview
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Availability_Overview"); }
            }
            public static string AvailabilitySettings
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Availability_Settings"); }
            }
            public static string EstimatedDistance
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Estimated_distance"); }
            }
            public static string EstimatedTimeEnRoute
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Estimated_time_en_route"); }
            }
            public static string Function
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Function"); }
            }
            public static string Overview
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Overview"); }
            }
            public static string Rank
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Rank"); }
            }
            public static string SelectGroup
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Select_group"); }
            }
            public static string ShowsUserStatusesForGroup
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Shows_user_statuses_for_group"); }
            }
            public static string Status
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Status"); }
            }
            public static string VisibleInfo
            {
                get { return Ioc.Get<ITranslator>().Translate("t_availability_Visible_Info"); }
            }
        }
        
        public static class Blue
        {
            public static string Bluetooth
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Bluetooth"); }
            }
            public static string BluetoothIsNotPoweredOn
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Bluetooth_is_not_powered_on"); }
            }
            public static string Cancel
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Cancel"); }
            }
            public static string Configuration
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Configuration"); }
            }
            public static string Connected
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Connected"); }
            }
            public static string ConnectingToPager
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Connecting_to_pager"); }
            }
            public static string ConnectionChangePrompt
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_connection_change_prompt"); }
            }
            public static string Disconnect
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Disconnect"); }
            }
            public static string FailedToConnectTryToForgetPager
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Failed_to_connect_Try_to_forget_pager"); }
            }
            public static string FailedToSave
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Failed_to_save"); }
            }
            public static string NoAvailableSettings
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_No_available_settings"); }
            }
            public static string NotConnected
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Not_Connected"); }
            }
            public static string Pager
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Pager"); }
            }
            public static string PagerIsNotAvailable
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Pager_is_not_available"); }
            }
            public static string PagerIsNotConnected
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Pager_is_not_connected"); }
            }
            public static string PagerScanner
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Pager_Scanner"); }
            }
            public static string PairingWithPager
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Pairing_with_pager"); }
            }
            public static string ReadingPagerConfiguration
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Reading_pager_configuration"); }
            }
            public static string Retry
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Retry"); }
            }
            public static string SavingConfiguration
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Saving_configuration"); }
            }
            public static string Scan
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Scan"); }
            }
            public static string Scanning
            {
                get { return Ioc.Get<ITranslator>().Translate("t_blue_Scanning"); }
            }
        }
        
        public static class Connection
        {
            public static string ApplicationDoesNotHaveServerAccess
            {
                get { return Ioc.Get<ITranslator>().Translate("t_connection_Application_does_not_have_server_access"); }
            }
            public static string ApplicationHasSuccessfullyCreatedConnection
            {
                get { return Ioc.Get<ITranslator>().Translate("t_connection_Application_has_successfully_created_connection"); }
            }
            public static string NoConnection
            {
                get { return Ioc.Get<ITranslator>().Translate("t_connection_NoConnection"); }
            }
            public static string ServerInformation
            {
                get { return Ioc.Get<ITranslator>().Translate("t_connection_Server_information"); }
            }
        }
        
        public static class EmailConfirm
        {
            public static string ComeBackToLogin
            {
                get { return Ioc.Get<ITranslator>().Translate("t_emailConfirm_Come_back_to_Login"); }
            }
            public static string Confirm
            {
                get { return Ioc.Get<ITranslator>().Translate("t_emailConfirm_Confirm"); }
            }
            public static string ConfirmationCode
            {
                get { return Ioc.Get<ITranslator>().Translate("t_emailConfirm_Confirmation_code"); }
            }
            public static string DidntGetConfirmation
            {
                get { return Ioc.Get<ITranslator>().Translate("t_emailConfirm_Didnt_get_confirmation"); }
            }
            public static string EmailConfirmation
            {
                get { return Ioc.Get<ITranslator>().Translate("t_emailConfirm_Email_confirmation"); }
            }
            public static string YouveRegistered
            {
                get { return Ioc.Get<ITranslator>().Translate("t_emailConfirm_Youve_registered"); }
            }
        }
        
        public static class EmailConfirmation
        {
            public static string YouveRegisteredEnterConfirmCode
            {
                get { return Ioc.Get<ITranslator>().Translate("t_EmailConfirmation_Youve_registered_Enter_confirm_code"); }
            }
        }
        
        public static class Feedback
        {
            public static string Alert
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Alert"); }
            }
            public static string AlertMessage
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Alert_Message"); }
            }
            public static string AlertMessages
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Alert_messages"); }
            }
            public static string Confirm
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Confirm"); }
            }
            public static string Decline
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Decline"); }
            }
            public static string FeedbackDetails
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Feedback_Details"); }
            }
            public static string FeedbackOptionsOverviewForMessage
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Feedback_options_overview_for_message"); }
            }
            public static string FeedbackOverview
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Feedback_Overview"); }
            }
            public static string FeedbackString
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Feedback"); }
            }
            public static string MapNavigation
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Map_navigation"); }
            }
            public static string Next
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Next"); }
            }
            public static string NoResponses
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_No_responses"); }
            }
            public static string NotAnswered
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Not_answered"); }
            }
            public static string Overview
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Overview"); }
            }
            public static string Previous
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Previous"); }
            }
            public static string SendingFeedback
            {
                get { return Ioc.Get<ITranslator>().Translate("t_feedback_Sending_feedback"); }
            }
        }
        
        public static class General
        {
            public static string AllGroups
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_All_groups"); }
            }
            public static string Cancel
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Cancel"); }
            }
            public static string Close
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_close"); }
            }
            public static string Fetching
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Fetching"); }
            }
            public static string Hybrid
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Hybrid"); }
            }
            public static string No
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_No"); }
            }
            public static string Ok
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Ok"); }
            }
            public static string Open
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_open"); }
            }
            public static string OutOf
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_out_of"); }
            }
            public static string SentAt
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Sent_at"); }
            }
            public static string Yes
            {
                get { return Ioc.Get<ITranslator>().Translate("t_general_Yes"); }
            }
        }
        
        public static class Home
        {
            public static string AlertMessage
            {
                get { return Ioc.Get<ITranslator>().Translate("t_home_Alert_Message"); }
            }
            public static string NoAlerts
            {
                get { return Ioc.Get<ITranslator>().Translate("t_home_No_alerts"); }
            }
            public static string Overview
            {
                get { return Ioc.Get<ITranslator>().Translate("t_home_Overview"); }
            }
            public static string SelectNewStatus
            {
                get { return Ioc.Get<ITranslator>().Translate("t_home_Select_new_status"); }
            }
            public static string YourCurrentStatusIs
            {
                get { return Ioc.Get<ITranslator>().Translate("t_home_Your_current_status_is"); }
            }
        }
        
        public static class Login
        {
            public static string AuthenticationDataIsEmpty
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Authentication_data_is_empty"); }
            }
            public static string BackToLogin
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Back_to_Login"); }
            }
            public static string EmailWasConfirmed
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_email_was_confirmed"); }
            }
            public static string EnterEmail
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Enter_email"); }
            }
            public static string EnterPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Enter_Password"); }
            }
            public static string ForgotPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Forgot_password"); }
            }
            public static string IncorrectKey
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Incorrect_key"); }
            }
            public static string IncorrectPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Incorrect_password"); }
            }
            public static string KeyIsExpired
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Key_is_expired"); }
            }
            public static string LoggingInSystem
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_logging_in_system"); }
            }
            public static string LoginShouldBeSpecified
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_login_should_be_specified"); }
            }
            public static string LoginString
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Login"); }
            }
            public static string NewPasswordsDoNotMatchOld
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_new_passwords_do_not_match_old"); }
            }
            public static string PasswordWasChanged
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Password_was_changed"); }
            }
            public static string ProcessingPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Processing_password"); }
            }
            public static string Register
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Register"); }
            }
            public static string RegistrationFinishedSuccessfully
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Registration_finished_successfully"); }
            }
            public static string SuccessfullyLogged
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Successfully_logged"); }
            }
            public static string TheOldPasswordIsIncorrect
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_The_old_password_is_incorrect"); }
            }
            public static string TheOldPasswordIsntPresented
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_The_old_password_isnt_presented"); }
            }
            public static string ThereIsntUserInSystem
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_There_isnt_user_in_system"); }
            }
            public static string TheUserIsntRegistered
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_The_user_isnt_registered"); }
            }
            public static string UpdatePassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_Update_password"); }
            }
            public static string UserHasntChanged
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_User_hasnt_changed"); }
            }
            public static string UserHasntConfirmed
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_User_hasnt_confirmed"); }
            }
            public static string UserIsAlreadyRegistered
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_User_is_already_registered"); }
            }
            public static string WeAreChangingPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_we_are_changing_password"); }
            }
            public static string YouNeedToFillAllFields
            {
                get { return Ioc.Get<ITranslator>().Translate("t_login_You_need_to_fill_all_fields"); }
            }
        }
        
        public static class Map
        {
            public static string Team
            {
                get { return Ioc.Get<ITranslator>().Translate("t_map_Team"); }
            }
        }
        
        public static class Menu
        {
            public static string About
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_About"); }
            }
            public static string AlertMessages
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Alert_messages"); }
            }
            public static string Alerts
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Alerts"); }
            }
            public static string Availability
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Availability"); }
            }
            public static string Bluetooth
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Bluetooth"); }
            }
            public static string Feedback
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Feedback"); }
            }
            public static string Home
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Home"); }
            }
            public static string Hybrid
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Hybrid"); }
            }
            public static string Info
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Info"); }
            }
            public static string Main
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Main"); }
            }
            public static string Notifications
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Notifications"); }
            }
            public static string Settings
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Settings"); }
            }
            public static string UnitTests
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_Unit_Tests"); }
            }
            public static string UserInfo
            {
                get { return Ioc.Get<ITranslator>().Translate("t_menu_User_Info"); }
            }
        }
        
        public static class Message
        {
            public static string Alerts
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Alerts"); }
            }
            public static string ApplicationDoesNotHaveServerAccess
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Application_does_not_have_server_access"); }
            }
            public static string ConnectionToServer
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Connection_to_server"); }
            }
            public static string ContactSupport
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Contact_support"); }
            }
            public static string ErrorOnConnectingToServer
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_error_on_connecting_to_server"); }
            }
            public static string FailedToSendLog
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Failed_to_send_log"); }
            }
            public static string GoToAppleStore
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Go_to_Apple_Store"); }
            }
            public static string SomethingWrongHappened
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Something_wrong_happened"); }
            }
            public static string TheApplicationIsOutOfDate
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_The_application_is_out_of_date"); }
            }
            public static string TryToFixIssueAndRepeatLogin
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Try_to_fix_issue_and_repeat_login"); }
            }
            public static string TryToRepeatLogin
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_Try_to_repeat_login"); }
            }
            public static string WeCreatedTemporaryPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_we_created_temporary_password"); }
            }
            public static string YouShouldChangeTemporaryPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_message_You_should_change_temporary_password"); }
            }
        }
        
        public static class Notification
        {
            public static string Notifications
            {
                get { return Ioc.Get<ITranslator>().Translate("t_notification_Notifications"); }
            }
            public static string NotificationString
            {
                get { return Ioc.Get<ITranslator>().Translate("t_notification_Notification"); }
            }
            public static string NotificationText
            {
                get { return Ioc.Get<ITranslator>().Translate("t_notification_Notification_text"); }
            }
        }
        
        public static class PasswordChanging
        {
            public static string ChangePassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_Change_password"); }
            }
            public static string ConfirmationCode
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_Confirmation_code"); }
            }
            public static string ConfirmNewPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_Confirm_new_password"); }
            }
            public static string CurrentPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_Current_password"); }
            }
            public static string EnterConfirmationCode
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_Enter_confirmation_code"); }
            }
            public static string EnterNewPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_Enter_new_password"); }
            }
            public static string NewPassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_New_password"); }
            }
            public static string UpdatePassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_passwordChanging_Update_password"); }
            }
        }
        
        public static class Register
        {
            public static string AlreadyHasAccountRelogin
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Already_has_account_Relogin"); }
            }
            public static string Email
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Email"); }
            }
            public static string EmailIsAlreadyRegistered
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_email_is_already_registered"); }
            }
            public static string FirstName
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_First_name"); }
            }
            public static string LastName
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Last_name"); }
            }
            public static string Login
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_login"); }
            }
            public static string MustBeCorrectEmail
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_must_be_correct_email"); }
            }
            public static string Password
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Password"); }
            }
            public static string PleaseEnter
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Please_enter"); }
            }
            public static string RegisterNewAccount
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Register_new_account"); }
            }
            public static string RegisterString
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Register"); }
            }
            public static string Registration
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_Registration"); }
            }
            public static string WeAreActivating
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_We_are_activating"); }
            }
            public static string WeAreRegistering
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_we_are_registering"); }
            }
            public static string YouShouldGetNewConfirmationEmail
            {
                get { return Ioc.Get<ITranslator>().Translate("t_register_You_should_get_new_confirmation_email"); }
            }
        }
        
        public static class Settings
        {
            public static string Alerts
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Alerts"); }
            }
            public static string AllowTrackMyLocation
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Allow_track_my_location"); }
            }
            public static string Hours
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Hours"); }
            }
            public static string Kilometers
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Kilometers"); }
            }
            public static string Map
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Map"); }
            }
            public static string Miles
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Miles"); }
            }
            public static string SettingsString
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Settings"); }
            }
            public static string ShowHybridAlerts
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Show_Hybrid_Alerts"); }
            }
            public static string TimeWhenAlertIsActual
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Time_when_alert_is_actual"); }
            }
            public static string UnitOfLength
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Unit_of_length"); }
            }
            public static string UnitsOfLength
            {
                get { return Ioc.Get<ITranslator>().Translate("t_settings_Units_of_length"); }
            }
        }
        
        public static class User
        {
            public static string ChangePassword
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Change_password"); }
            }
            public static string Contacts
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Contacts"); }
            }
            public static string Details
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Details"); }
            }
            public static string DeviceID
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Device_ID"); }
            }
            public static string FirstName
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_First_name"); }
            }
            public static string Function
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Function"); }
            }
            public static string LastName
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Last_name"); }
            }
            public static string Login
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Login"); }
            }
            public static string Logout
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Logout"); }
            }
            public static string MainInformation
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Main_information"); }
            }
            public static string Organization
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Organization"); }
            }
            public static string RadioCodes
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Radio_Codes"); }
            }
            public static string Rank
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Rank"); }
            }
            public static string ShowUserProfile
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Show_user_profile"); }
            }
            public static string Status
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_Status"); }
            }
            public static string UserProfile
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_User_profile"); }
            }
            public static string UserString
            {
                get { return Ioc.Get<ITranslator>().Translate("t_user_User"); }
            }
        }
        
    }
    

}
//cur dir is: d:\Work\subwork\git\Poliglot\sandbox\Poliglot.Console\bin\Debug
