﻿using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile;

using Xamarin.Forms;

namespace Contoso.Forms.Test
{
    public partial class ToggleStatesPage : ContentPage
    {
        public ToggleStatesPage()
        {
            InitializeComponent();
            UpdateEnabledStateLabels();
        }

        void EnableMobileCenter(object sender, System.EventArgs e)
        {
            MobileCenter.SetEnabled(true);
            UpdateEnabledStateLabels();
        }

        void EnableCrashes(object sender, System.EventArgs e)
        {
            Crashes.SetEnabled(true);
            UpdateEnabledStateLabels();
        }

        void EnableAnalytics(object sender, System.EventArgs e)
        {
            Analytics.SetEnabled(true);
            UpdateEnabledStateLabels();
        }

        void DisableMobileCenter(object sender, System.EventArgs e)
        {
            MobileCenter.SetEnabled(false);
            UpdateEnabledStateLabels();
        }

        void DisableCrashes(object sender, System.EventArgs e)
        {
            Crashes.SetEnabled(false);
            UpdateEnabledStateLabels();
        }

        void DisableAnalytics(object sender, System.EventArgs e)
        {
            Analytics.SetEnabled(false);
            UpdateEnabledStateLabels();
        }

        void UpdateEnabledStateLabels()
        {
            ForceLayout();
            UpdateMobileCenterLabel();
            UpdateCrashesLabel();
            UpdateAnalyticsLabel();
            ForceLayout();
        }

        void UpdateCrashesLabel()
        {
            if (CrashesEnabledLabel != null)
            {
                Crashes.IsEnabledAsync().ContinueWith(
                    enabled =>
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            CrashesEnabledLabel.Text = enabled.Result ? TestStrings.CrashesEnabledText : TestStrings.CrashesDisabledText;
                        });
                    }
                );
            }
        }

        void UpdateAnalyticsLabel()
        {
            if (AnalyticsEnabledLabel != null)
            {
                Analytics.IsEnabledAsync().ContinueWith(
                    enabled =>
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            AnalyticsEnabledLabel.Text = enabled.Result ? TestStrings.AnalyticsEnabledText : TestStrings.AnalyticsDisabledText;
                        });
                    }
                );
            }
        }

        void UpdateMobileCenterLabel()
        {
            if (MobileCenterEnabledLabel != null)
            {
                MobileCenter.IsEnabledAsync().ContinueWith(
                    enabled =>
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            MobileCenterEnabledLabel.Text = enabled.Result ? TestStrings.MobileCenterEnabledText : TestStrings.MobileCenterDisabledText;
                        });
                    }
                );
            }
        }

        void DismissPage(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
