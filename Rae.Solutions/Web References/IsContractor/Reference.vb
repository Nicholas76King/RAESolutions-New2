﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.586
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.586.
'
Namespace IsContractor
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="AuthenticateSoap", [Namespace]:="http://www.rae-int.com/RAE/392423")>  _
    Partial Public Class Authenticate
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private CallAuthenticateOperationCompleted As System.Threading.SendOrPostCallback
        
        Private IsContractorOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Rae.RaeSolutions.My.MySettings.Default.RaeSolutions_IsContractor_Authenticate
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event CallAuthenticateCompleted As CallAuthenticateCompletedEventHandler
        
        '''<remarks/>
        Public Event IsContractorCompleted As IsContractorCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.rae-int.com/RAE/392423/Authenticate", RequestElementName:="Authenticate", RequestNamespace:="http://www.rae-int.com/RAE/392423", ResponseElementName:="AuthenticateResponse", ResponseNamespace:="http://www.rae-int.com/RAE/392423", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CallAuthenticate(ByVal UserName As String, ByVal Password As String, ByVal ProgramVersion As String, ByVal OperatingSystem As String, ByVal OperatingSystemVersion As String) As <System.Xml.Serialization.XmlElementAttribute("AuthenticateResult")> AuthenticationResult
            Dim results() As Object = Me.Invoke("CallAuthenticate", New Object() {UserName, Password, ProgramVersion, OperatingSystem, OperatingSystemVersion})
            Return CType(results(0),AuthenticationResult)
        End Function
        
        '''<remarks/>
        Public Function BeginCallAuthenticate(ByVal UserName As String, ByVal Password As String, ByVal ProgramVersion As String, ByVal OperatingSystem As String, ByVal OperatingSystemVersion As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CallAuthenticate", New Object() {UserName, Password, ProgramVersion, OperatingSystem, OperatingSystemVersion}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndCallAuthenticate(ByVal asyncResult As System.IAsyncResult) As AuthenticationResult
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),AuthenticationResult)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CallAuthenticateAsync(ByVal UserName As String, ByVal Password As String, ByVal ProgramVersion As String, ByVal OperatingSystem As String, ByVal OperatingSystemVersion As String)
            Me.CallAuthenticateAsync(UserName, Password, ProgramVersion, OperatingSystem, OperatingSystemVersion, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CallAuthenticateAsync(ByVal UserName As String, ByVal Password As String, ByVal ProgramVersion As String, ByVal OperatingSystem As String, ByVal OperatingSystemVersion As String, ByVal userState As Object)
            If (Me.CallAuthenticateOperationCompleted Is Nothing) Then
                Me.CallAuthenticateOperationCompleted = AddressOf Me.OnCallAuthenticateOperationCompleted
            End If
            Me.InvokeAsync("CallAuthenticate", New Object() {UserName, Password, ProgramVersion, OperatingSystem, OperatingSystemVersion}, Me.CallAuthenticateOperationCompleted, userState)
        End Sub
        
        Private Sub OnCallAuthenticateOperationCompleted(ByVal arg As Object)
            If (Not (Me.CallAuthenticateCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CallAuthenticateCompleted(Me, New CallAuthenticateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.rae-int.com/RAE/392423/IsContractor", RequestNamespace:="http://www.rae-int.com/RAE/392423", ResponseNamespace:="http://www.rae-int.com/RAE/392423", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function IsContractor(ByVal UserName As String) As Boolean
            Dim results() As Object = Me.Invoke("IsContractor", New Object() {UserName})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Function BeginIsContractor(ByVal UserName As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("IsContractor", New Object() {UserName}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndIsContractor(ByVal asyncResult As System.IAsyncResult) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub IsContractorAsync(ByVal UserName As String)
            Me.IsContractorAsync(UserName, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub IsContractorAsync(ByVal UserName As String, ByVal userState As Object)
            If (Me.IsContractorOperationCompleted Is Nothing) Then
                Me.IsContractorOperationCompleted = AddressOf Me.OnIsContractorOperationCompleted
            End If
            Me.InvokeAsync("IsContractor", New Object() {UserName}, Me.IsContractorOperationCompleted, userState)
        End Sub
        
        Private Sub OnIsContractorOperationCompleted(ByVal arg As Object)
            If (Not (Me.IsContractorCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent IsContractorCompleted(Me, New IsContractorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.450"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.rae-int.com/RAE/392423")>  _
    Partial Public Class AuthenticationResult
        
        Private isAuthenticatedField As Boolean
        
        Private disableAccountField As Boolean
        
        Private accessLevelField As Integer
        
        Private authorityGroupField As Integer
        
        Private userFullNameField As String
        
        '''<remarks/>
        Public Property isAuthenticated() As Boolean
            Get
                Return Me.isAuthenticatedField
            End Get
            Set
                Me.isAuthenticatedField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property disableAccount() As Boolean
            Get
                Return Me.disableAccountField
            End Get
            Set
                Me.disableAccountField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property accessLevel() As Integer
            Get
                Return Me.accessLevelField
            End Get
            Set
                Me.accessLevelField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property authorityGroup() As Integer
            Get
                Return Me.authorityGroupField
            End Get
            Set
                Me.authorityGroupField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property userFullName() As String
            Get
                Return Me.userFullNameField
            End Get
            Set
                Me.userFullNameField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub CallAuthenticateCompletedEventHandler(ByVal sender As Object, ByVal e As CallAuthenticateCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CallAuthenticateCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As AuthenticationResult
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),AuthenticationResult)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub IsContractorCompletedEventHandler(ByVal sender As Object, ByVal e As IsContractorCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class IsContractorCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
    End Class
End Namespace