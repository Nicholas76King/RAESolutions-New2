Namespace IntegratedSecurity

   ''' <summary>
   ''' Indicates an identity's authorization to access protected portions of the application.
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/07/07">
   ''' Copied
   ''' </history>
   Public Enum AccessLevel As Integer
      ALL = 100   'ALL = has access to all company forms
        CRI = 101     'CRI = access to century refrigertion forms
        TSI = 102 'TSI = access to technical systems forms
        ALL_P = 103    'P = access to pricing
        CRI_P = 104
        TSI_P = 105

        RSI = 106
        RSI_P = 107

    End Enum

End Namespace