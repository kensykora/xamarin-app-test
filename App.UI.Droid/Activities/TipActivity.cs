using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;

using App.Core.ViewModels;

using MvvmCross.Droid.Views;

namespace App.UI.Droid.Activities
{
    [Activity(Label = "Tip", MainLauncher = true)]
    public class TipActivity : MvxActivity<TipViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Tip);
        }
    }
}