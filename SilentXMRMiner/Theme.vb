Imports System.Drawing.Drawing2D
Imports System.ComponentModel

'PLEASE LEAVE CREDITS IN SOURCE, DO NOT REDISTRIBUTE!

'--------------------- [ Theme ] --------------------
'Creator: Mephobia
'Contact: Mephobia.HF (Skype)
'Created: 4.20.2013
'Changed: 4.20.2013
'-------------------- [ /Theme ] ---------------------

'PLEASE LEAVE CREDITS IN SOURCE, DO NOT REDISTRIBUTE!

Enum MouseState As Byte
    None = 0
    Over = 1
    Down = 2
    Block = 3
End Enum
Module Draw
    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Public Sub InnerGlow(ByVal G As Graphics, ByVal Rectangle As Rectangle, ByVal Colors As Color())
        Dim SubtractTwo As Integer = 1
        Dim AddOne As Integer = 0
        For Each c In Colors
            G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(c.R, c.B, c.G))), Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo)
            SubtractTwo += 2
            AddOne += 1
        Next
    End Sub
    Public Sub InnerGlowRounded(ByVal G As Graphics, ByVal Rectangle As Rectangle, ByVal Degree As Integer, ByVal Colors As Color())
        Dim SubtractTwo As Integer = 1
        Dim AddOne As Integer = 0
        For Each c In Colors
            G.DrawPath(New Pen(New SolidBrush(Color.FromArgb(c.R, c.B, c.G))), Draw.RoundRect(Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo, Degree))
            SubtractTwo += 2
            AddOne += 1
        Next
    End Sub
