Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Packaging
Imports System.IO

Imports wp = DocumentFormat.OpenXml.Drawing.Wordprocessing
Imports a = DocumentFormat.OpenXml.Drawing
Imports pic = DocumentFormat.OpenXml.Drawing.Pictures

Imports System.Runtime.CompilerServices

public module content_control_extensions
   <extension>
   function tag(block as SdtRun) as string
      return block.descendants(of tag).first.val
   end function

   <extension>
   sub set_text(block as SdtRun, text as string)
      block.descendants(of text).first.text = text
   end sub
end module

public module part_extensions
   <extension>
   sub add_image(image_part as ImagePart, image_file_path as string)
      using file_stream as new FileStream(image_file_path, FileMode.Open)
         image_part.feedData(file_stream)
      end using
   end sub
end module

public module element_extensions
   <extension>
   sub add_image(element as DocumentFormat.OpenXml.OpenXmlCompositeElement, image_file_path as string)
      dim id = "rId100"
      dim graphic_uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"

      dim image_file_name = new FileInfo(image_file_path).Name
      
      dim dimensions as dimensions
      using image = new system.drawing.bitmap(image_file_path)
         dimensions.width = (image.width / image.HorizontalResolution) * 914400L
         dimensions.height = (image.height / image.VerticalResolution) * 914400L
      end using

      dim extent = new wp.Extent() with {
         .Cx = dimensions.width,
         .Cy = dimensions.height
      }
      dim document_properties = new wp.DocProperties() with {
         .Id = 1,
         .Name = "Logo",
         .Description = image_file_name
      }
      dim nonvisual_picture_properties = new pic.NonVisualPictureProperties(
         new pic.NonVisualDrawingProperties() with {
            .Id = 0,
            .Name = image_file_name
         },
         new pic.NonVisualPictureDrawingProperties()
      )

      dim shape_properties = new pic.ShapeProperties(
         new a.Transform2D(
            new a.Offset() with { .X = 0L, .Y = 0L },
            new a.Extents() with {
               .Cx = dimensions.width,
               .Cy = dimensions.height
            }
         ),
         new a.PresetGeometry( new a.AdjustValueList() ) with { 
            .Preset = a.ShapeTypeValues.Rectangle
         }
      )
      

      dim graphic = new a.Graphic(
         new a.GraphicData(
            new pic.Picture(
               nonvisual_picture_properties,
               new pic.BlipFill(
                  new a.Blip() with { .Embed = id },
                  new a.Stretch( new a.FillRectangle() )
               ),
               shape_properties
            )
         ) with { .Uri = graphic_uri }
      )

      dim run = 
         new paragraph(
            new ParagraphProperties( new Justification() with {.Val = JustificationValues.Both } ),
            new run(
               new drawing(
                  new wp.Inline(
                     extent,
                     document_properties,
                     graphic
                  ) with {
                    .DistanceFromTop = 0,
                    .DistanceFromBottom = 0,
                    .DistanceFromLeft = 0,
                    .DistanceFromRight = 0
                  }
               )
            )
         )
      

      element.AppendChild(run)
      'ctype(element, body).ChildElements.ToList.Add(run)
      'element.ToList.Add(run)
   end sub

end module

module string_extensions
   <extension>
   function delete(text as string, text_to_delete as string) as string
      return text.replace(text_to_delete, "")
   end function
end module