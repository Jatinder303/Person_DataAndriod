using Person_DataAndriod.Models;

namespace Person_DataAndriod
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText? obj_UserName, obj_Password, obj_FullName, obj_email;
        Button? obj_submit;
        DatabaseManager Obj_databaseManager;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            obj_UserName = FindViewById<EditText>(Resource.Id.UserName_EditText);
            obj_Password = FindViewById<EditText>(Resource.Id.Password_EditText);
            obj_FullName = FindViewById<EditText>(Resource.Id.FullName_EditText);
            obj_email = FindViewById<EditText>(Resource.Id.Email_EditText);
            obj_submit = FindViewById<Button>(Resource.Id.Submit_button);
            
            string directoryPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string dbPath = Path.Combine(directoryPath, "Person_Data.db");
            Obj_databaseManager = new DatabaseManager(dbPath);

            obj_submit.Click += btnSubmit_Click;

        }
        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            //SignUp signUp = new SignUp(obj_UserName.Text, obj_Password.Text, obj_FullName.Text, obj_email.Text);
            SignUp signUp = new SignUp()
            {
                UserName = obj_UserName.Text,
                Password = obj_Password.Text,
                FullName = obj_FullName.Text,
                Email = obj_email.Text
            };

            Obj_databaseManager.InsertUser(signUp);
            Toast.MakeText(this, "Person Data is inserted successfully", ToastLength.Long).Show();
        }
    }
}