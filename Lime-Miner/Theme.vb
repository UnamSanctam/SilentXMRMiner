'Credits goes to : Aeonhack, HawkHF, Leumonic and Xertz.
'Edited by Huracan
'last edited by zapptheman (converted to dark theme)

Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

#Region "Functions"

Enum MouseState As Byte
    None = 0
    Over = 1
    Down = 2
    Block = 3
End Enum

#End Region

Module HuraModule

#Region " G"
    Friend G As Graphics, B As Bitmap
#End Region


    Sub New()
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
    End Sub

    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics

    Friend Function MeasureString(text As String, font As Font) As SizeF
        Return TextGraphics.MeasureString(text, font)
    End Function

    Friend Function MeasureString(text As String, font As Font, width As Integer) As SizeF
        Return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic)
    End Function

    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Friend Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Friend Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

    Public Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

End Module



Public Class HuraForm : Inherits ContainerControl
    Enum ColorSchemes
        Dark
    End Enum
    Event ColorSchemeChanged()
    Private _ColorScheme As ColorSchemes
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            RaiseEvent ColorSchemeChanged()
        End Set
    End Property
    Protected Sub OnColorSchemeChanged() Handles Me.ColorSchemeChanged
        Invalidate()
        Select Case ColorScheme
            Case ColorSchemes.Dark
                BackColor = Color.FromArgb(0, 0, 0)
                Font = New Font("Segoe UI", 9.5)
                AccentColor = Color.FromArgb(0, 0, 0)
                ForeColor = Color.Gray
        End Select
    End Sub
#Region " Properties "
    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            OnAccentColorChanged()
        End Set
    End Property
#End Region
#Region " Constructor "
    Sub New()
        MyBase.New()
        DoubleBuffered = True
        Font = New Font("Segoe UI Semilight", 9.75F)
        'AccentColor = Color.FromArgb(150, 0, 150)
        AccentColor = Color.Black
        ColorScheme = ColorSchemes.Dark
        ForeColor = Color.Gray
        BackColor = Color.FromArgb(0, 0, 0)
        MoveHeight = 32
    End Sub
#End Region
#Region " Events "
    Event AccentColorChanged()
#End Region
#Region " Overrides "
    Private MouseP As Point = New Point(0, 0)
    Private Cap As Boolean = False
    Private MoveHeight As Integer
    Private pos As Integer = 0
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
            Cap = True : MouseP = e.Location
        End If
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Cap Then
            Parent.Location = MousePosition - MouseP
        End If
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e) : Cap = False
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Dock = DockStyle.Fill
        Parent.FindForm().FormBorderStyle = FormBorderStyle.None
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As Bitmap = New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        MyBase.OnPaint(e)

        Dim MainRect As New Rectangle(0, 0, Width - 1, Height - 1)

        G.Clear(BackColor)
        G.DrawLine(New Pen(Color.FromArgb(0, 219, 106), 3), New Point(0, 0), New Point(Width, 0))
        G.DrawRectangle(New Pen(Color.FromArgb(0, 219, 106)), MainRect)
        G.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(8, 6, Width - 1, Height - 1), StringFormat.GenericDefault)

        e.Graphics.DrawImage(B, New Point(0, 0))
        G.Dispose() : B.Dispose()
    End Sub
    Protected Sub OnAccentColorChanged() Handles Me.AccentColorChanged
        Invalidate()
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Invalidate()
    End Sub
#End Region

End Class

