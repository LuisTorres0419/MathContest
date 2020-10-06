'Tim Rossiter
'RCET0265
'Fall 2020
'Math Contest
'

Public Class MathContestForm
    Dim number1 As Integer
    Dim number2 As Integer
    Dim systemAnswer As Integer
    Dim problems As Integer = 0I
    Dim correctproblems As Integer = 0I



    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub SummeryButton_Click(sender As Object, e As EventArgs) Handles SummeryButton.Click
        MsgBox(correctproblems & "/" & problems & "   Good job!")
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

        NameTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        StudentAnswerTextBox.Text = ""
        FirstNumberTextBox.Text = ""
        SeconNumberTextBox.Text = ""
        problems = 0
        correctproblems = 0
        Controlset()


    End Sub

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Controlset()

    End Sub

    Sub Controlset()

        AddRadioButton.Enabled = False
        SubtractRadioButton.Enabled = False
        MultiplyRadioButton.Enabled = False
        DivideRadioButton.Enabled = False
        FirstNumberTextBox.Enabled = False
        SeconNumberTextBox.Enabled = False
        StudentAnswerTextBox.Enabled = False
        StudentInformationGroupBox.Enabled = True
        SubmitButton.Enabled = False
        SummeryButton.Enabled = False

    End Sub


    Sub ControlReset()

        If GradeTextBox.Text = 1 Then
            AddRadioButton.Enabled = True
            SubtractRadioButton.Enabled = False
            MultiplyRadioButton.Enabled = False
            DivideRadioButton.Enabled = False
        ElseIf GradeTextBox.Text = 2 Then
            AddRadioButton.Enabled = True
            SubtractRadioButton.Enabled = True
            MultiplyRadioButton.Enabled = False
            DivideRadioButton.Enabled = False
        ElseIf GradeTextBox.Text = 3 Then
            AddRadioButton.Enabled = True
            SubtractRadioButton.Enabled = True
            MultiplyRadioButton.Enabled = True
            DivideRadioButton.Enabled = False
        ElseIf GradeTextBox.Text = 4 Then
            AddRadioButton.Enabled = True
            SubtractRadioButton.Enabled = True
            MultiplyRadioButton.Enabled = True
            DivideRadioButton.Enabled = True
        End If




        FirstNumberTextBox.Enabled = True
        SeconNumberTextBox.Enabled = True
        StudentAnswerTextBox.Enabled = True
        StudentInformationGroupBox.Enabled = False
        SubmitButton.Enabled = True
        SummeryButton.Enabled = True

    End Sub


    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click



        If AddRadioButton.Checked = True Then
            systemAnswer = CInt(number1) + CInt(number2)
        ElseIf SubtractRadioButton.Checked = True Then
            systemAnswer = CInt(number1) - CInt(number2)
        ElseIf MultiplyRadioButton.Checked = True Then
            systemAnswer = CInt(number1) * CInt(number2)
        ElseIf DivideRadioButton.Checked = True Then
            systemAnswer = CInt(number1) / CInt(number2)
        End If



        Try

            If Not StudentAnswerTextBox.Text = Nothing Then
                If StudentAnswerTextBox.Text = systemAnswer Then
                    MsgBox("correct")
                    correctproblems += 1
                    problems += 1
                    StudentAnswerTextBox.Clear()
                Else
                    MsgBox("incorrect")
                    StudentAnswerTextBox.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox("numbers!!")
        End Try




        InfotextBoxes()

        If Accumulatemessage("", False) <> "" Then
            AlertUser(Accumulatemessage("", False))
        End If


        Randomize()
        number1 = CInt((10 * Rnd()) + 1)
        Randomize()
        number2 = CInt((10 * Rnd()) + 1)
        FirstNumberTextBox.Text = number1
        SeconNumberTextBox.Text = number2
        StudentAnswerTextBox.Text = ""
        StudentAnswerTextBox.Select()
        SummeryButton.Enabled = True


    End Sub

    Sub InfotextBoxes()

        Dim problem As Boolean = False
        If NameTextBox.Text = "" Then
            Accumulatemessage("Name is need to continue.", False)
            NameTextBox.Focus()
            problem = False
        End If

        Try

            If AgeTextBox.Text = "" Then
                Accumulatemessage("Age is need to continue.", False)
                AgeTextBox.Focus()
                problem = False
            ElseIf AgeTextBox.Text > 6 And AgeTextBox.Text < 12 Then
            Else
                Accumulatemessage("Ages 7 to 11 only.", False)
                AgeTextBox.Focus()
                problem = False
            End If

            If GradeTextBox.Text = "" Then
                Accumulatemessage("Grade is need to continue.", False)
                GradeTextBox.Focus()
                problem = False
            ElseIf GradeTextBox.Text > 0 And GradeTextBox.Text < 5 Then
                ControlReset()

            Else
                Accumulatemessage("grades 1 to 4 only.", False)
                GradeTextBox.Focus()
                problem = False
            End If
        Catch ex As Exception
            MsgBox("numbers!!")
        End Try


    End Sub


    Function Accumulatemessage(ByVal newMessage As String, ByVal clear As Boolean) As String

        Static message As String

        If clear Then
            message = ""
        ElseIf newMessage <> "" Then
            message &= newMessage & vbNewLine
        End If

        Return message

    End Function

    Sub AlertUser(ByVal messege As String)
        MsgBox(messege)
        Accumulatemessage("", True)
    End Sub

    Private Sub CurrentMathProblemGroupBox_Enter(sender As Object, e As EventArgs) Handles _
 FirstNumberTextBox.TextChanged, SeconNumberTextBox.TextChanged, StudentAnswerLabel.TextChanged
        Dim userMessage As String = ""
        Dim answer As Boolean
        answer = False

        If StudentAnswerLabel.Text <> "" Then
            Try
                answer = True
            Catch ex As Exception
                MsgBox("please enter")
            End Try
        End If
        If userMessage <> "" Then
            MsgBox(userMessage)
        End If

    End Sub

    Private Sub GradeTextBox_TextChanged(sender As Object, e As EventArgs) Handles GradeTextBox.TextChanged
        If Me.GradeTextBox.Text <> String.Empty Then
            SubmitButton.Enabled = True
        Else
            SubmitButton.Enabled = False
        End If
    End Sub

    Private Sub AgeTextBox_TextChanged(sender As Object, e As EventArgs) Handles AgeTextBox.TextChanged
        If Me.AgeTextBox.Text <> String.Empty Then
            SubmitButton.Enabled = True
        Else
            SubmitButton.Enabled = False
        End If
    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        If Me.NameTextBox.Text <> String.Empty Then
            SubmitButton.Enabled = True
        Else
            SubmitButton.Enabled = False
        End If
    End Sub
End Class