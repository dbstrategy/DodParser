Option Strict Off
Imports System
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Text.RegularExpressions


Public Class Form1

    Dim strOutputPath As String
    Dim strInputath As String

    Private Sub DODParser(ByVal v_strInputFileName As String)

        Dim srInputFile As IO.StreamReader
        Try
            srInputFile = IO.File.OpenText(v_strInputFileName)                        'Input file is in open mode
            Dim strLine As String = ""

            Do Until srInputFile.EndOfStream    'for each row
                Dim dictSymbolBarValues = New Dictionary(Of String, Barvalues)
                Dim strSymbolPath As String
                Dim astrline() As String
                Dim iVolume As Int64 = 0

                If strLine.Length <= 0 Then
                    strLine = srInputFile.ReadLine()
                End If

                astrline = Split(strLine, ",")
                Dim iMinute As Int64 = Fix(Convert.ToInt64(astrline(1).Substring(0, 10)) / 60)

                Dim dCurrentPrice As Double = Convert.ToDouble(astrline(5))

                Dim iCurrentVolume As Int64 = 0

                While srInputFile.EndOfStream = False Or strLine <> Nothing
                    astrline = Split(strLine, ",")
                    ' Dim culture As CultureInfo = Nothing
                    Dim iTempTime As Int64 = Fix(Convert.ToInt64(astrline(1).Substring(0, 10)) / 60)

                    If iMinute <> iTempTime Then
                        Exit While
                    End If

                    'culture = CultureInfo.CreateSpecificCulture("en-US")
                    dCurrentPrice = Convert.ToDouble(astrline(5))
                    iCurrentVolume = Convert.ToInt64(Regex.Replace(astrline(6), @"\s+", " "))
                    'Int64.TryParse(astrline(6), culture)

                    'Substring(0, astrline(6).IndexOfAny(New Char() {" "c, vbCrLf, vbCr, vbLf})))

                    If dictSymbolBarValues.ContainsKey(astrline(2)) = False Then
                        dictSymbolBarValues.Add(astrline(2), New Barvalues With _
                            {.dOpen = dCurrentPrice, .dClose = dCurrentPrice, .dHigh = dCurrentPrice, .dLow = dCurrentPrice, .iVolume = iCurrentVolume})
                    Else

                        Dim barVal As Barvalues = dictSymbolBarValues(astrline(2))

                        barVal.iVolume += iCurrentVolume

                        barVal.dClose = dCurrentPrice

                        If barVal.dHigh < dCurrentPrice Then
                            barVal.dHigh = dCurrentPrice
                        End If

                        If barVal.dLow > dCurrentPrice Then
                            barVal.dLow = dCurrentPrice
                        End If
                        dictSymbolBarValues(astrline(2)) = barVal
                    End If
                    strLine = srInputFile.ReadLine()
                End While

                Dim MyDateTime As DateTime = epoch2date(iMinute * 60 + 60)

                For Each pair As KeyValuePair(Of String, Barvalues) In dictSymbolBarValues
                    strSymbolPath = My.Settings.outputPath & "\" & pair.Key & ".txt"
                    DODWriter(strSymbolPath, MyDateTime, pair.Value.dOpen, pair.Value.dHigh, pair.Value.dLow, pair.Value.dClose, pair.Value.iVolume)
                Next
                dictSymbolBarValues.Clear()

            Loop
        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
            MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
        End Try
    End Sub

    Function epoch2date(myEpoch)
        epoch2date = DateAdd("s", myEpoch, "01/01/1970 00:00:00").ToLocalTime()
    End Function

    Public Sub DODWriter(strSymbolPath As String, MyDateTime As DateTime, dOpen As Double, dHigh As Double, dLow As Double, dClose As Double, iVolume As Int64)

        If Not File.Exists(strSymbolPath) Then                                           ' Check whether Symbol File Name exist
            Using outfileInit As StreamWriter = New StreamWriter(strSymbolPath, True)
                outfileInit.WriteLine("DATE,TIME,OPEN,HIGH,LOW,CLOSE,VOLUME")
            End Using
        End If
        Using outfile As StreamWriter = New StreamWriter(strSymbolPath, True)            'Append SymbolFile for writing
            outfile.WriteLine(MyDateTime.ToShortDateString() & "," & Format(MyDateTime, "HH:mm:ss") & "," _
                              & dOpen & "," & dHigh & "," & dLow & "," & dClose & "," & iVolume)
        End Using
    End Sub

    Private Sub btnFilePath_Click(sender As Object, e As EventArgs) Handles btnFilePath.Click
        Dim result As DialogResult = ofdInputFilepath.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            strInputath = ofdInputFilepath.FileName
            lblFilePath.Text = strInputath
        End If
    End Sub

    Private Sub btnOutputPath_Click(sender As Object, e As EventArgs) Handles btnOutputPath.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            strOutputPath = folderDlg.SelectedPath
            lblOutputFile.Text = strOutputPath
            Dim root As Environment.SpecialFolder = folderDlg.RootFolder
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        DODParser(strInputath)
        MsgBox("DOD Parser Done!")
    End Sub
End Class