Public Class HuraControlBox : Inherits Control
    Enum ColorSchemes
        Dark
    End Enum
    Event ColorSchemeChanged()
    Private _ColorScheme As ColorSchemes
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            RaiseEvent ColorSchemeChanged()
        End Set
    End Property
    Protected Sub OnColorSchemeChanged() Handles Me.ColorSchemeChanged
        Invalidate()
        Select Case ColorScheme
            Case ColorSchemes.Dark
                BackColor = Color.Black
                ForeColor = Color.Black
                AccentColor = Color.FromArgb(0, 219, 106)
        End Select
    End Sub
    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            Invalidate()
        End Set
    End Property

    Sub New()
        MyBase.New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        ForeColor = Color.FromArgb(50, 50, 50)
        BackColor = Color.Black
        AccentColor = Color.FromArgb(200, 200, 200)
        ColorScheme = ColorSchemes.Dark
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(100, 25)
    End Sub
    Enum ButtonHover
        Minimize
        Maximize
        Close
        None
    End Enum
    Dim ButtonState As ButtonHover = ButtonHover.None
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim X As Integer = e.Location.X
        Dim Y As Integer = e.Location.Y
        If Y > 0 AndAlso Y < (Height - 2) Then
            If X > 0 AndAlso X < 34 Then
                ButtonState = ButtonHover.Minimize
            ElseIf X > 33 AndAlso X < 65 Then
                ButtonState = ButtonHover.Maximize
            ElseIf X > 64 AndAlso X < Width Then
                ButtonState = ButtonHover.Close
            Else
                ButtonState = ButtonHover.None
            End If
        Else
            ButtonState = ButtonHover.None
        End If
        Invalidate()
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        MyBase.OnPaint(e)

        G.Clear(BackColor)
        Select Case ButtonState
            Case ButtonHover.None
                G.Clear(BackColor)
            Case ButtonHover.Minimize
                G.FillRectangle(New SolidBrush(_AccentColor), New Rectangle(3, 0, 30, Height))
            Case ButtonHover.Maximize
                G.FillRectangle(New SolidBrush(_AccentColor), New Rectangle(34, 0, 30, Height))
            Case ButtonHover.Close
                G.FillRectangle(New SolidBrush(_AccentColor), New Rectangle(65, 0, 35, Height))
        End Select

        Dim ButtonFont As New Font("Marlett", 9.75F)
        'Close
        G.DrawString("r", ButtonFont, New SolidBrush(Color.FromArgb(150, 150, 150)), New Point(Width - 16, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        'Maximize
        Select Case Parent.FindForm().WindowState
            Case FormWindowState.Maximized
                G.DrawString("2", ButtonFont, New SolidBrush(Color.FromArgb(150, 150, 150)), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
            Case FormWindowState.Normal
                G.DrawString("1", ButtonFont, New SolidBrush(Color.FromArgb(150, 150, 150)), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        End Select
        'Minimize
        G.DrawString("0", ButtonFont, New SolidBrush(Color.FromArgb(150, 150, 150)), New Point(20, 7), New StringFormat With {.Alignment = StringAlignment.Center})


        e.Graphics.DrawImage(B, New Point(0, 0))
        G.Dispose() : B.Dispose()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Select Case ButtonState
            Case ButtonHover.Close
                Parent.FindForm().Close()
            Case ButtonHover.Minimize
                Parent.FindForm().WindowState = FormWindowState.Minimized
            Case ButtonHover.Maximize
                If Parent.FindForm().WindowState = FormWindowState.Normal Then
                    Parent.FindForm().WindowState = FormWindowState.Maximized
                Else
                    Parent.FindForm().WindowState = FormWindowState.Normal
                End If

        End Select
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        ButtonState = ButtonHover.None : Invalidate()
    End Sub
End Class

Public Class HuraButton
    Inherits Control

#Region "Declarations"
    Private ReadOnly _Font As New Font("Segoe UI", 9)
    Private _ProgressColour As Color = Color.FromArgb(0, 191, 255)

    Private _BorderColour As Color = Color.FromArgb(0, 219, 106)
    Private _FontColour As Color = Color.FromArgb(150, 150, 150)
    Private _MainColour As Color = Color.Black
    Private _HoverColour As Color = Color.FromArgb(0, 0, 0)
    Private _PressedColour As Color = Color.FromArgb(0, 219, 106)
    Private State As New MouseState
#End Region

#Region "Mouse States"
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Properties"

    <Category("Colours")>
    Public Property ProgressColour As Color
        Get
            Return _ProgressColour
        End Get
        Set(value As Color)
            _ProgressColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _FontColour
        End Get
        Set(value As Color)
            _FontColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _MainColour
        End Get
        Set(value As Color)
            _MainColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverColour As Color
        Get
            Return _HoverColour
        End Get
        Set(value As Color)
            _HoverColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property PressedColour As Color
        Get
            Return _PressedColour
        End Get
        Set(value As Color)
            _PressedColour = value
        End Set
    End Property

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
              ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
              ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(75, 30)
        BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G = e.Graphics
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .InterpolationMode = CType(7, InterpolationMode)
            .Clear(BackColor)
            Select Case State
                Case MouseState.None
                    .FillRectangle(New SolidBrush(_MainColour), New Rectangle(0, 0, Width, Height))
                    .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                    .DrawString(Text, _Font, Brushes.Gray, New Point(CInt(Width / 2), CInt(Height / 2)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Over
                    .FillRectangle(New SolidBrush(_HoverColour), New Rectangle(0, 0, Width, Height))
                    .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(1, 1, Width - 2, Height - 2))
                    .DrawString(Text, _Font, Brushes.Gray, New Point(CInt(Width / 2), CInt(Height / 2)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Down
                    .FillRectangle(New SolidBrush(_PressedColour), New Rectangle(0, 0, Width, Height))
                    .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(1, 1, Width - 2, Height - 2))
                    .DrawString(Text, _Font, Brushes.Gray, New Point(CInt(Width / 2), CInt(Height / 2)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
        End With
    End Sub

#End Region

End Class

Public Class HuraTextBox
    Inherits Control

#Region "Declarations"
    Private State As MouseState = MouseState.None
    Private WithEvents TB As Windows.Forms.TextBox
    Private _BaseColour As Color = Color.Black
    Private _TextColour As Color = Color.FromArgb(150, 150, 150)
    Private _BorderColour As Color = Color.FromArgb(0, 219, 106)
    Private _Style As Styles = Styles.Normal
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _UseSystemPasswordChar As Boolean
    Private _Multiline As Boolean
#End Region

#Region "TextBox Properties"

    Enum Styles
        Normal
    End Enum

    <Category("Options")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub

    Public Property Style As Styles
        Get
            Return _Style
        End Get
        Set(value As Styles)
            _Style = value
        End Set
    End Property

    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
    End Sub


#End Region

#Region "Colour Properties"

    <Category("Colours")>
    Public Property BackgroundColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        TB = New Windows.Forms.TextBox
        TB.Height = 190
        TB.Font = New Font("Segoe UI", 10)
        TB.Text = Text
        TB.BackColor = Color.FromArgb(0, 0, 0)
        TB.ForeColor = Color.FromArgb(150, 150, 150)
        TB.MaxLength = _MaxLength
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 5)
        TB.Width = Width - 35
        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub


    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        Dim GP As GraphicsPath
        Dim Base As New Rectangle(0, 0, Width, Height)
        With g
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            TB.BackColor = Color.FromArgb(0, 0, 0)
            TB.ForeColor = Color.FromArgb(150, 150, 150)
            Select Case _Style
                Case Styles.Normal
                    .FillRectangle(New SolidBrush(Color.FromArgb(0, 0, 0)), New Rectangle(0, 0, Width - 1, Height - 1))
                    .DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(0, 219, 106)), 2), New Rectangle(0, 0, Width, Height))
            End Select
            .InterpolationMode = CType(7, InterpolationMode)
        End With
    End Sub

#End Region

End Class

Class HuraGroupBox
    Inherits ContainerControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.Black
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(Color.Black), mainRect)
        G.DrawRectangle(New Pen(Color.FromArgb(0, 219, 106)), mainRect)
    End Sub
End Class

<DefaultEvent("CheckedChanged")>
Public Class HuraRadioButton
    Inherits Control

#Region "Declarations"
    Private _Checked As Boolean
    Private State As MouseState = MouseState.None
    Private _HoverColour As Color = Color.FromArgb(240, 240, 240)
    Private _CheckedColour As Color = Color.FromArgb(0, 219, 106)
    Private _BorderColour As Color = Color.FromArgb(0, 219, 106)
    Private _BackColour As Color = Color.FromArgb(0, 0, 0)
    Private _TextColour As Color = Color.FromArgb(150, 150, 150)
#End Region

#Region "Colour & Other Properties"

    <Category("Colours")>
    Public Property HighlightColour As Color
        Get
            Return _HoverColour
        End Get
        Set(value As Color)
            _HoverColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BackColour
        End Get
        Set(value As Color)
            _BackColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedColour As Color
        Get
            Return _CheckedColour
        End Get
        Set(value As Color)
            _CheckedColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property

    Event CheckedChanged(ByVal sender As Object)
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub
    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is HuraRadioButton Then
                DirectCast(C, HuraRadioButton).Checked = False
                Invalidate()
            End If
        Next
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 32
    End Sub
#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                   ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Cursor = Cursors.Hand
        Size = New Size(100, 32)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G = e.Graphics
        Dim Base As New Rectangle(1, 1, Height - 2, Height - 2)
        Dim Circle As New Rectangle(6, 6, Height - 12, Height - 12)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(_BackColour)
            .FillEllipse(New SolidBrush(_BackColour), Base)
            .DrawEllipse(New Pen(_BorderColour, 2), Base)
            If Checked Then
                Select Case State
                    Case MouseState.Over
                        .FillEllipse(New SolidBrush(_HoverColour), New Rectangle(2, 2, Height - 4, Height - 4))
                End Select
                .FillEllipse(New SolidBrush(_CheckedColour), Circle)
            Else
                Select Case State
                    Case MouseState.Over
                        .FillEllipse(New SolidBrush(_HoverColour), New Rectangle(2, 2, Height - 4, Height - 4))
                End Select
            End If
            .DrawString(Text, Font, New SolidBrush(_TextColour), New Rectangle(24, 3, Width, Height), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
            .InterpolationMode = CType(7, InterpolationMode)
        End With
    End Sub
#End Region
End Class

<DefaultEvent("CheckedChanged")>
Public Class HuraCheckBox
    Inherits Control

#Region "Declarations"
    Private _Checked As Boolean
    Private State As MouseState = MouseState.None
    Private _CheckedColour As Color = Color.FromArgb(0, 219, 106)
    Private _BorderColour As Color = Color.FromArgb(0, 219, 106)
    Private _BackColour As Color = Color.Black
    Private _TextColour As Color = Color.FromArgb(150, 150, 150)
#End Region

#Region "Colour & Other Properties"

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BackColour
        End Get
        Set(value As Color)
            _BackColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedColour As Color
        Get
            Return _CheckedColour
        End Get
        Set(value As Color)
            _CheckedColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 22
    End Sub
#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                   ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Cursor = Cursors.Hand
        Size = New Size(100, 22)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        Dim Base As New Rectangle(0, 0, 20, 20)
        With g
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(Color.FromArgb(0, 0, 0))
            .FillRectangle(New SolidBrush(_BackColour), Base)
            .DrawRectangle(New Pen(_BorderColour), New Rectangle(1, 1, 18, 18))
            Select Case State
                Case MouseState.Over
                    .FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), Base)
                    .DrawRectangle(New Pen(_BorderColour), New Rectangle(1, 1, 18, 18))
            End Select
            If Checked Then
                Dim P() As Point = {New Point(4, 11), New Point(6, 8), New Point(9, 12), New Point(15, 3), New Point(17, 6), New Point(9, 16)}
                .FillPolygon(New SolidBrush(_CheckedColour), P)
            End If
            .DrawString(Text, Font, New SolidBrush(_TextColour), New Rectangle(24, 1, Width, Height - 2), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
            .InterpolationMode = CType(7, InterpolationMode)
        End With
    End Sub
#End Region

End Class

Public Class HuraComboBox : Inherits ComboBox
#Region " Control Help - Properties & Flicker Control "
    Enum ColorSchemes
        Dark
    End Enum
    Private _ColorScheme As ColorSchemes
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            Invalidate()
        End Set
    End Property

    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            Invalidate()
        End Set
    End Property

    Private _StartIndex As Integer = 0
    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property
    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_AccentColor), e.Bounds)
            Else
                Select Case ColorScheme
                    Case ColorSchemes.Dark
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0, 6, 160, 167)), e.Bounds)
                End Select
            End If
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.Gray, e.Bounds)
            End Select
        Catch
        End Try
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray())
    End Sub