End Module
Public Class MephTheme : Inherits ContainerControl

    Private _subHeader As String
    Public Property SubHeader() As String
        Get
            Return _subHeader
        End Get
        Set(ByVal value As String)
            _subHeader = value
            Invalidate()
        End Set
    End Property

    Private _accentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _accentColor
        End Get
        Set(ByVal value As Color)
            _accentColor = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.FromArgb(28, 28, 28)
        _subHeader = "Insert Sub Header"
        _accentColor = Color.DarkRed
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics

        Dim mainRect As New Rectangle(0, 0, Width, Height)

        MyBase.OnPaint(e)


        G.Clear(Color.Fuchsia)
        'G.SetClip(Draw.RoundRect(New Rectangle(0, 0, Width, Height), 9))

        Dim c As Color() = New Color() {Color.FromArgb(10, 10, 10), Color.FromArgb(45, 45, 45), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), Color.FromArgb(46, 46, 46), Color.FromArgb(47, 47, 47), Color.FromArgb(48, 48, 48), Color.FromArgb(49, 49, 49), Color.FromArgb(50, 50, 50)}
        G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), mainRect)
        InnerGlow(G, mainRect, c)

        Dim c2 As Color() = New Color() {Color.FromArgb(5, 5, 5), Color.FromArgb(40, 40, 40), Color.FromArgb(41, 41, 41), Color.FromArgb(42, 42, 42), Color.FromArgb(43, 43, 43), Color.FromArgb(44, 44, 44), Color.FromArgb(45, 45, 45)}
        G.FillRectangle(New SolidBrush(Color.FromArgb(45, 45, 45)), New Rectangle(0, 35, Width, 23))
        InnerGlow(G, New Rectangle(0, 35, Width, 23), c2)

        Dim accentGradient As New LinearGradientBrush(New Rectangle(0, 36, 11, 21), _accentColor, Color.FromArgb(IIf(_accentColor.R >= 10, _accentColor.R - 10, _accentColor.R + 10), IIf(_accentColor.G >= 10, _accentColor.G - 10, _accentColor.G + 10), IIf(_accentColor.B >= 10, _accentColor.B - 10, _accentColor.B + 10)), 90S)
        G.FillRectangle(accentGradient, New Rectangle(0, 36, 11, 21))
        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(5, 5, 5))), New Rectangle(0, 35, 11, 22))
        G.FillRectangle(accentGradient, New Rectangle(Width - 12, 36, 11, 21))
        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(5, 5, 5))), New Rectangle(Width - 12, 35, 11, 22))

        Dim gloss As New LinearGradientBrush(New Rectangle(1, 0, Width - 1, 35 / 2), Color.FromArgb(255, Color.FromArgb(90, 90, 90)), Color.FromArgb(255, 71, 71, 71), 90S)
        G.FillRectangle(gloss, New Rectangle(1, 0, Width - 2, 35 / 2))

        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(5, 5, 5))), 0, 0, Width, 0)
        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), 1, 1, Width - 2, 1)
        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(85, 85, 85))), 1, 34, Width - 2, 34)
        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(45, 45, 45))), 1, 58, Width - 2, 58)

        Dim drawFont As New Font("Verdana", 10, FontStyle.Regular)
        G.DrawString(Text, drawFont, New SolidBrush(Color.FromArgb(225, 225, 225)), New Rectangle(0, 0, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

        Dim subFont As New Font("Verdana", 8, FontStyle.Regular)
        G.DrawString(_subHeader, subFont, New SolidBrush(Color.FromArgb(225, 225, 225)), New Rectangle(0, 35, Width, 23), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

        Dim controlFont As New Font("Marlett", 10, FontStyle.Regular)
        Select Case State
            Case MouseState.None
                G.DrawString("r", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-4, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                G.DrawString("1", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-21, -5, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                G.DrawString("0", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-38, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
            Case MouseState.Over
                If X > Width - 18 And X < Width - 10 And Y < 18 And Y > 8 Then
                    G.DrawString("r", controlFont, New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(-4, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("1", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-21, -5, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("0", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-38, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                ElseIf X > Width - 36 And X < Width - 25 And Y < 18 And Y > 8 Then
                    G.DrawString("r", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-4, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("1", controlFont, New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(-21, -5, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("0", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-38, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                ElseIf X > Width - 52 And X < Width - 44 And Y < 18 And Y > 8 Then
                    G.DrawString("r", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-4, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("1", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-21, -5, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("0", controlFont, New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(-38, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                Else
                    G.DrawString("r", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-4, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("1", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-21, -5, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                    G.DrawString("0", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-38, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                End If
            Case MouseState.Down
                G.DrawString("r", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-4, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                G.DrawString("1", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-21, -5, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
                G.DrawString("0", controlFont, New SolidBrush(Color.FromArgb(178, 178, 178)), New Rectangle(-38, -6, Width, 35), New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        End Select

    End Sub
    Private MouseP As Point = New Point(0, 0)
    Private Cap As Boolean = False
    Private MoveHeight% = 35 : Private pos% = 0
    Dim State As MouseState = MouseState.None
    Dim X As Integer
    Dim Y As Integer
    Dim MinBtn As New Rectangle(0, 0, 32, 25)
    Dim CloseBtn As New Rectangle(33, 0, 65, 25)
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) And X < Width - 53 Then
            Cap = True
            MouseP = e.Location
        Else
            If X > Width - 18 And X < Width - 8 And Y < 18 And Y > 8 Then
                FindForm.Close()
            ElseIf X > Width - 36 And X < Width - 25 And Y < 18 And Y > 8 Then
                If FindForm.WindowState = FormWindowState.Maximized Then
                    FindForm.WindowState = FormWindowState.Normal
                Else
                End If
            ElseIf X > Width - 52 And X < Width - 44 And Y < 18 And Y > 8 Then
                FindForm.WindowState = FormWindowState.Minimized
            End If
        End If
        State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e) : Cap = False
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Cap Then
            Parent.Location = MousePosition - MouseP
        End If
        X = e.Location.X
        Y = e.Location.Y
        Invalidate()
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Me.ParentForm.FormBorderStyle = FormBorderStyle.None
        Me.ParentForm.TransparencyKey = Color.Fuchsia
        Dock = DockStyle.Fill
        Anchor = AnchorStyles.None
        Font = New Font(Font.Name, 8.25F * 100.0F / CreateGraphics().DpiY, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont)
    End Sub
End Class
Public Class MephButton : Inherits Control
#Region " MouseStates "
    Dim State As MouseState = MouseState.None
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
#End Region

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        ForeColor = Color.FromArgb(205, 205, 205)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim ClientRectangle As New Rectangle(0, 0, Width - 1, Height - 1)

        MyBase.OnPaint(e)

        G.Clear(BackColor)
        Dim drawFont As New Font("Verdana", 8, FontStyle.Regular)

        G.SmoothingMode = SmoothingMode.HighQuality

        G.FillPath(New SolidBrush(Color.FromArgb(40, 40, 40)), Draw.RoundRect(ClientRectangle, 3))
        G.DrawPath(New Pen(New SolidBrush(Color.FromArgb(15, 15, 15))), Draw.RoundRect(ClientRectangle, 3))
        G.DrawPath(New Pen(New SolidBrush(Color.FromArgb(55, 55, 55))), Draw.RoundRect(New Rectangle(1, 1, Width - 3, Height - 3), 3))

        Select Case State
            Case MouseState.None
                G.DrawString(Text, drawFont, Brushes.Silver, New Rectangle(0, 0, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Case MouseState.Over
                G.DrawString(Text, drawFont, Brushes.White, New Rectangle(0, 0, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Case MouseState.Down
                G.DrawString(Text, drawFont, Brushes.Gray, New Rectangle(0, 0, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Select

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
Public Class MephGroupBox : Inherits ContainerControl

    Enum HeaderLine
        Enabled
        Disabled
    End Enum
    Private _HeaderLine As HeaderLine
    Public Property Header_Line() As HeaderLine
        Get
            Return _HeaderLine
        End Get
        Set(ByVal value As HeaderLine)
            _HeaderLine = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        ForeColor = Color.FromArgb(205, 205, 205)
        Size = New Size(174, 115)
        _HeaderLine = HeaderLine.Enabled
        DoubleBuffered = True
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim ClientRectangle As New Rectangle(0, 0, Width - 1, Height - 1)


        MyBase.OnPaint(e)

        G.Clear(BackColor)
        Dim drawFont As New Font("Verdana", 8, FontStyle.Regular)

        G.SmoothingMode = SmoothingMode.HighQuality

        Dim c As Color() = New Color() {Color.FromArgb(20, 20, 20), Color.FromArgb(45, 45, 45), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), Color.FromArgb(46, 46, 46), Color.FromArgb(47, 47, 47), Color.FromArgb(48, 48, 48), Color.FromArgb(49, 49, 49), Color.FromArgb(50, 50, 50)}
        G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), ClientRectangle)
        Draw.InnerGlow(G, ClientRectangle, c)

        Select Case _HeaderLine
            Case HeaderLine.Enabled
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(45, 45, 45))), 16, 29, Width - 17, 29)
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(20, 20, 20))), 15, 30, Width - 16, 30)
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(45, 45, 45))), 16, 31, Width - 17, 31)
            Case HeaderLine.Disabled
        End Select

        G.DrawString(Text, drawFont, Brushes.Silver, New Rectangle(0, 3, Width - 1, 27), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})


        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
<DefaultEvent("CheckedChanged")> Public Class MephToggleSwitch : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Private State As MouseState = MouseState.None
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
    Private _Checked As Boolean
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Height = 24
        Width = 50
    End Sub
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub
    Event CheckedChanged(ByVal sender As Object)
#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.OptimizedDoubleBuffer, True)
        BackColor = Color.Transparent
        ForeColor = Color.Black
        Size = New Size(50, 24)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim onoffRect As New Rectangle(0, 0, Width - 1, Height - 1)

        G.SmoothingMode = SmoothingMode.HighQuality
        G.CompositingQuality = CompositingQuality.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        G.Clear(Color.Transparent)

        Dim bodyGrad As New LinearGradientBrush(onoffRect, Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), 90S)
        G.FillPath(bodyGrad, Draw.RoundRect(onoffRect, 4))
        G.DrawPath(New Pen(Color.FromArgb(15, 15, 15)), Draw.RoundRect(onoffRect, 4))
        G.DrawPath(New Pen(Color.FromArgb(50, 50, 50)), Draw.RoundRect(New Rectangle(1, 1, Width - 3, Height - 3), 4))

        If Checked Then
            G.FillPath(New SolidBrush(Color.FromArgb(80, Color.Green)), Draw.RoundRect(New Rectangle(4, 2, 25, Height - 5), 4))
            G.FillPath(New SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(New Rectangle(2, 2, 25, Height - 5), 4))
            G.DrawPath(New Pen(New SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(New Rectangle(2, 2, 25, Height - 5), 4))
            Select Case State
                Case MouseState.None
                    G.DrawString("On", New Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, New Point(16, Height - 12), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Over
                    G.DrawString("On", New Font("Tahoma", 8, FontStyle.Regular), Brushes.White, New Point(16, Height - 12), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Down
                    G.DrawString("On", New Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, New Point(16, Height - 12), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
        Else
            G.FillPath(New SolidBrush(Color.FromArgb(60, Color.Red)), Draw.RoundRect(New Rectangle((Width / 2) - 7, 2, Width - 25, Height - 5), 4))
            G.FillPath(New SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(New Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4))
            G.DrawPath(New Pen(New SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(New Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4))
            Select Case State
                Case MouseState.None
                    G.DrawString("Off", New Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, New Point(34, Height - 11), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Over
                    G.DrawString("Off", New Font("Tahoma", 8, FontStyle.Regular), Brushes.White, New Point(34, Height - 11), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case MouseState.Down
                    G.DrawString("Off", New Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, New Point(34, Height - 11), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
        End If

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
Public Class MephTextBox : Inherits Control
    Dim WithEvents txtbox As New TextBox

#Region " Control Help - Properties & Flicker Control "
    Private _passmask As Boolean = False
    Public Shadows Property UseSystemPasswordChar() As Boolean
        Get
            Return _passmask
        End Get
        Set(ByVal v As Boolean)
            txtbox.UseSystemPasswordChar = UseSystemPasswordChar
            _passmask = v
            Invalidate()
        End Set
    End Property
    Private _maxchars As Integer = 32767
    Public Shadows Property MaxLength() As Integer
        Get
            Return _maxchars
        End Get
        Set(ByVal v As Integer)
            _maxchars = v
            txtbox.MaxLength = MaxLength
            Invalidate()
        End Set
    End Property
    Private _align As HorizontalAlignment
    Public Shadows Property TextAlignment() As HorizontalAlignment
        Get
            Return _align
        End Get
        Set(ByVal v As HorizontalAlignment)
            _align = v
            Invalidate()
        End Set
    End Property
    Private _multiline As Boolean = False
    Public Shadows Property MultiLine() As Boolean
        Get
            Return _multiline
        End Get
        Set(ByVal value As Boolean)
            _multiline = value
            Invalidate()
        End Set
    End Property
    Private _wordwrap As Boolean = False
    Public Shadows Property WordWrap() As Boolean
        Get
            Return _wordwrap
        End Get
        Set(ByVal value As Boolean)
            _wordwrap = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
    Protected Overrides Sub OnBackColorChanged(ByVal e As System.EventArgs)
        MyBase.OnBackColorChanged(e)
        txtbox.BackColor = BackColor
        Invalidate()
    End Sub
    Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
        MyBase.OnForeColorChanged(e)
        txtbox.ForeColor = ForeColor
        Invalidate()
    End Sub
    Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
        MyBase.OnFontChanged(e)
        txtbox.Font = Font
    End Sub
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnGotFocus(e)
        txtbox.Focus()
    End Sub
    Sub TextChngTxtBox() Handles txtbox.TextChanged
        Text = txtbox.Text
    End Sub
    Sub TextChng() Handles MyBase.TextChanged
        txtbox.Text = Text
    End Sub
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        If MultiLine = False Then
            Height = 24
        End If
    End Sub
    Sub NewTextBox()
        With txtbox
            .Multiline = MultiLine
            .BackColor = Color.FromArgb(50, 50, 50)
            .ForeColor = ForeColor
            .Text = String.Empty
            .TextAlign = HorizontalAlignment.Center
            .BorderStyle = BorderStyle.None
            .Location = New Point(5, 4)
            .Font = New Font("Verdana", 8, FontStyle.Regular)
            If MultiLine = True Then
                If WordWrap = True Then
                    .WordWrap = True
                Else
                    .WordWrap = False
                End If
            Else
                If WordWrap = True Then
                    .WordWrap = True
                Else
                    .WordWrap = False
                End If
            End If
            .Size = New Size(Width - 10, Height - 11)
            .UseSystemPasswordChar = UseSystemPasswordChar
        End With

    End Sub
#End Region

    Sub New()
        MyBase.New()

        NewTextBox()
        Controls.Add(txtbox)
        Text = ""
        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.Silver
        Size = New Size(135, 24)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.SmoothingMode = SmoothingMode.HighQuality
        Dim ClientRectangle As New Rectangle(0, 0, Width - 1, Height - 1)

        With txtbox
            .Multiline = MultiLine
            If MultiLine = False Then
                Height = txtbox.Height + 11
                If WordWrap = True Then
                    .WordWrap = True
                Else
                    .WordWrap = False
                End If
            Else
                txtbox.Height = Height - 11
                If WordWrap = True Then
                    .WordWrap = True
                Else
                    .WordWrap = False
                End If
            End If
            .Width = Width - 10
            .TextAlign = TextAlignment
            .UseSystemPasswordChar = UseSystemPasswordChar
        End With

        G.Clear(BackColor)

        Dim c As Color() = New Color() {Color.FromArgb(20, 20, 20), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), Color.FromArgb(46, 46, 46), Color.FromArgb(47, 47, 47), Color.FromArgb(48, 48, 48), Color.FromArgb(49, 49, 49), Color.FromArgb(50, 50, 50)}
        G.FillPath(New SolidBrush(Color.FromArgb(50, 50, 50)), Draw.RoundRect(ClientRectangle, 3))
        Draw.InnerGlowRounded(G, ClientRectangle, 3, c)

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
Public Class MephProgressBar : Inherits Control

#Region " Control Help - Properties & Flicker Control "
    Private OFS As Integer = 0
    Private Speed As Integer = 50
    Private _Maximum As Integer = 100

    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Integer)
            Select Case v
                Case Is < _Value
                    _Value = v
            End Select
            _Maximum = v
            Invalidate()
        End Set
    End Property
    Private _Value As Integer = 0
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                Case Else
                    Return _Value
            End Select
        End Get
        Set(ByVal v As Integer)
            Select Case v
                Case Is > _Maximum
                    v = _Maximum
            End Select
            _Value = v
            Invalidate()
        End Set
    End Property
    Private _ShowPercentage As Boolean = False
    Public Property ShowPercentage() As Boolean
        Get
            Return _ShowPercentage
        End Get
        Set(ByVal v As Boolean)
            _ShowPercentage = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
    End Sub
    Sub Animate()
        While True
            If OFS <= Width Then : OFS += 1
            Else : OFS = 0
            End If
            Invalidate()
            Threading.Thread.Sleep(Speed)
        End While
    End Sub
#End Region

    Sub New()
        MyBase.New()
        DoubleBuffered = True
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        G.SmoothingMode = SmoothingMode.HighQuality

        Dim intValue As Integer = CInt(_Value / _Maximum * Width)
        G.Clear(BackColor)

        Dim percentColor As SolidBrush = New SolidBrush(Color.White)

        Dim c As Color() = New Color() {Color.FromArgb(20, 20, 20), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), Color.FromArgb(46, 46, 46), Color.FromArgb(47, 47, 47), Color.FromArgb(48, 48, 48), Color.FromArgb(49, 49, 49), Color.FromArgb(50, 50, 50)}
        G.FillPath(New SolidBrush(Color.FromArgb(50, 50, 50)), Draw.RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), 3))
        Draw.InnerGlowRounded(G, ClientRectangle, 3, c)

        '//// Bar Fill
        If Not intValue = 0 Then
            G.FillPath(New LinearGradientBrush(New Rectangle(1, 1, intValue, Height - 3), Color.FromArgb(30, 30, 30), Color.FromArgb(35, 35, 35), 90S), Draw.RoundRect(New Rectangle(1, 1, intValue, Height - 3), 2))
            G.DrawPath(New Pen(Color.FromArgb(45, 45, 45)), Draw.RoundRect(New Rectangle(1, 1, intValue, Height - 3), 2))
            'G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(15, 15, 15))), intValue + 1, 3, intValue + 1, Height - 4)
            percentColor = New SolidBrush(Color.White)
        End If



        If _ShowPercentage Then
            G.DrawString(Convert.ToString(String.Concat(Value, "%")), New Font("Tahoma", 9, FontStyle.Bold), percentColor, New Rectangle(0, 1, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
<DefaultEvent("CheckedChanged")> Public Class MephRadioButton : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Private R1 As Rectangle
    Private G1 As LinearGradientBrush

    Private State As MouseState = MouseState.None
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Height = 24
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
    Private _Checked As Boolean
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub
    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub
    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is MephRadioButton Then
                DirectCast(C, MephRadioButton).Checked = False
            End If
        Next
    End Sub

    Private _accentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _accentColor
        End Get
        Set(ByVal value As Color)
            _accentColor = value
            Invalidate()
        End Set
    End Property
#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        ForeColor = Color.Black
        Size = New Size(150, 24)
        _accentColor = Color.Maroon
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim radioBtnRectangle As New Rectangle(0, 0, Height - 1, Height - 1)
        Dim InnerRect As New Rectangle(5, 5, Height - 11, Height - 11)

        G.SmoothingMode = SmoothingMode.HighQuality
        G.CompositingQuality = CompositingQuality.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        G.Clear(BackColor)

        Dim bgGrad As New LinearGradientBrush(radioBtnRectangle, Color.FromArgb(50, 50, 50), Color.FromArgb(40, 40, 40), 90S)
        G.FillRectangle(bgGrad, radioBtnRectangle)
        G.DrawRectangle(New Pen(Color.FromArgb(20, 20, 20)), radioBtnRectangle)
        G.DrawRectangle(New Pen(Color.FromArgb(55, 55, 55)), New Rectangle(1, 1, Height - 3, Height - 3))

        If Checked Then
            Dim fillGradient As New LinearGradientBrush(InnerRect, _accentColor, Color.FromArgb(_accentColor.R + 5, _accentColor.G + 5, _accentColor.B + 5), 90S)
            G.FillRectangle(fillGradient, InnerRect)
            G.DrawRectangle(New Pen(Color.FromArgb(25, 25, 25)), InnerRect)
        End If

        Dim drawFont As New Font("Tahoma", 10, FontStyle.Bold)
        Dim nb As Brush = New SolidBrush(Color.FromArgb(200, 200, 200))
        G.DrawString(Text, drawFont, nb, New Point(28, 12), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub

End Class
Public Class MephComboBox : Inherits ComboBox
#Region " Control Help - Properties & Flicker Control "
    Private _StartIndex As Integer = 0
    Public Property StartIndex As Integer
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
    Public Overrides ReadOnly Property DisplayRectangle As System.Drawing.Rectangle
        Get
            Return MyBase.DisplayRectangle
        End Get
    End Property
    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_highlightColor), e.Bounds)
                Dim gloss As New LinearGradientBrush(e.Bounds, Color.FromArgb(30, Color.White), Color.FromArgb(0, Color.White), 90S) 'Highlight Gloss/Color
                e.Graphics.FillRectangle(gloss, New Rectangle(New Point(e.Bounds.X, e.Bounds.Y), New Size(e.Bounds.Width, e.Bounds.Height))) 'Drop Background
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(90, Color.Black)) With {.DashStyle = DashStyle.Solid}, New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1))
            Else
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), e.Bounds)
            End If
            Using b As New SolidBrush(Color.Silver)
                e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, b, New Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height))
            End Using
        Catch
        End Try
        e.DrawFocusRectangle()
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal FirstPoint2 As Point, ByVal SecondPoint2 As Point, ByVal ThirdPoint2 As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray)
        G.DrawPolygon(New Pen(New SolidBrush(Color.FromArgb(25, 25, 25))), points.ToArray)

        Dim points2 As New List(Of Point)()
        points2.Add(FirstPoint2)
        points2.Add(SecondPoint2)
        points2.Add(ThirdPoint2)
        G.FillPolygon(New SolidBrush(Clr), points2.ToArray)
        G.DrawPolygon(New Pen(New SolidBrush(Color.FromArgb(25, 25, 25))), points2.ToArray)
    End Sub
    Private _highlightColor As Color = Color.FromArgb(55, 55, 55)
    Public Property ItemHighlightColor() As Color
        Get
            Return _highlightColor
        End Get
        Set(ByVal v As Color)
            _highlightColor = v
            Invalidate()
        End Set
    End Property
#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.Transparent
        ForeColor = Color.Silver
        Font = New Font("Verdana", 8, FontStyle.Regular)
        DropDownStyle = ComboBoxStyle.DropDownList
        DoubleBuffered = True
        Size = New Size(Width, 21)
        ItemHeight = 16
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.SmoothingMode = SmoothingMode.HighQuality


        G.Clear(BackColor)
        Dim bodyGradNone As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 2), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), 90S)
        G.FillPath(bodyGradNone, Draw.RoundRect(New Rectangle(bodyGradNone.Rectangle.X, bodyGradNone.Rectangle.Y, bodyGradNone.Rectangle.Width, bodyGradNone.Rectangle.Height), 3))
        Dim bodyInBorderNone As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 3), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), 90S)
        G.DrawPath(New Pen(bodyInBorderNone), Draw.RoundRect(New Rectangle(1, 1, Width - 3, Height - 4), 3))
        G.DrawPath(New Pen(Color.FromArgb(20, 20, 20)), Draw.RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), 3)) 'Outer Line
        G.DrawPath(New Pen(Color.FromArgb(55, 55, 55)), Draw.RoundRect(New Rectangle(1, 1, Width - 3, Height - 3), 3)) 'Inner Line
        DrawTriangle(Color.FromArgb(60, 60, 60), New Point(Width - 14, 12), New Point(Width - 7, 12), New Point(Width - 11, 16), New Point(Width - 14, 10), New Point(Width - 7, 10), New Point(Width - 11, 5), G) 'Triangle Fill Color

        'Draw Separator line
        G.DrawLine(New Pen(Color.FromArgb(45, 45, 45)), New Point(Width - 21, 2), New Point(Width - 21, Height - 3))
        G.DrawLine(New Pen(Color.FromArgb(55, 55, 55)), New Point(Width - 20, 1), New Point(Width - 20, Height - 3))
        G.DrawLine(New Pen(Color.FromArgb(45, 45, 45)), New Point(Width - 19, 2), New Point(Width - 19, Height - 3))
        Try
            G.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(5, 0, Width - 20, Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
        Catch
        End Try

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
Class MephTabcontrol
    Inherits TabControl
    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(35, 85)
    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Left
    End Sub

    Function ToPen(ByVal color As Color) As Pen
        Return New Pen(color)
    End Function

    Function ToBrush(ByVal color As Color) As Brush
        Return New SolidBrush(color)
    End Function

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim FF As New Font("Verdana", 8, FontStyle.Regular)
        Try : SelectedTab.BackColor = Color.FromArgb(50, 50, 50) : Catch : End Try
        G.Clear(Parent.FindForm.BackColor)

        G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), New Rectangle(0, 0, ItemSize.Height, Height - 1)) 'Full Tab Background

        For i = 0 To TabCount - 1
            If i = SelectedIndex Then
                Dim x2 As Rectangle = New Rectangle(New Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), New Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1))
                Dim myBlend As New ColorBlend()
                myBlend.Colors = {Color.FromArgb(50, 50, 50), Color.FromArgb(50, 50, 50), Color.FromArgb(50, 50, 50)} 'Full Tab Background Gradient Accents
                myBlend.Positions = {0.0F, 0.5F, 1.0F}
                Dim lgBrush As New LinearGradientBrush(x2, Color.Black, Color.Black, 90.0F)
                lgBrush.InterpolationColors = myBlend
                G.FillRectangle(lgBrush, x2)
                'G.DrawRectangle(New Pen(Color.FromArgb(20, 20, 20)), x2) 'Full Tab Highlight Outline
                Dim tabRect As New Rectangle(GetTabRect(i).Location.X + 4, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width + 10, GetTabRect(i).Size.Height - 11)
                G.FillPath(New SolidBrush(Color.FromArgb(50, 50, 50)), RoundRect(tabRect, 4)) 'Highlight Fill Background

                Dim cFull As Color() = New Color() {Color.FromArgb(20, 20, 20), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), Color.FromArgb(46, 46, 46), Color.FromArgb(47, 47, 47), Color.FromArgb(48, 48, 48), Color.FromArgb(49, 49, 49), Color.FromArgb(50, 50, 50)}
                Draw.InnerGlow(G, New Rectangle(0, 0, ItemSize.Height + 3, Height - 1), cFull) ' Main Left Box Outline

                Dim cHighlight As Color() = New Color() {Color.FromArgb(20, 20, 20), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), Color.FromArgb(46, 46, 46), Color.FromArgb(47, 47, 47), Color.FromArgb(48, 48, 48), Color.FromArgb(49, 49, 49), Color.FromArgb(50, 50, 50)}
                Draw.InnerGlowRounded(G, tabRect, 4, cHighlight) ' Fill HighLight Inner

                G.SmoothingMode = SmoothingMode.HighQuality
                'Dim p() As Point = {New Point(ItemSize.Height - 3, GetTabRect(i).Location.Y + 20), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 14), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 27)}
                'G.FillPolygon(Brushes.White, p)

                If ImageList IsNot Nothing Then
                    Try
                        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then

                            G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(x2.Location.X + 8, x2.Location.Y + 6))
                            G.DrawString("      " & TabPages(i).Text.ToUpper, New Font(Font.FontFamily, Font.Size, FontStyle.Regular), Brushes.White, New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        Else
                            G.DrawString(TabPages(i).Text, FF, Brushes.White, New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End If
                    Catch ex As Exception
                        G.DrawString(TabPages(i).Text, FF, Brushes.White, New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End Try
                Else
                    G.DrawString(TabPages(i).Text, FF, Brushes.White, New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                End If

                G.DrawLine(New Pen(Color.FromArgb(96, 110, 121)), New Point(x2.Location.X - 1, x2.Location.Y - 1), New Point(x2.Location.X, x2.Location.Y))
                G.DrawLine(New Pen(Color.FromArgb(96, 110, 121)), New Point(x2.Location.X - 1, x2.Bottom - 1), New Point(x2.Location.X, x2.Bottom))
            Else
                Dim x2 As Rectangle = New Rectangle(New Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), New Size(GetTabRect(i).Width + 3, GetTabRect(i).Height + 1))
                'G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), x2) 'Tab Highlight
                G.DrawLine(New Pen(Color.FromArgb(96, 110, 121)), New Point(x2.Right, x2.Top), New Point(x2.Right, x2.Bottom))
                If ImageList IsNot Nothing Then
                    Try
                        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                            G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(x2.Location.X + 8, x2.Location.Y + 6))
                            G.DrawString("      " & TabPages(i).Text, Font, Brushes.White, New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Near, .Alignment = StringAlignment.Near})
                        Else
                            G.DrawString(TabPages(i).Text, FF, New SolidBrush(Color.FromArgb(210, 220, 230)), New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End If
                    Catch ex As Exception
                        G.DrawString(TabPages(i).Text, FF, New SolidBrush(Color.FromArgb(210, 220, 230)), New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End Try
                Else
                    G.DrawString(TabPages(i).Text, FF, New SolidBrush(Color.FromArgb(210, 220, 230)), New Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                End If
            End If
            G.FillRectangle(New SolidBrush(Color.FromArgb(50, 50, 50)), New Rectangle(86, -1, Width - 86, Height + 1)) 'Page Fill Full

            Dim c As Color() = New Color() {Color.FromArgb(20, 20, 20), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), Color.FromArgb(46, 46, 46), Color.FromArgb(47, 47, 47), Color.FromArgb(48, 48, 48), Color.FromArgb(49, 49, 49), Color.FromArgb(50, 50, 50)}
            Draw.InnerGlowRounded(G, New Rectangle(86, 0, Width - 87, Height - 1), 3, c) ' Fill Page
        Next

        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(50, 50, 50))), New Rectangle(0, 0, ItemSize.Height + 4, Height - 1)) 'Full Tab Outer Outline
        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(20, 20, 20))), New Rectangle(1, 0, ItemSize.Height + 3, Height - 2)) 'Full Tab Inner Outline

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
<DefaultEvent("CheckedChanged")> Public Class MephCheckBox : Inherits Control

