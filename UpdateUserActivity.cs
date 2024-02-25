using Android.Content;
using Person_DataAndriod.Models;
namespace Person_DataAndriod;

[Activity(Label = "UpdateUserActivity")]
public class UpdateUserActivity : Activity
{
    private EditText _userName, _password, _email, _fullname;
    private Button _updateButton;
    private int _userId;
    DatabaseManager _dbManager;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Create your application here
        SetContentView(Resource.Layout.UpdateUser);

        _userName = FindViewById<EditText>(Resource.Id.UserName_EditText);
        _password = FindViewById<EditText>(Resource.Id.Password_EditText);
        _fullname = FindViewById<EditText>(Resource.Id.FullName_EditText);
        _email = FindViewById<EditText>(Resource.Id.Email_EditText);

        _updateButton = FindViewById<Button>(Resource.Id.Update_button);

        _dbManager = new DatabaseManager();

        _userId = Intent.GetIntExtra("UserId", 0);

        SignUp obj_SignUp = _dbManager.GetUserId(_userId);

        if (obj_SignUp != null)
        {
            _userName.Text = obj_SignUp.UserName;
            _password.Text = obj_SignUp.Password;   
            _fullname.Text = obj_SignUp.FullName;
            _email.Text = obj_SignUp.Email;
        }
        else
        {
            Toast.MakeText(this, "Person Data Not Found", ToastLength.Long).Show();
        }

        _updateButton.Click += _updateButton_Click;
    }

    private void _updateButton_Click(object? sender, EventArgs e)
    {
        //SignUp signUp = new SignUp(obj_UserName.Text, obj_Password.Text, obj_FullName.Text, obj_email.Text);
        SignUp UpdateUserData = new SignUp()
        {
            Id = _userId,
            UserName = _userName.Text,
            Password = _password.Text,
            FullName = _fullname.Text,
            Email = _email.Text
        };

        _dbManager.UpdateUser(UpdateUserData);
        Toast.MakeText(this, "Person Data is updated successfully", ToastLength.Long).Show();

        Finish();

    }
}