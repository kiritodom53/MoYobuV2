﻿using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.Backdrop;
using Syncfusion.XForms.iOS.EffectsView;
using UIKit;

namespace MoYobuV2.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            new Syncfusion.SfNavigationDrawer.XForms.iOS.SfNavigationDrawerRenderer();

            global::Xamarin.Forms.Forms.Init();

            Syncfusion.XForms.iOS.TabView.SfTabViewRenderer.Init();
            Syncfusion.XForms.iOS.Expander.SfExpanderRenderer.Init(); 
            SfListViewRenderer.Init();
            SfEffectsViewRenderer.Init(); //Initialize only when effects view is added to Listview.
            Syncfusion.XForms.iOS.ComboBox.SfComboBoxRenderer.Init();
            SfBackdropPageRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfChipRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfChipGroupRenderer.Init();

            LoadApplication(new App());
            
            Syncfusion.XForms.iOS.Buttons.SfCheckBoxRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}