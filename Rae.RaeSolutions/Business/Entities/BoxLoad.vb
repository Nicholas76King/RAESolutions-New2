Imports Rae.Persistence
Imports Rae.Reflection
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities

Public Class BoxLoad
   Inherits ItemBase
   Implements IEquatable(Of BoxLoad)
   Implements ICloneable(Of BoxLoad)
   Implements ICanBePersisted
   
   
   ''' <summary>
   ''' DO NOT USE.
   ''' </summary>
   ''' <remarks>
   ''' Parameterless constructor used for reflection during Clone and Equals.
   ''' </remarks>
   <EditorBrowsable(EditorBrowsableState.Never)> _
   Sub New()
      MyBase.initialize()
      da = New Rae.Data.Access.BoxLoadProjects()
      revisions_ = New RevisionList()
      Revisions.Add(New Revision(0, 0))
      Revisions.Current = Revisions(0)
   End Sub

   ''' <summary>
   ''' Initializes a new box load.
   ''' </summary>
   ''' <param name="itemId">
   ''' Item ID
   ''' </param>
   ''' <param name="projectManager">
   ''' Project manager
   ''' </param>   
   Sub New(itemId As item_id, projectManager As project_manager)
      Me.New()
      Me.id = itemId
      Me.ProjectManager = projectManager
   End Sub


#Region " Events"
   
   ''' <summary>
   ''' Occurs after saved as revision
   ''' </summary>
   Event SavedAsRevision As EventHandler(Of ICanBeRevisioned, EventArgs) _
   Implements ICanBeRevisioned.SavedAsRevision


   ''' <summary>
   ''' Raises SavedAsRevision event.
   ''' </summary>
   ''' <param name="e">
   ''' Event arguments to pass in event.
   ''' </param>
   Protected Overridable Sub onSavedAsRevision(e As EventArgs)
      If Me.SavedAsRevisionEvent IsNot Nothing Then
         RaiseEvent SavedAsRevision(Me, e)
      End If
   End Sub

#End Region


#Region " Properties"


   Overrides Property name As String _
   Implements ICanBePersisted.Name
      Get
         Return MyBase.name
      End Get
      Set(value As String)
         MyBase.name = value
      End Set
   End Property

   Property DbId As Integer
   Property Description As String
   ''' <summary>Capacity the user entered</summary>
   Property UserCapacity As String
   Property UserCapacityChecked As Boolean
   Property Ambient As String
   ''' <summary>External wet bulb</summary>
   Property ExternalWb As String
   Property RoomTemperature As String
   Property ExternalWallTemperature1 As String
   Property ExternalWallTemperature2 As String
   Property ExternalWallTemperature3 As String
   Property ExternalWallTemperature4 As String
   Property ExternalWallTemperature5 As String
   Property ExternalWallTemperature6 As String
   Property InsulW1 As String
   Property InsulW2 As String
   Property InsulW3 As String
   Property InsulW4 As String
   Property InsulW5 As String
   Property InsulW6 As String
   Property ThickW1 As String
   Property ThickW2 As String
   Property ThickW3 As String
   Property ThickW4 As String
   Property ThickW5 As String
   Property ThickW6 As String
   Property KFactor1 As String
   Property KFactor2 As String
   Property KFactor3 As String
   Property KFactor4 As String
   Property KFactor5 As String
   Property KFactor6 As String
   Property WallTotal As String
   Property FExtTemp As String
   Property InsulF As String
   Property ThickF As String
   Property KFactorF As String
   Property FloorTotal As String
   Property CExtTemp As String
   Property InsulC As String
   Property ThickC As String
   Property KFactorC As String
   Property CeilingTotal As String
   Property TransTotal As String
   Property IVolume As String
   Property InfWb As String
   Property InfDb As String
   Property IFactor As String
   Property IAirChg As String
   Property TotalInfil As String
   Property RoomArea As String
   Property RoomVolume As String
   Property Wall1 As String
   Property Wall2 As String
   Property Wall3 As String
   Property Wall4 As String
   Property Wall5 As String
   Property Wall6 As String
   Property Height1 As String
   Property Height2 As String
   Property Height3 As String
   Property Height4 As String
   Property Height5 As String
   Property Height6 As String
   Property txtImageCounter As String
   Property rdoRectangle As Boolean
   Property WattL As String
   Property TotalOl As String
   Property MotorHp As String
   Property TotalOm As String
   Property People As String
   Property TotalOP As String
   Property OtherType As String
   Property OtherBtu As String
   Property TotalOo As String
   Property OtherTotal As String
   Property ForkLift As String
   Property ForkLiftTotal As String
   Property DockDoors As String
   Property DockDoorsTotal As String
   Property SumTran As String
   Property SumInf As String
   Property SumProd As String
   Property SumOther As String
   Property SumTotal As String
   Property Safety As String
   Property SafetyTotal As String
   Property RunVar As String
   Property RunVarTotal As String
   Property LoadTotal As String
   Property btnAllWallSy As Boolean
   Property btnAllWallSn As Boolean
   Property MyState As String
   Property MyCity As String
   Property KFactors As Boolean
   Property Rw1 As Single
   Property Rw2 As Single
   Property Rw3 As Single
   Property Rw4 As Single
   Property Rw5 As Single
   Property Rw6 As Single
   Property RwFloor As Single
   Property RwCeiling As Single
   Property RoomNumber As String
   Property RoomWetBulb As String
