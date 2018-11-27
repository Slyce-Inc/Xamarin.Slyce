using SlyceSDK;
using SlyceSDK.Exception;
using IT.Slyce.Sdk.Helpers;
using IT.Slyce.Sdk.Labs;
using Android.Support.V4.App;
using System.Collections.Generic;
using IT.Slyce.Sdk.UI;


namespace Xamarin.Android.Slyce.Sample
{
    public class SlyceFragmentLauncher : Java.Lang.Object, ISlyceCompletionHandler
    {
        private FragmentActivity activity;

        public SlyceFragmentLauncher(FragmentActivity activity)
        {
            this.activity = activity;
        }


        public void OnCompletion(SlyceError error)
        {

            if (error != null)
            {
                System.Diagnostics.Debug.WriteLine("Error opening Slyce: " + error.LocalizedMessage);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("Slyce.GetInstance(this).DefaultSession = " + SlyceSDK.Slyce.GetInstance(activity).DefaultSession.ToString());

                //SlyceUI.FragmentLauncher fragmentLauncher = new SlyceUI.FragmentLauncher(SlyceSDK.Slyce.GetInstance(activity), SlyceActivityMode.Picker, Resource.Id.root);


                UIDelegate uIDelegate = new UIDelegate();


                //Dictionary<string, Java.Lang.Object> options = new Dictionary<string, Java.Lang.Object>();

                SlyceXamarinUIFactory factory = new SlyceXamarinUIFactory(SlyceSDK.Slyce.GetInstance(activity), SlyceActivityMode.Picker);
                Fragment slyceFragment = (Fragment)factory.CreateSlyceFragment(null, new CloseDelegate(), uIDelegate);

                
                //FragmentTransaction ft = activity.SupportFragmentManager.BeginTransaction();
                //ft.Replace(Resource.Id.fragment_container, slyceFragment);
                //ft.Commit();







                //activity.StartActivity((Intent)factory.CreateIntentForSlyceActivity(activity, null));

                

                //SlyceUI.ActivityLauncher activityLauncher = new SlyceUI.ActivityLauncher(SlyceSDK.Slyce.GetInstance(activity), SlyceActivityMode.Picker);
                //activityLauncher.Launch(activity);
            }
        }




        class UIDelegate : Java.Lang.Object, ISlyceUIDelegate
        {

            public void DidOpenSession(ISlyceSession session)
            {

            }


            public void DidCreateList(SlyceListDescriptor listDescriptor)
            {

            }


            public bool ShouldDisplayDefaultItemDetailLayerForItem(SlyceItemDescriptor descriptor)
            {
                System.Console.WriteLine("SHOULD DISPLAY ITEM DETAIL");
                // Present your custom item detail here or change return value to true
                return false;
            }


            public bool ShouldDisplayDefaultListLayerForItems(IList<SlyceItemDescriptor> descriptorsList)
            {
                System.Console.WriteLine("SHOULD DISPLAY ITEMS LIST DETAIL");
                // Present yout custom items list here or change return value to true
                return false;
            }
        }


        class CloseDelegate : Java.Lang.Object, ISlyceFragmentCloseDelegate
        {


            public void CloseSlyceFragment()
            {

            }

        }
    }
}
