### Asserting on the Number of Items in a Collection with NUnit Asserts

```csharp
var names = new[] { "Sarah", "Amrit", "Amanda", "Sarah" };
 
Assert.That(names, Has.Exactly(4).Items); // pass
Assert.That(names, Is.Empty); // fail
Assert.That(names, Is.Not.Empty); // pass
```

### Asserting That All Items in a Collection are Unique with NUnit Asserts
	
```csharp
Assert.That(names, Is.Unique); // fail - 2 Sarah items exist
```

### Asserting That An Item Does or Does Not Exist in a Collection with NUnit Asserts
```csharp
Assert.That(names, Contains.Item("Sarah")); // pass

// Alternative syntax
Assert.That(names, Does.Contain("Sarah")); // pass
Assert.That(names, Does.Not.Contain("Arnold")); // pass
```
### Asserting That An Item Appears a Specified Number Of Times in a Collection with NUnit Asserts


```csharp	
Assert.That(names, Has.Exactly(1).EqualTo("Sarah")); // fail
Assert.That(names, Has.Exactly(2).EqualTo("Sarah")); // pass
Assert.That(names, Has.Exactly(2).EqualTo("Sarah")
                      .And.Exactly(1).EqualTo("Amrit")); // pass
```

### Asserting That All Items In a Collections Satisfy a Predicate/Condition with NUnit Asserts


```csharp	
Assert.That(names, Is.All.Not.Null); // pass
Assert.That(names, Is.All.Contains("a")); // fail lowercase a
Assert.That(names, Is.All.Contains("a").IgnoreCase); // pass
Assert.That(names, Is.All.Matches<string>(name => name.ToUpperInvariant().Contains("A"))); // pass
Assert.That(names, Is.All.Matches<string>(name => name.Length > 4)); // pass
```

### Asserting That Only One Item In a Collection Satisfies a Predicate with NUnit Asserts

```csharp	
Assert.That(names, Has.Exactly(1).Matches<string>(name => name.Contains("mri"))); // pass
Assert.That(names, Has.Exactly(1).Matches<string>(name => name.Contains("ara"))); // fail (2 Sarah items exist)
```