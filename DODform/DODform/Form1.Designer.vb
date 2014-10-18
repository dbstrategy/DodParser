<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnFilePath = New System.Windows.Forms.Button()
        Me.btnOutputPath = New System.Windows.Forms.Button()
        Me.ofdInputFilepath = New System.Windows.Forms.OpenFileDialog()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.lblOutputFile = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnFilePath
        '
        Me.btnFilePath.Location = New System.Drawing.Point(291, 60)
        Me.btnFilePath.Name = "btnFilePath"
        Me.btnFilePath.Size = New System.Drawing.Size(75, 23)
        Me.btnFilePath.TabIndex = 0
        Me.btnFilePath.Text = "File Path"
        Me.btnFilePath.UseVisualStyleBackColor = True
        '
        'btnOutputPath
        '
        Me.btnOutputPath.Location = New System.Drawing.Point(291, 122)
        Me.btnOutputPath.Name = "btnOutputPath"
        Me.btnOutputPath.Size = New System.Drawing.Size(75, 23)
        Me.btnOutputPath.TabIndex = 1
        Me.btnOutputPath.Text = "Output Path"
        Me.btnOutputPath.UseVisualStyleBackColor = True
        '
        'ofdInputFilepath
        '
        Me.ofdInputFilepath.FileName = "OpenInputFilePath"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(177, 193)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.Location = New System.Drawing.Point(22, 70)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(115, 13)
        Me.lblFilePath.TabIndex = 3
        Me.lblFilePath.Text = "Slect the input file path"
        '
        'lblOutputFile
        '
        Me.lblOutputFile.AutoSize = True
        Me.lblOutputFile.Location = New System.Drawing.Point(22, 127)
        Me.lblOutputFile.Name = "lblOutputFile"
        Me.lblOutputFile.Size = New System.Drawing.Size(103, 13)
        Me.lblOutputFile.TabIndex = 4
        Me.lblOutputFile.Text = "Slect the ouput path"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 271)
        Me.Controls.Add(Me.lblOutputFile)
        Me.Controls.Add(Me.lblFilePath)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnOutputPath)
        Me.Controls.Add(Me.btnFilePath)
        Me.Name = "Form1"
        Me.Text = "DODParser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFilePath As System.Windows.Forms.Button
    Friend WithEvents btnOutputPath As System.Windows.Forms.Button
    Friend WithEvents ofdInputFilepath As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblFilePath As System.Windows.Forms.Label
    Friend WithEvents lblOutputFile As System.Windows.Forms.Label

End Class
