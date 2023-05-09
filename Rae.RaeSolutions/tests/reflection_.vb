imports rae.reflection

<TestClass> _
public class reflection_ : inherits test_base

public class some_class
   public name as string
end class

public structure some_structure
   public name as string
end structure

<TestMethod> _
sub can_copy_public_fields_from_structure
   dim bob as some_structure
   bob.name = "bob"
   
   dim clone = domain.clone(bob)
   assert(clone.name = bob.name)
end sub

<TestMethod> _
sub can_copy_public_fields_from_class
   dim bob = new some_class()
   bob.name = "bob"
   
   dim clone = domain.clone(bob)
   assert(clone.name = bob.name)
end sub

<TestMethod> _
sub cloned_structure_is_a_new_instance
   dim bob as some_structure
   bob.name = "bob"
   
   dim clone = domain.clone(bob)
   clone.name = "clone"
   
   assert(clone.name <> bob.name)
end sub

<TestMethod> _
sub returns_nothing_for_nothing
   dim bob = nothing
   
   dim clone = domain.clone(bob)
   assert(bob is nothing)
end sub

<TestMethod> _
sub when_string_and_number_fields_in_structure_are_equal_objects_are_equal
   dim bob as person
   bob.name = "bob" : bob.age = 29
   dim bob_2 = bob
   
   assert(domain.are_equal(bob, bob_2))
end sub

<TestMethod> _
sub when_string_field_is_not_equal_then_objects_are_not_equal
   dim bob as person : bob.name = "bob"
   dim susan as person : susan.name = "susan"
   assert(not domain.are_equal(bob, susan))
end sub

<TestMethod> _
sub when_number_field_is_not_equal_then_objects_are_not_equal
   dim bob as person : bob.age = 29
   dim susan as person : susan.age = 87
   assert(not domain.are_equal(bob, susan))
end sub


structure person
   public name as string
   public age as integer
end structure

end class
