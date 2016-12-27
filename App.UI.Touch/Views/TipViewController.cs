using System;

using App.Core.ViewModels;

using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;

using UIKit;

namespace App.UI.Touch.Views
{
    public partial class TipViewController : MvxViewController<TipViewModel>
    {
        public TipViewController() : base("TipViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.CreateBinding(TipLabel).To((TipViewModel vm) => vm.Tip).Apply();
            this.CreateBinding(SubTotalTextField).To((TipViewModel vm) => vm.Subtotal).Apply();
            this.CreateBinding(GenerositySlider).To((TipViewModel vm) => vm.Generosity).Apply();
        }
    }
}