using excemath.Models;

namespace excemath.Views;

/// <summary>
/// ����������� ������� �������.
/// </summary>
public partial class ProfilePage : ContentPage
{
    #region ������������

    /// <summary>
    /// �������� ������� <see cref="ProfilePage"/>.
    /// </summary>
    public ProfilePage()
    {
        InitializeComponent();

        
    }

    #endregion

    #region ��������� ����

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        UserLevel.Text = await User.GetCurrentLevelText();
    }

    #endregion

    #region ������

    #endregion
}