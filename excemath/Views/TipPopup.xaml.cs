/* excemath - an app for preparing for math exams.
 * Copyright (C) 2023 miu-miu enjoyers

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>. */

using CommunityToolkit.Maui.Views;
using CSharpMath.SkiaSharp;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace excemath.Views;

/// <summary>
/// ����������� ��������� ���� ��� �������.
/// </summary>
public partial class TipPopup : Popup
{
    #region ����

    private readonly string _latex;

    #endregion

    #region ������������

    /// <summary>
    /// �������� ��������� ���� <see cref="TipPopup"/>.
    /// </summary>
    public TipPopup() => InitializeComponent();

    /// <summary>
    /// �������� ��������� ���� <see cref="TipPopup"/> �� ��������� ������� �������, LaTeX-�������� �� ������� LaTeX-�������.
    /// </summary>
    /// <param name="text">����� �������.</param>
    /// <param name="latex">LaTeX-������� �������.</param>
    /// <param name="heightRequest">������ LaTeX-������� �������.</param>
    public TipPopup(string text, string latex, int heightRequest, int leftMargin)
    {
        InitializeComponent();

        TipText.Text = text;
        TipLatexCanvas.HeightRequest = heightRequest;
        TipLatexCanvas.Margin = new Thickness(leftMargin, 0, 0, 0);
        _latex = latex;
    }

    public void TipLatexCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;

        canvas.Clear();

        MathPainter painter = new()
        {
            FontSize = 40,
            LaTeX = _latex
        };

        painter.Draw(canvas);
    }

    #endregion
}