#Region " Control Help - MouseState & Flicker Control"
    Private State As MouseState = MouseState.None
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
    Private _Checked As Boolean
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property
    Private _accentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _accentColor
        End Get
        Set(ByVal value As Color)
            _accentColor = value
            Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Height = 24
    End Sub
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub
    Event CheckedChanged(ByVal sender As Object)
#End Region


    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.OptimizedDoubleBuffer, True)
        BackColor = Color.Transparent
        ForeColor = Color.Black
        Size = New Size(250, 24)
        _accentColor = Color.Maroon
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim radioBtnRectangle As New Rectangle(0, 0, Height - 1, Height - 1)
        Dim InnerRect As New Rectangle(5, 5, Height - 11, Height - 11)

        G.SmoothingMode = SmoothingMode.HighQuality
        G.CompositingQuality = CompositingQuality.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        G.Clear(BackColor)

        Dim bgGrad As New LinearGradientBrush(radioBtnRectangle, Color.FromArgb(50, 50, 50), Color.FromArgb(40, 40, 40), 90S)
        G.FillRectangle(bgGrad, radioBtnRectangle)
        G.DrawRectangle(New Pen(Color.FromArgb(20, 20, 20)), radioBtnRectangle)
        G.DrawRectangle(New Pen(Color.FromArgb(55, 55, 55)), New Rectangle(1, 1, Height - 3, Height - 3))

        If Checked Then
            Dim fillGradient As New LinearGradientBrush(InnerRect, _accentColor, Color.FromArgb(_accentColor.R + 5, _accentColor.G + 5, _accentColor.B + 5), 90S)
            G.FillRectangle(fillGradient, InnerRect)
            G.DrawRectangle(New Pen(Color.FromArgb(25, 25, 25)), InnerRect)
        End If

        Dim drawFont As New Font("Tahoma", 10, FontStyle.Bold)
        Dim nb As Brush = New SolidBrush(Color.FromArgb(200, 200, 200))
        G.DrawString(Text, drawFont, nb, New Point(28, 12), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()

    End Sub

End Class