#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(0, 0, 0)
        Size = New Size(189, 24)
        ForeColor = Color.Black
        AccentColor = Color.FromArgb(0, 6, 160, 167)
        ColorScheme = ColorSchemes.Dark
        DropDownStyle = ComboBoxStyle.DropDownList
        Font = New Font("Segoe UI", 9.5)
        StartIndex = 0
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Curve As Integer = 2


        G.SmoothingMode = SmoothingMode.HighQuality


        Select Case ColorScheme
            Case ColorSchemes.Dark
                G.Clear(Color.FromArgb(0, 6, 160, 167))
                G.DrawLine(New Pen(Color.FromArgb(0, 219, 106), 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                G.DrawLine(New Pen(Color.FromArgb(0, 219, 106), 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                G.DrawLine(New Pen(Color.FromArgb(0, 219, 106)), New Point(Width - 14, 15), New Point(Width - 14, 14))

        End Select
        G.DrawRectangle(New Pen(Color.FromArgb(0, 219, 106)), New Rectangle(0, 0, Width - 1, Height - 1))


        Try
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    G.DrawString(Text, Font, Brushes.Gray, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            End Select
        Catch
        End Try

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class

Public Class HuraProgressBar
    Inherits Control

#Region "Declarations"
    Private _ProgressColour As Color = Color.FromArgb(0, 219, 106)
    Private _BorderColour As Color = Color.FromArgb(190, 190, 190)
    Private _BaseColour As Color = Color.FromArgb(0, 0, 0)
    Private _FontColour As Color = Color.FromArgb(50, 50, 50)
    Private _SecondColour As Color = Color.FromArgb(0, 170, 250)
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _TwoColour As Boolean = True
#End Region

#Region "Properties"

    Public Property SecondColour As Color
        Get
            Return _SecondColour
        End Get
        Set(value As Color)
            _SecondColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property TwoColour As Boolean
        Get
            Return _TwoColour
        End Get
        Set(value As Boolean)
            _TwoColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property ProgressColour As Color
        Get
            Return _ProgressColour
        End Get
        Set(value As Color)
            _ProgressColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _FontColour
        End Get
        Set(value As Color)
            _FontColour = value
        End Set
    End Property

#End Region

#Region "Events"

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G = e.Graphics
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Dim ProgVal As Integer = CInt(_Value / _Maximum * Width)
            Select Case Value
                Case 0
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                    .DrawRectangle(New Pen(_BorderColour, 2), Base)
                Case _Maximum
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                    If _TwoColour Then
                        For i = 0 To (Width - 1) * _Maximum / _Value Step 25
                            G.DrawLine(New Pen(New SolidBrush(_SecondColour), 7), New Point(CInt(i), 0), New Point(CInt(i - 15), Height))
                        Next
                        G.ResetClip()
                    Else
                    End If
                    .DrawRectangle(New Pen(_BorderColour, 2), Base)
                Case Else
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                    If _TwoColour Then
                        .SetClip(New Rectangle(0, 0, CInt(Width * _Value / _Maximum - 1), Height - 1))
                        For i = 0 To (Width - 1) * _Maximum / _Value Step 25
                            .DrawLine(New Pen(New SolidBrush(_SecondColour), 7), New Point(CInt(i), 0), New Point(CInt(i - 10), Height))
                        Next
                        .ResetClip()
                    Else
                    End If
                    .DrawRectangle(New Pen(_BorderColour, 2), Base)
            End Select
            .InterpolationMode = CType(7, InterpolationMode)
        End With
    End Sub

#End Region

End Class

Class HuraTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or
                 ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        ItemSize = New Size(0, 30)
        Font = New Font("Segoe UI", 9.5)
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Dim G As Graphics = e.Graphics

        Dim borderPen As New Pen(Color.FromArgb(0, 0, 0))

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim fillRect As New Rectangle(2, ItemSize.Height + 2, Width - 6, Height - ItemSize.Height - 3)

        G.DrawRectangle(borderPen, fillRect)

        Dim FontColor As New Color

        For i = 0 To TabCount - 1

            Dim mainRect As Rectangle = GetTabRect(i)

            If i = SelectedIndex Then

                G.FillRectangle(New SolidBrush(Color.FromArgb(0, 0, 0)), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                G.DrawLine(New Pen(Color.FromArgb(0, 219, 106)), New Point(mainRect.X, mainRect.Y + 25), New Point(mainRect.X + mainRect.Width - 0, mainRect.Y + 25))

                FontColor = Color.FromArgb(150, 150, 150)

            Else

                G.FillRectangle(New SolidBrush(Color.FromArgb(0, 0, 0)), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                G.DrawLine(New Pen(Color.FromArgb(200, 200, 200)), New Point(mainRect.X, mainRect.Y + 25), New Point(mainRect.X + mainRect.Width - 0, mainRect.Y + 25))
                FontColor = Color.FromArgb(180, 180, 180)

            End If

            Dim titleX As Integer = (mainRect.Location.X + mainRect.Width / 2) - (G.MeasureString(TabPages(i).Text, Font).Width / 2)
            Dim titleY As Integer = (mainRect.Location.Y + mainRect.Height / 2) - (G.MeasureString(TabPages(i).Text, Font).Height / 2)
            G.DrawString(TabPages(i).Text, Font, New SolidBrush(FontColor), New Point(titleX, titleY))

            Try : TabPages(i).BackColor = Color.FromArgb(0, 0, 0) : Catch : End Try

        Next

    End Sub

End Class

Class HuraAlertBox
    Inherits Control

    Private exitLocation As Point
    Private overExit As Boolean

    Enum Style
        Simple
        Success
        Notice
        Warning
        Informations
    End Enum

    Private _alertStyle As Style
    Public Property AlertStyle As Style
        Get
            Return _alertStyle
        End Get
        Set(ByVal value As Style)
            _alertStyle = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Font = New Font("Verdana", 8)
        Size = New Size(200, 40)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim borderColor, innerColor, textColor As Color
        Select Case _alertStyle
            Case Style.Simple
                borderColor = Color.FromArgb(0, 219, 106)
                innerColor = Color.White
                textColor = Color.FromArgb(150, 150, 150)
            Case Style.Success
                borderColor = Color.FromArgb(105, 130, 124)
                innerColor = Color.FromArgb(60, 105, 79)
                textColor = Color.FromArgb(110, 150, 129)
            Case Style.Notice
                borderColor = Color.FromArgb(115, 136, 139)
                innerColor = Color.FromArgb(110, 131, 134)
                textColor = Color.FromArgb(97, 185, 186)
            Case Style.Warning
                borderColor = Color.FromArgb(155, 126, 126)
                innerColor = Color.FromArgb(150, 121, 121)
                textColor = Color.FromArgb(254, 142, 122)
            Case Style.Informations
                borderColor = Color.FromArgb(165, 165, 116)
                innerColor = Color.FromArgb(160, 160, 111)
                textColor = Color.FromArgb(254, 224, 122)
        End Select

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(innerColor), mainRect)
        G.DrawRectangle(New Pen(borderColor), mainRect)

        Dim styleText As String = Nothing

        Select Case _alertStyle

        End Select

        Dim styleFont As New Font(Font.FontFamily, Font.Size, FontStyle.Bold)
        Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Text, Font).Height / 2)
        G.DrawString(styleText, styleFont, New SolidBrush(textColor), New Point(10, textY))
        G.DrawString(Text, Font, New SolidBrush(textColor), New Point(10 + G.MeasureString(styleText, styleFont).Width + 4, textY))

        Dim exitFont As New Font("Marlett", 6)
        Dim exitY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString("r", exitFont).Height / 2) + 1
        exitLocation = New Point(Width - 26, exitY - 3)
        G.DrawString("r", exitFont, New SolidBrush(textColor), New Point(Width - 23, exitY))

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If e.X >= Width - 26 AndAlso e.X <= Width - 12 AndAlso e.Y > exitLocation.Y AndAlso e.Y < exitLocation.Y + 12 Then
            If Cursor <> Cursors.Hand Then Cursor = Cursors.Hand
            overExit = True
        Else
            If Cursor <> Cursors.Arrow Then Cursor = Cursors.Arrow
            overExit = False
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If overExit Then Me.Visible = False
    End Sub
End Class