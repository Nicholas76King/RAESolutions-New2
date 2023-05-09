Imports System.Collections.Generic
Imports rae.Collections
Imports rae.solutions.credentials

Namespace rae.solutions

    ''' <summary>Groups of usernames</summary>
    Public Class group

#Region " groups"

        Public Shared ReadOnly employees As New group(New user_list() _
           .add("ADAMM", "ALISANT", "BETHO", "BRETTC", "BRIANM", "CARAD", "CARLW", "CASEYJ", "dakotal", "CHARLESS", "CHARLIEB", "CLIFFM", "CODYG", "DANH", "DANM", "DANNYG", "DARINA", "DAVEN", "DONA", "DONNAC", "DREWS", "ERICS", "FAISALB", "GARYB", "GREGK", "JAMESS", "JASONS", "JAYK", "JCHANDLER", "JCOCHREN", "JDGILBO", "JENNIFERH", "JEREMYC", "JERRYA", "JERRYF", "JERRYJR", "JIMG", "JIMW", "DAVEB", "JOED", "JOES", "JOHNJ", "JOSEYM", "JUDYS", "KARIM", "KELLYA", "KEVINT", "KIRKS", "kyleb", "LARRYH", "LINDAZ", "LOIST", "LYNND", "MARGOF", "MARYG", "MELODYS", "MIKEM", "MIKEW", "NEWLYR", "PHILLIPC", "RANDYHN", "ROBERTD", "ROBM", "SALESSUPPORT", "SALLYD", "SHAWNL", "STACYP", "SYLVIAD", "TERRYT", "TODDM", "TONYG", "VICKIES", "WANDAI", "WESM", "WESTONS", "TROYB", "HEATHERM", "BRADM", "TOMA", "jedidiahh", "STEVEC", "chrisharrison", "DAVEB", "DAVIDH", "jarredw", "TOMMYR", "JACKH"))

        Public Shared ReadOnly IT As New group(New user_list() _
           .add("DannyG", "CaseyJ", "DonA", "JaniceM", "EricC", "dakotal", "kyleb"))

        Public Shared ReadOnly century_sales As New group(New user_list() _
           .add("LarryH", "GaryB", "DaveN", kevin, "caseyj", "dakotal", "wesleyd", "chrisharrison", "kyleb", "jarredw", "JACKH"))

        Public Shared ReadOnly technical_systems_sales As New group(New user_list() _
           .add(adam, "MikeM", "CodyG", "DrewS", kevin, "toma", "STEVEC", "jedidiahh", "chrisharrison", "jarredw", "TOMMYR", "kyleb", "jarredw"))

        Public Shared ReadOnly sales As New group(New user_list() _
           .add(century_sales).add(technical_systems_sales))

        Public Shared ReadOnly application_engineering As New group(New user_list() _
           .add("LynnD", jim_wilson, jay, "TroyB", "BrettC", "kyleb", "caseyj", "dakotal", "DAVEB", "TOMMYR", "alexm", "jarredw", "chrisharrison"))

        Public Shared ReadOnly capacity_multiplier As New group(New user_list() _
   .add(jim_wilson, jay, "BrettC", "kyleb", "caseyj", "dakotal", "daveb", "TOMMYR", "jarredw"))



#End Region

#Region " permissions"
        'for oem, rsi, etc
        Public Shared ReadOnly choose_report_logo As New group(New user_list() _
           .add("DanH", "WestonS", "JoeS", "BrettC", faisal, "TroyB", "JerryF", "LarryH", "GaryB", "DaveN", "MelodyS", "LynnD", "adamm", "jedidiahh", "STEVEC", "caseyj", "cliffm", "davidh", "jimw", "daveb", "DAVIDH", "dakotal", "kyleb"))


        Public Shared ReadOnly enter_custom_cfm_cond_unit As New group(New user_list() _
   .add("caseyj", jim_wilson, adam, jay, "DAVEB", "TOMMYR", "dakotal", "kyleb", "larryh", "GARYB", "DAVEN", "WESLEYD", "CHRISHARRISON", "JACKH"))



        Public Shared ReadOnly chiller_engineering_options As New group(New user_list() _
           .add(application_engineering) _
           .add("JohnJ", adam, "CodyG", "DrewS", "TOMA", "STEVEC", "chrisharrison", "kyleb"))

        Public Shared ReadOnly balance_R410a_chiller As New group(New user_list() _
           .add(technical_systems_sales).add(application_engineering) _
           .add("CharlesS", "DanH", kevin, "JoeS", "WestonS", "JohnJ", "jeremyc", "DAVIDH", "jarredw", "TOMMYR", "kyleb"))

        Public Shared ReadOnly century_R134a As New group(New user_list().add(faisal, "CASEYJ", "JD", "dakotal", "kyleb"))

        Public Shared ReadOnly CSW_Compressors As New group(New user_list() _
.add("jeremyc", "ericc", "adamm", "caseyj", "dakotal", "kyleb"))



        Public Shared ReadOnly view_overrides_on_report As New group(New user_list() _
           .add(application_engineering))

        ''mikem says not to release to reps yet, see email
        '     Public Shared ReadOnly rate_20A4 As New group(New user_list() _
        '        .add(employees))

        Public Shared ReadOnly rate_water_cooled_condensing_unit As New group(New user_list() _
           .add(application_engineering))

        Public Shared ReadOnly calculate_iplv As New group(New user_list() _
           .add(faisal))

        Public Shared ReadOnly generate_catalogs As New group(New user_list() _
           .add("DaveN", jim_chandler, jay, jim_wilson, casey, "HeatherM", "cliffm", "kyleb", "dakotal"))

#End Region

    End Class


    Partial Public Class group : Inherits listing(Of list(Of String))

        Private Sub New(ByVal values As list(Of String))
            MyBase.new(values)
        End Sub

        Function contains(ByVal username As String) As Boolean
            For Each name As String In Me.value
                If String.Equals(name, username, StringComparison.CurrentCultureIgnoreCase) Then
                    Return True
                End If
            Next
            Return False
        End Function

    End Class


    Public Enum access_level As Integer
        ALL = 100   'ALL = has access to all company forms
        CRI = 101       'CRI = access to century refrigertion forms
        TSI = 102   'TSI = access to technical systems forms
        ALL_P = 103    'P = access to pricing
        CRI_P = 104
        TSI_P = 105
        RSI = 106
        RSI_P = 107
    End Enum

End Namespace