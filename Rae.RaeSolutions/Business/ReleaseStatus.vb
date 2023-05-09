Namespace Rae.RaeSolutions.Business

   ''' <summary>
   ''' Release status.
   ''' </summary>
   Public Enum ReleaseStatus

      ''' <summary>
      ''' No selection is made
      ''' </summary>
      NotSet = 0

      ''' <summary>
      ''' Hold for Release
      ''' </summary>
      HR

      ''' <summary>
      ''' Production Release
      ''' </summary>
      PR

      ''' <summary>
      ''' Project, before it becomes an HR.
      ''' </summary>
      ''' <remarks>
      ''' Per Danny Groom
      ''' </remarks>
      Project

   End Enum

End Namespace