option strict off

imports Microsoft.TeamFoundation.Client
imports Microsoft.TeamFoundation.Framework.Common
imports Microsoft.TeamFoundation.VersionControl.Client
imports System.IO


<TestClass>
public class update_ : inherits test_base

   <TestMethod>
   sub peform_update
      dim manager = new update_manager(update_config.tfs_uri)
      dim updates = manager.get_changes(#10/8/2010#)
      updates.ForEach( sub(x) x.file_paths.ForEach(sub(y) log(y)) )
   end sub

   <TestMethod>
   sub copy_files_to_new_folder_on_server
      dim manager = new update_manager(update_config.tfs_uri)
      dim updates = manager.get_changes(#10/8/2010#)

      dim new_folder_name = DateTime.Now.ToString("yyyy.MM.dd hh.mm.ss")
      dim path_to = new path_to
      dim new_folder_path = path_to.updates(new_folder_name)

      directory.CreateDirectory(new_folder_path)
      
      for each file_path in manager.file_paths
         file.copy(file_path, path_to.file(new_folder_path, file_path.file_name))
      next
      file.copy(path_to.bin("RAESolutions.exe"), path_to.file(new_folder_path, "RAESolutions.exe"))

      system.diagnostics.process.start("explorer.exe", new_folder_path)
   end sub

   <TestMethod>
   sub get_version_history_of_project
      dim uri = new uri("http://developertfs:8080")
      dim tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri)
      
      dim version_control = tfs.GetService(of VersionControlServer)()

      dim [from] = new DateVersionSpec(#1/27/2010#)
      dim [to] = new DateVersionSpec(#9/20/2010#)

      dim max_changesets = 50
      
      dim history = version_control.QueryHistory(
         "$/Solutions/Main/Rae.RaeSolutions",
         VersionSpec.Latest,
         0,
         RecursionType.Full,
         "CaseyJ",
         [from], [to], 
         max_changesets, true, true)

      for each item as ChangeSet in history
         dim changes = ""
         for each change as change in item.changes
            changes &= "-- " & change.item.ServerItem & rae.io.text.new_line
         next
         log(item.comment & ":" & item.changes.count)
         log(changes)
      next

      tfs.dispose
   end sub

   <TestMethod>
   sub determine_which_assembly_files_have_been_modified
      dim manager = new update_manager(update_config.tfs_uri)
      dim updates = manager.get_changes(#9/1/2010#)
      dim path_to = new path_to
      assert(updates.where(function(x) x.file_paths.contains(path_to.bin("Rae.RaeSolutions.dll"))).count = 1)
   end sub

   <TestMethod>
   sub determine_which_database_files_have_been_modified
      dim manager = new update_manager(update_config.tfs_uri)
      dim updates = manager.get_changes(#8/1/2010#)
      dim path_to = new path_to
      assert(updates.where(function(x) x.file_paths.contains(path_to.database("20a0capacitiesDEC17.mdb"))).count = 1)
   end sub

   <TestMethod>
   sub determine_which_report_files_have_been_modified
      dim manager = new update_manager(update_config.tfs_uri)
      dim updates = manager.get_changes(#9/1/2010#)
      dim path_to = new path_to
      assert(updates.where(function(x) x.file_paths.contains(path_to.report("unit_cooler_order_write_up_template.docx"))).count = 1)
   end sub

   <TestMethod>
   sub determine_which_drawing_report_files_have_been_modified
      dim manager = new update_manager(update_config.tfs_uri)
      dim updates = manager.get_changes(#9/1/2010#)
      dim path_to = new path_to
      assert(updates.where(function(x) x.file_paths.contains(path_to.unit_drawing("10-A.dxf"))).count = 1)
   end sub

   <TestMethod>
   sub determine_which_dll_references_have_been_modified
      dim manager = new update_manager(update_config.tfs_uri)
      dim updates = manager.get_changes(#8/29/2010#)
      dim path_to = new path_to
      assert(updates.where(function(x) x.file_paths.contains(path_to.dll_references("DocumentFormat.OpenXml.dll"))).count = 1)
   end sub

   <TestMethod>
   sub convert_project_path_to_dll_file_path
      dim project_path = "$\Solutions\Main\Rae.RaeSolutions"
      dim expected_dll_file_path = "c:\code\rae\solutions\Main\Rae.Solutions\bin\Rae.RaeSolutions.dll"

      dim changes = new project(project_path, #9/1/2010#)
      dim dll_file_path = changes.convert_project_path_to_assembly_file_path(project_path)
      assert(dll_file_path = expected_dll_file_path)
   end sub

   <TestMethod>
   sub determine_if_databases_have_changed
      dim path_to = new path_to
      path_to.use_source_control_paths

      dim uri = new uri(update_config.tfs_uri)
      dim tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri)
      
      dim version_control = tfs.GetService(of VersionControlServer)()

      dim [from] = new DateVersionSpec(#1/27/2010#)
      dim [to] = new DateVersionSpec(#9/20/2010#)

      dim max_changesets = 50
      
      dim history = version_control.QueryHistory(
         path_to.databases_folder_path,
         VersionSpec.Latest,
         0,
         RecursionType.Full,
         "CaseyJ",
         [from], [to], 
         max_changesets, true, true)

      for each item as ChangeSet in history
         dim changes = ""
         for each change as change in item.changes
            changes &= "-- " & change.item.ServerItem & rae.io.text.new_line
         next
         log(item.comment & ":" & item.changes.count)
         log(changes)
      next

      tfs.dispose
   end sub

end class

class path_to
   sub new
      set_paths("c:\code\rae\solutions")
   end sub

   sub new(use_source_control_paths as boolean)
      if use_source_control_paths then
         me.use_source_control_paths
      else
         set_paths("c:\code\rae\solutions")
      end if
   end sub

   public solutions_folder_path, raesolutions_folder_path, bin_folder_path as string
   public databases_folder_path, reports_folder_path, drawings_folder_path as string
   public dll_references_folder_path as string
   public update_folder_path as string

   sub set_paths(solutions_folder_path as string)
      me.solutions_folder_path = solutions_folder_path
      raesolutions_folder_path = path.combine(solutions_folder_path, "Main\Rae.Solutions")
      databases_folder_path = path.combine(raesolutions_folder_path, "Databases")
      reports_folder_path = path.combine(raesolutions_folder_path, "reports")
      drawings_folder_path = path.combine(raesolutions_folder_path, "Drawings\Drawings")
      bin_folder_path = path.combine(raesolutions_folder_path, "bin")
      dll_references_folder_path = path.combine(raesolutions_folder_path, "MyReferences")
      update_folder_path = "\\fileserver1\fileser1_e\update control\rae_solutions"
   end sub

   sub use_source_control_paths
      set_paths("$\Solutions")
   end sub

   function updates(folder_name as string) as string
      return path.combine(update_folder_path, folder_name)
   end function

   function file(folder_path as string, file_name as string) as string
      return path.combine(folder_path, file_name)
   end function

   function dll_references(file_name as string) as string
      return path.combine(dll_references_folder_path, file_name)
   end function

   function bin(file_name as string) as string
      return path.combine(bin_folder_path, file_name)
   end function

   function database(file_name as string) as string
      return path.combine(databases_folder_path, file_name)
   end function

   function report(file_name as string) as string
      return path.combine(reports_folder_path, file_name)
   end function

   function unit_drawing(file_name as string) as string
      return path.combine(path.combine(drawings_folder_path, "Unit\MasterDrawings"), file_name)
   end function
end class

class update_config
   public shared tfs_uri as string = "http://developertfs:8080"
end class

interface i_change
   property file_paths as list(of string)
   property changed as boolean
end interface

class changed_files_in_folder : implements i_change
   sub new(tfs_uri as string, folder_path as string, last_update as date, optional filter_by_extensions() as string = nothing)
      file_paths = new list(of string)

      dim query = new change_set_query(update_config.tfs_uri)
      dim change_sets = query.get_change_sets(folder_path, last_update)

      changed = false
      for each change_set in change_sets
         changed = true
         for each change in change_set.changes
            if filter_by_extensions isNot nothing
               for each ext in filter_by_extensions
                  if change.item.serverItem.extension = ext and not change.ChangeType = ChangeType.Delete then
                     if not file_paths.contains(change.item.serverItem) then file_paths.add(change.item.serverItem)
                     exit for
                  end if
               next
            else
               if not file_paths.contains(change.item.serverItem) then file_paths.add(change.item.serverItem)
            end if
         next
      next

      file_paths = convert_from_source_control_to_local_path(file_paths)
   end sub

   '$\Solutions\Main\Rae.Solutions\Databases
   'c:\code\rae\solutions\Main\Rae.Solutions\Databases
   private function convert_from_source_control_to_local_path(file_paths as list(of string)) as list(of string)
      for i=0 to file_paths.count-1
         file_paths(i) = file_paths(i).replace("$/Solutions", new path_to().solutions_folder_path).replace("/", "\")
      next
      return file_paths
   end function

   property changed as boolean implements i_change.changed
   property file_paths as list(of string) implements i_change.file_paths
end class

'dim query = new change_set_query(uri)
'query.get_change_sets("$\Solutions\Main\Rae.RaeSolutions", last_update)
class change_set_query
   private uri as string

   sub new(tfs_uri as string)
      uri = tfs_uri   
   end sub

   function get_change_sets(source_control_path as string, since as date) as IEnumerable(of ChangeSet)
      dim tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new uri(me.uri))
      dim version_control = tfs.GetService(of VersionControlServer)()

      dim [from] = new DateVersionSpec(since)
      dim [to] = new DateVersionSpec(DateTime.Now)
      dim max_changesets = 50
      
      dim history = version_control.QueryHistory(
         source_control_path,
         VersionSpec.Latest,
         0,
         RecursionType.Full,
         "",
         [from], [to], 
         max_changesets, true, true
      )

      dim change_sets = history.cast(of ChangeSet).ToArray

      tfs.dispose

      return change_sets
   end function
end class

class project : implements i_change

   sub new(project_path as string, last_update as date)
      'change_details = new list(of change_detail)
      file_paths = new list(of string)
      changed = false

      dim change_sets = new change_set_query(update_config.tfs_uri).get_change_sets(project_path, last_update) ' get_change_sets(project_path, last_update)
      if change_sets.count > 0 then
         'for each change_set in change_sets
         '   dim change_detail as project.change_detail
         '   change_detail.description = change_set.comment
         '   change_detail.modified_files = (from c in change_set.changes select c.item.serverItem).ToArray
         '   change_details.add(change_detail)
         'next
         file_paths.add( convert_project_path_to_assembly_file_path(project_path) )
         changed = true
      end if
   end sub

   property file_paths as list(of string) implements i_change.file_paths
   property changed as boolean implements i_change.changed
   'private change_details as list(of change_detail)
     
   structure change_detail
      public description as string
      public modified_files() as string
   end structure

   'private function get_change_sets(project_path as string, since as date) as IEnumerable(of ChangeSet)
   '   dim uri = new uri(update_config.tfs_uri)
   '   dim tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri)
   '   dim version_control = tfs.GetService(of VersionControlServer)()

   '   dim [from] = new DateVersionSpec(since)
   '   dim [to] = new DateVersionSpec(DateTime.Now)
   '   dim max_changesets = 50
   '   'not filtering by dates ???
   '   dim history = version_control.QueryHistory(
   '      project_path,
   '      VersionSpec.Latest,
   '      0,
   '      RecursionType.Full,
   '      "CaseyJ",
   '      [from], [to], 
   '      max_changesets, true, true
   '   )

   '   dim change_sets = new list(of ChangeSet)
   '   for each h in history
   '      dim change_set = ctype(h, ChangeSet)
   '      change_sets.add(change_set)
   '   next

   '   tfs.dispose

   '   return change_sets
   'end function

   function convert_project_path_to_assembly_file_path(project_path as string) as string
      dim file_name = project_path.after_last("\")
      return new path_to().bin(file_name & ".dll")
   end function
end class

module file_path_extensions
   <System.Runtime.CompilerServices.Extension>
   function after_last(file_path as string, character as char) as string
      return file_path.substring( file_path.lastIndexOf(character)+1,  file_path.length - file_path.lastIndexOf(character)-1 )
   end function

   <System.Runtime.CompilerServices.Extension>
   function extension(file_path as string) as string
      return file_path.after_last("."c)
   end function

   <System.Runtime.CompilerServices.Extension>
   function file_name(file_path as string) as string
      return path.GetFileName(file_path)
   end function

end module

class update_manager
   private uri as string

   sub new(tfs_uri as string)
      uri = tfs_uri
   end sub

   function get_changes(last_update as date) as list(of i_change)
      dim changes = new list(of i_change)
      
      dim project_paths = get_project_paths
      for each project_path in project_paths
         dim project = new project(project_path, last_update)
         if project.changed then changes.add(project)
      next

      dim path_to = new path_to(true)
      dim db = new changed_files_in_folder(uri, path_to.databases_folder_path, last_update, {"mdb"})
      if db.changed then changes.add(db)

      dim report = new changed_files_in_folder(uri, path_to.reports_folder_path, last_update, {"docx", "rpt"})
      if report.changed then changes.add(report)

      dim drawing = new changed_files_in_folder(uri, path_to.drawings_folder_path, last_update, {"dxf"})
      if drawing.changed then changes.add(drawing)

      dim dll_references = new changed_files_in_folder(uri, path_to.dll_references_folder_path, last_update, {"dll"})
      if dll_references.changed then changes.add(dll_references)

      file_paths = new list(of string)
      changes.ForEach(sub(x) file_paths.AddRange(x.file_paths))

      return changes
   end function

   public file_paths as list(of string)

   private function get_project_paths as list(of string)
      dim projects = new list(of string)
      dim root = "$\Solutions\Main\"
      projects.add(root & "Rae.DataAccess.EquipmentOptions")
      projects.add(root & "Rae.RaeSolutions")
      projects.add(root & "rae.reporting.beta")
      projects.add(root & "Rae.Security")
      projects.add(root & "RaeSolutions")
      projects.add(root & "StandardRefrigeration")

      root = "$\Solutions\Common\"
      projects.add(root & "Rae.Core")
      projects.add(root & "Rae.Data")
      projects.add(root & "Rae.Reporting")
      projects.add(root & "Rae.Ui")
      
      return projects
   end function
end class