using Android.App;
using Person_DataAndriod.Models;

namespace Person_DataAndriod;

[Activity(Label = "AllUserDetails", MainLauncher = true)]
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
        obj_listview.ItemClick += obj_listview_item_Selected;

    }

    private void obj_listview_item_Selected(object sender, AdapterView.ItemClickEventArgs e)
    {
        SignUp selectedUser = userdetails[e.Position];

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.SetTitle("Options");
        builder.SetMessage("Please select one option");
        builder.SetPositiveButton("Update",(s, a ) =>  UpdateUser(selectedUser));
        builder.SetNegativeButton("Delete", (s, a) =>  DeleteUser(selectedUser));
      //  builder.SetNeutralButton("Cancel", (s, a) => dialog.cancel());
        builder.Show();
    }

    private void UpdateUser(SignUp user)
    {
        Toast.MakeText(this, "Update function is not yet implemented", ToastLength.Long).Show();
    }

    private void DeleteUser(SignUp user)
    {
        obj_databaseManager.DeleteUser(user.Id);


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

    private void CancleDialog()
    {

    }


}