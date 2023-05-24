using CommunityToolkit.Maui.Views;
using excemath.Models;

namespace excemath.Views;

/// <summary>
/// 
/// </summary>
public partial class ChangePasswordPopup : Popup
{
	public ChangePasswordPopup()
	{
		InitializeComponent();
	}

    private async void ChangePasswordButton_Tapped(object sender, TappedEventArgs e)
    {
        UserGetRequest currentUser = await User.GetCurrentProfile();
        string nickname = currentUser.Nickname;
        UserUpdateRequest userUpdateRequest = new()
        {
            Password = nickname,
            RightAnswers = currentUser.RightAnswers++,
            WrongAnswers = currentUser.WrongAnswers++
        };

        string result = await User.TryUpdate(nickname, userUpdateRequest);

        IdentitySuccess.Text = result;
    }
}