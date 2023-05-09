Option Strict On
Option Explicit On 


Imports Color = System.Drawing.Color


Public Class MyColors

   Public Shared ReadOnly Property LightestBlue() As Color
      Get
         Return Color.FromArgb(231, 231, 254)
      End Get
   End Property

   Public Shared ReadOnly Property LighterBlue() As Color
      Get
         Return Color.FromArgb(211, 219, 250)
      End Get
   End Property

   Public Shared ReadOnly Property LightBlue() As Color
      Get
         Return Color.FromArgb(167, 197, 233)
      End Get
   End Property

   Public Shared ReadOnly Property MediumBlue() As Color
      Get
         Return Color.FromArgb(54, 95, 254)
      End Get
   End Property

   Public Shared ReadOnly Property Blue() As Color
      Get
         Return Color.FromArgb(1, 64, 231)
      End Get
   End Property

   Public Shared ReadOnly Property DarkBlue() As Color
      Get
         Return Color.FromArgb(3, 21, 180)
      End Get
   End Property

End Class


Public Class ColorManager

   Public Shared ReadOnly Property LighterBlue() As Color
      Get
         Return Color.FromArgb(235, 240, 249)
      End Get
   End Property

   Public Shared ReadOnly Property LightBlue() As Color
      Get
         Return Color.FromArgb(196, 219, 249)
      End Get
   End Property

   Public Shared ReadOnly Property MediumBlue() As Color
      Get
         Return Color.FromArgb(125, 165, 224)
      End Get
   End Property

   Public Shared ReadOnly Property DarkBlue() As Color
      Get
         Return Color.FromArgb(89, 135, 214)
      End Get
   End Property


   Public Shared ReadOnly Property HeaderBlue() As Color
      Get
         Return Color.FromArgb(66, 123, 210)
      End Get
   End Property


   Public Shared ReadOnly Property LightGreyBlue() As Color
      Get
         Return Color.FromArgb(203, 216, 235)
      End Get
   End Property

   Public Shared ReadOnly Property GreyBlue() As Color
      Get
         Return Color.FromArgb(127, 157, 185)
      End Get
   End Property

End Class
