using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Fr.Ganfra.MaterialSpinner;
using Java.Interop;

namespace Nivaes.Materialspinner.Droid
{
    [Activity(Label = "@string/app_name",
        MainLauncher = true,
        Theme = "@style/AppTheme",
        Icon = "@mipmap/ic_launcher")]
    public class MainActivity : AppCompatActivity
    {
        private static string error_msg = "Very very very long error message to get scrolling or multiline animation when the error button is clicked";
        private static string[] items = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6" };

        private ArrayAdapter<string> adapter;

        MaterialSpinner spinner1;
        MaterialSpinner spinner2;
        MaterialSpinner spinner3;
        MaterialSpinner spinner4;
        MaterialSpinner spinner5;
        MaterialSpinner spinner6;
        MaterialSpinner spinner7;

        private bool shown = false;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetContentView(Resource.Layout.activity_main);

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            InitSpinnerHintAndFloatingLabel();
            InitSpinnerOnlyHint();
            InitSpinnerNoHintNoFloatingLabel();
            InitSpinnerMultiline();
            InitSpinnerScrolling();
            InitSpinnerHintAndCustomHintView();
            InitEmptyArray();
        }

        private void InitSpinnerHintAndCustomHintView()
        {
            spinner6 = FindViewById<MaterialSpinner>(Resource.Id.spinner6);
            spinner6.SetAdapter(adapter);
            spinner4.Hint = "Select an item";
        }

        private void InitSpinnerHintAndFloatingLabel()
        {
            spinner1 = FindViewById<MaterialSpinner>(Resource.Id.spinner1);
            spinner1.SetAdapter(adapter);
            spinner1.SetPaddingSafe(0, 0, 0, 0);
        }

        private void InitSpinnerOnlyHint()
        {
            spinner2 = FindViewById<MaterialSpinner>(Resource.Id.spinner2);
        }

        private void InitSpinnerNoHintNoFloatingLabel()
        {
            spinner3 = FindViewById<MaterialSpinner>(Resource.Id.spinner3);
            spinner3.SetAdapter(adapter);
        }

        private void InitSpinnerMultiline()
        {
            spinner4 = FindViewById<MaterialSpinner>(Resource.Id.spinner4);
            spinner4.SetAdapter(adapter);
            spinner4.Hint = "Select an item";
        }

        private void InitSpinnerScrolling()
        {
            spinner5 = FindViewById<MaterialSpinner>(Resource.Id.spinner5);
            spinner5.SetAdapter(adapter);
            spinner5.Hint = "Select an item";
        }

        private void InitEmptyArray()
        {
            string[] emptyArray = { };
            spinner7 = FindViewById<MaterialSpinner>(Resource.Id.spinner7);
            spinner7.SetAdapter(new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, emptyArray));
        }

        [Export("ActivateError")]
        public void ActivateError(View view)
        {
            if (!shown)
            {
                spinner4.Error = error_msg;
                spinner5.Error = error_msg;
            }
            else
            {
                spinner4.Error = null;
                spinner5.Error = null;
            }
            shown = !shown;

        }
    }
}


