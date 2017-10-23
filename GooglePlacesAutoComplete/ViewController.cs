using System;

using UIKit;
using Google.Maps;
using Foundation;

namespace GooglePlacesAutoComplete
{
    public partial class ViewController : UIViewController, IAutocompleteViewControllerDelegate
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void OnGooglePlacesClick(UIButton sender)
        {
            var autoCompleteVC = new AutocompleteViewController();
            autoCompleteVC.Delegate = this;

            this.PresentViewController(autoCompleteVC, false, null);
        }

        public void DidAutocomplete(AutocompleteViewController viewController, Place place)
        {
            Debug.Print(place.Name);
            Debug.Print(place.FormattedAddress);
            this.DismissViewController(false, null);
        }

        public void DidFailAutocomplete(AutocompleteViewController viewController, NSError error)
        {

        }

        public void WasCancelled(AutocompleteViewController viewController)
        {
            this.DismissViewController(false, null);
        }
    }
}
