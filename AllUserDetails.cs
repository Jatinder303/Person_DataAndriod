using Android.App;
using Android.Content;
using Org.Apache.Commons.Logging;
using Person_DataAndriod.Models;

namespace Person_DataAndriod;

[Activity(Label = "AllUserDetails", MainLauncher = false)]
public class AllUserDetails : Activity
{
    ListView obj_listview;
    DatabaseManager obj_databaseManager;
    EditText obj_editText;
    List<SignUp> userdetails;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Create your application here
        SetContentView(Resource.Layout.AllUsers);
        obj_listview = FindViewById<ListView>(Resource.Id.AllUser_ListView);
        obj_editText = FindViewById<EditText>(Resource.Id.editText1);

        obj_databaseManager = new DatabaseManager();
        Display();
         
        obj_listview.ItemClick += obj_listview_item_Selected;
        
    }
    protected override void OnResume()
    {
        base.OnResume();

        Display();
    }

    private void Display()
    {
        userdetails = obj_databaseManager.GetUsers();

        ArrayAdapter<string> UserDetails_adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);

        foreach (var item in userdetails)
        {
            //if(item.FullName == obj_editText.Text)
            {
                UserDetails_adapter.Add($"{item.UserName} - {item.FullName} - {item.Email}");
            }

        }
        obj_listview.Adapter = UserDetails_adapter;
    }

    private void obj_listview_item_Selected(object sender, AdapterView.ItemClickEventArgs e)
    {
        SignUp selectedUser = userdetails[e.Position];

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.SetTitle("Options");
        builder.SetMessage("Please select one option");
        builder.SetPositiveButton("Update",(s, a ) =>  UpdateUser(selectedUser));
        builder.SetNegativeButton("Delete", (s, a) =>  DeleteUser(selectedUser));
        // Set the Cancel button with dismiss action
        builder.SetNeutralButton("Cancel", (s, a) => { ((Dialog)s).Dismiss(); });
        builder.Show();
        
    }

    private void UpdateUser(SignUp user)
    {
        Intent updateIntent = new Intent(this, typeof(UpdateUserActivity));
        updateIntent.PutExtra("UserId", user.Id);
        StartActivity(updateIntent);
        
    }

    private void DeleteUser(SignUp user)
    {
        obj_databaseManager.DeleteUser(user.Id);
        Display();
    }

 


}