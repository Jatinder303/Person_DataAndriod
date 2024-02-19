using Person_DataAndriod.Models;

namespace Person_DataAndriod;

[Activity(Label = "AllUserDetails", MainLauncher = false)]
public class AllUserDetails : Activity
{
    ListView obj_listview;
    DatabaseManager obj_databaseManager;
    EditText obj_editText;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Create your application here
        SetContentView(Resource.Layout.AllUsers);
        obj_listview = FindViewById<ListView>(Resource.Id.AllUser_ListView);
        obj_editText = FindViewById<EditText>(Resource.Id.editText1);

        obj_databaseManager = new DatabaseManager();

        List<SignUp> userdetails = obj_databaseManager.GetUsers();

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
}