#End Region

   <Exclude> _
   ReadOnly Property Revisions As RevisionList _
   Implements ICanBeRevisioned.Revisions
      Get
         Return revisions_
      End Get
   End Property

   <Exclude> _
   ReadOnly Property HasChanged As Boolean _
   Implements IAmAwareOfChange.HasChanged
      Get
         Return Not Me.Equals(LastSavedState)
      End Get
   End Property
   
   Private refresh_ As RefreshSignature
   <Exclude> _
   Property Refresh As RefreshSignature _
   Implements ICanBeRevisioned.Refresh
      Get
         Return refresh_
      End Get
      Set(value As RefreshSignature)
         refresh_ = value
      End Set
   End Property

   <Exclude> _
   ReadOnly Property LastSavedState As BoxLoad
      Get
         Return lastSavedState_
      End Get
   End Property

   Overrides Sub Save() _
   Implements ICanBeSaved.Save
      DbId = da.Save(toDto)
      lastSavedState_ = Me.Clone()
   End Sub
   
   Sub SaveAsRevision() _
   Implements ICanBeSavedAsRevision.SaveAsRevision
      Revisions.Add(Revisions.Last.Increment())
      Revisions.Current = Revisions.Last
      Save()
      onSavedAsRevision(EventArgs.Empty)
   End Sub
   
   Overloads Overrides Sub Load()
      updateRevisions(id.ToString)
      Load(Revisions.Last)
   End Sub
   
   Overloads Sub Load(revision As Revision) _
   Implements ICanBeRevisioned.Load
      Dim dto As Rae.Data.Access.BoxLoadDto
      dto = da.Retrieve(id.ToString, revision.Minor)
      Load(dto)
   End Sub
   
   Overloads Sub Load(dto As Rae.Data.Access.BoxLoadDto)
      loadDto(dto)
      Me.lastSavedState_ = Me.Clone()
   End Sub
   
   Overloads Sub Load(dbId As Integer)
      Dim dto As Rae.Data.Access.BoxLoadDto
      dto = da.Retrieve(dbId)
      Load(dto)
   End Sub
   
   Sub Delete()
      da.Delete(id.ToString)
   End Sub
   
   <Exclude()> _
   ReadOnly Property IsPersisted As Boolean _
   Implements IAmAwareOfPersistence.IsPersisted
      Get
         Return da.Exists(id.ToString(), Revisions.Current.Minor)
      End Get
   End Property


   Overloads Function Equals(other As BoxLoad) As Boolean _
   Implements IEquatable(Of BoxLoad).Equals
      Return reflector.are_equal(Of BoxLoad)(Me, other)
   End Function
   
   Function Clone() As BoxLoad _
   Implements ICloneable(Of BoxLoad).Clone
      Return reflector.clone(Of BoxLoad)(Me)
   End Function
   
   ''' <summary>
   ''' Converts box load object to a table.
   ''' </summary>
   Function ToTable() As DataTable
      ' create and save temporary clone object
      Dim temp As BoxLoad = Me.Clone()
      temp.id = New item_id("temp", "temp")
      temp.Save()
      ' retrieve temporary clone as table
      Dim boxLoadTable As DataTable = da.RetrieveTable(temp.DbId)
      ' deletes temporary row
      da.Delete(temp.DbId)

      Return boxLoadTable
   End Function
   
   
#Region " Internal"

   Private lastSavedState_ As BoxLoad
   Private revisions_ As RevisionList

   Private da As Rae.Data.Access.BoxLoadProjects
   
   Private Function toDto As Rae.Data.Access.BoxLoadDto
      Dim dto As New Rae.Data.Access.BoxLoadDto
      
      With dto
         .Id = Me.DbId
         .ItemId = Me.id.ToString
         .ItemRevision = Me.Revisions.Current.Minor 'Me.ItemRevision
         If Me.ProjectManager IsNot Nothing Then
            .ProjectId = Me.ProjectManager.Project.id.ToString
         End If
         .ProjectRevision = Me.Revisions.Current.Major
         ' START HERE:
         .RMWB = Me.RoomWetBulb
         
         .BlName = Me.name
         .Ambient = Me.Ambient
         .btnAllWallSn = Me.btnAllWallSn
         .btnAllWallSy = Me.btnAllWallSy
         .CeilingTot = Me.CeilingTotal
         .CExtTemp = Me.CExtTemp
         .Description = Me.Description
         .DockDoors = Me.DockDoors
         .TotDockDoors = Me.DockDoorsTotal
         .ExtTempW1 = Me.ExternalWallTemperature1
         .ExtTempW2 = Me.ExternalWallTemperature2
         .ExtTempW3 = Me.ExternalWallTemperature3
         .ExtTempW4 = Me.ExternalWallTemperature4
         .ExtTempW5 = Me.ExternalWallTemperature5
         .ExtTempW6 = Me.ExternalWallTemperature6
         .ExtWb = Me.ExternalWb
         .FExtTemp = Me.FExtTemp
         .FloorTot = Me.FloorTotal
         .ForkLift = Me.ForkLift
         .TotForkLift = Me.ForkLiftTotal
         .Height1 = Me.Height1
         .Height2 = Me.Height2
         .Height3 = Me.Height3
         .Height4 = Me.Height4
         .Height5 = Me.Height5
         .Height6 = Me.Height6
         .IAirChg = Me.IAirChg
         .IFactor = Me.IFactor
         .InfDb = Me.InfDb
         .InfWb = Me.InfWb
         .InsulC = Me.InsulC
         .InsulF = Me.InsulF
         .InsulW1 = Me.InsulW1
         .InsulW2 = Me.InsulW2
         .InsulW3 = Me.InsulW3
         .InsulW4 = Me.InsulW4
         .InsulW5 = Me.InsulW5
         .InsulW6 = Me.InsulW6
         .IVolume = Me.IVolume
         .KFactorW1 = Me.KFactor1
         .KFactorW2 = Me.KFactor2
         .KFactorW3 = Me.KFactor3
         .KFactorW4 = Me.KFactor4
         .KFactorW5 = Me.KFactor5
         .KFactorW6 = Me.KFactor6
         .KFactorC = Me.KFactorC
         .KFactorF = Me.KFactorF
         .KFactors = Me.KFactors
         .LoadTot = Me.LoadTotal
         .MotorHp = Me.MotorHp
         .MyCity = Me.MyCity
         .MyState = Me.MyState
         .OtherBtu = Me.OtherBtu
         .OtherTot = Me.OtherTotal
         .OtherType = Me.OtherType
         .People = Me.People
         .rdoRectangle = Me.rdoRectangle
         .RoomArea = Me.RoomArea
         .RoomNumber = Me.RoomNumber
         .RmTemp = Me.RoomTemperature
         .RoomVolume = Me.RoomVolume
         .RunVar = Me.RunVar
         .RunVarTot = Me.RunVarTotal
         .Rw1 = Me.Rw1
         .Rw2 = Me.Rw2
         .Rw3 = Me.Rw3
         .Rw4 = Me.Rw4
         .Rw5 = Me.Rw5
         .Rw6 = Me.Rw6
         .RwCeiling = Me.RwCeiling
         .RwFloor = Me.RwFloor
         .Safety = Me.Safety
         .SafetyTot = Me.SafetyTotal
         .SumInf = Me.SumInf
         .SumOther = Me.SumOther
         .SumProd = Me.SumProd
         .SumTot = Me.SumTotal
         .SumTran = Me.SumTran
         .ThickC = Me.ThickC
         .ThickF = Me.ThickF
         .ThickW1 = Me.ThickW1
         .ThickW2 = Me.ThickW2
         .ThickW3 = Me.ThickW3
         .ThickW4 = Me.ThickW4
         .ThickW5 = Me.ThickW5
         .ThickW6 = Me.ThickW6
         .TotInfil = Me.TotalInfil
         .TotOl = Me.TotalOl
         .TotOm = Me.TotalOm
         .TotOo = Me.TotalOo
         .TotOP = Me.TotalOP
         .TransTot = Me.TransTotal
         .txtImageCounter = Me.txtImageCounter
         .UserCapacity = Me.UserCapacity
         .UserCapacityChecked = Me.UserCapacityChecked
         .Wall1 = Me.Wall1
         .Wall2 = Me.Wall2
         .Wall3 = Me.Wall3
         .Wall4 = Me.Wall4
         .Wall5 = Me.Wall5
         .Wall6 = Me.Wall6
         .WallTot = Me.WallTotal
         .WattL = Me.WattL
      End With
      
      Return dto
   End Function
   
   Private Sub updateRevisions(itemId As String)
      Dim revs As List(Of Integer) = da.Revisions(itemId)
      Revisions.Clear()
      For Each rev As Integer In revs
         Revisions.Add(New Revision(0, rev))
      Next
   End Sub
   
   Private Sub loadDto(ByVal dto As Rae.Data.Access.BoxLoadDto)

      With dto
         DbId = .Id
         id = New item_id(.ItemId)

         updateRevisions(.ItemId)
         Revisions.Current = New Revision(.ProjectRevision, .ItemRevision)
         
         Me.name = .BlName

         Ambient = .Ambient
         btnAllWallSn = .btnAllWallSn
         btnAllWallSy = .btnAllWallSy
         CeilingTotal = .CeilingTot
         CExtTemp = .CExtTemp
         Description = .Description
         DockDoors = .DockDoors
         DockDoorsTotal = .TotDockDoors
         ExternalWallTemperature1 = .ExtTempW1
         ExternalWallTemperature2 = .ExtTempW2
         ExternalWallTemperature3 = .ExtTempW3
         ExternalWallTemperature4 = .ExtTempW4
         ExternalWallTemperature5 = .ExtTempW5
         ExternalWallTemperature6 = .ExtTempW6
         ExternalWb = .ExtWb
         FExtTemp = .FExtTemp
         FloorTotal = .FloorTot
         ForkLift = .ForkLift
         ForkLiftTotal = .TotForkLift
         Height1 = .Height1
         Height2 = .Height2
         Height3 = .Height3
         Height4 = .Height4
         Height5 = .Height5
         Height6 = .Height6
         IAirChg = .IAirChg
         IFactor = .IFactor
         InfDb = .InfDb
         InfWb = .InfWb
         InsulC = .InsulC
         InsulF = .InsulF
         InsulW1 = .InsulW1
         InsulW2 = .InsulW2
         InsulW3 = .InsulW3
         InsulW4 = .InsulW4
         InsulW5 = .InsulW5
         InsulW6 = .InsulW6
         'ItemRevision = .ItemRevision
         IVolume = .IVolume
         KFactor1 = .KFactorW1
         KFactor2 = .KFactorW2
         KFactor3 = .KFactorW3
         KFactor4 = .KFactorW4
         KFactor5 = .KFactorW5
         KFactor6 = .KFactorW6
         KFactorC = .KFactorC
         KFactorF = .KFactorF
         KFactors = .KFactors
         LoadTotal = .LoadTot
         MotorHp = .MotorHp
         MyCity = .MyCity
         MyState = .MyState
         OtherBtu = .OtherBtu
         OtherTotal = .OtherTot
         OtherType = .OtherType
         People = .People

         rdoRectangle = .rdoRectangle
         RoomArea = .RoomArea
         RoomNumber = .RoomNumber
         RoomTemperature = .RmTemp
         RoomVolume = .RoomVolume
         RoomWetBulb = .RMWB
         RunVar = .RunVar
         RunVarTotal = .RunVarTot
         Rw1 = .Rw1
         Rw2 = .Rw2
         Rw3 = .Rw3
         Rw4 = .Rw4
         Rw5 = .Rw5
         Rw6 = .Rw6
         RwCeiling = .RwCeiling
         RwFloor = .RwFloor
         Safety = .Safety
         SafetyTotal = .SafetyTot
         SumInf = .SumInf
         SumOther = .SumOther
         SumProd = .SumProd
         SumTotal = .SumTot
         SumTran = .SumTran
         ThickC = .ThickC
         ThickF = .ThickF
         ThickW1 = .ThickW1
         ThickW2 = .ThickW2
         ThickW3 = .ThickW3
         ThickW4 = .ThickW4
         ThickW5 = .ThickW5
         ThickW6 = .ThickW6
         TotalInfil = .TotInfil
         TotalOl = .TotOl
         TotalOm = .TotOm
         TotalOo = .TotOo
         TotalOP = .TotOP
         TransTotal = .TransTot
         txtImageCounter = .txtImageCounter
         UserCapacity = .UserCapacity
         UserCapacityChecked = .UserCapacityChecked
         Wall1 = .Wall1
         Wall2 = .Wall2
         Wall3 = .Wall3
         Wall4 = .Wall4
         Wall5 = .Wall5
         Wall6 = .Wall6
         WallTotal = .WallTot
         WattL = .WattL
      End With

   End Sub
   
#End Region
   
End Class

End NameSpace

'Property ItemRevision() As Integer
   '   Get
   '      Return itemRevision_
   '   End Get
   '   Set(ByVal value As Integer)
   '      itemRevision_ = value
   '   End Set
   'End Property : Protected itemRevision_ As Integer
   

   'Property ProjectRevision() As Integer
   '   Get
   '      Return projectRevision_
   '   End Get
   '   Set(value As Integer)
   '      projectRevision_ = value
   '   End Set
   'End Property : Protected projectRevision_ As Integer