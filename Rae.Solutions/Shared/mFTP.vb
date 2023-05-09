Imports Rae.Core
Imports EnterpriseDT.Util.Debug
Imports EnterpriseDT.Net.Ftp

Module mFTP

   '>> the associated ftp dll (edtftpnet-1.1.4) is from enterprisedt.com and is freeware
   '>> ftpFilePath parameter should not include the ftp ip address, rather
   '   just the file's parent directories and the filename ex. [dir]/[filename]
   Friend Function FTPCopy(ByVal localPath As String, ByVal ftpFilePath As String, ByVal ftpAddress As String) As Outcome
      Dim copyOutcome As Outcome = Outcome.Succeeded
      '>> the "ftp://" text should not be used in host; it will cause an error (from testing)
      '>> to test on RAE's network use 199.5.83.253
      '>> for access away from network use 68.88.115.111
      Dim host As String = ftpAddress
      'if username is blank the connection fails (from testing)
      Dim user As String = "anonymous"
      Dim password As String = ""
      Dim ftp As FTPClient = Nothing

      Try
         'connects to ftp server
         ftp = New FTPClient(host)
         'logs in anonymously
         ftp.Login(user, password)
         'server uses passive (PASV) mode; other option is Active
         ftp.ConnectMode = FTPConnectMode.PASV
         'sets transfer type to binary opposed to ASCII
         ftp.TransferType = FTPTransferType.BINARY
         'copies file from ftp
         ftp.Get(localPath, ftpFilePath)
         ftp.Quit()
      Catch Ex As Exception
         MessageBox.Show("Attempt to copy file from ftp server failed. " & _
         Environment.NewLine & Environment.NewLine & Ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Error)
         copyOutcome = Outcome.Failed
      End Try

      'returns true if succeeded, false if failed
      Return copyOutcome
   End Function

End Module
