using excemath.Models;

namespace excemath.Views;

/// <summary>
/// ����������� ������� �������.
/// </summary>
public partial class ProfilePage : ContentPage
{
    #region ����

    UserGetRequest currentUser;

    #endregion

    #region ������������

    /// <summary>
    /// �������� ������� <see cref="ProfilePage"/>.
    /// </summary>
    public ProfilePage() => InitializeComponent();    

    #endregion

    #region ��������� ����

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        currentUser = await User.GetCurrentProfile();

        UserLevel.Text = User.GetCurrentLevelText(currentUser, out double rating);
        Rating.Text = rating.ToString() + " %";        
        RightAnswers.Text = currentUser.RightAnswers.ToString();
        WrongAnswers.Text = currentUser.WrongAnswers.ToString();
    }

    #endregion

    #region ������

    #endregion
}