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

        UserLevel.Text = User.GetCurrentLevelText();
    }

    #endregion

    #region ��������� ����

    protected override void OnAppearing()
    {
        base.OnAppearing();


    }

    #endregion

    #region ������

    #endregion
}