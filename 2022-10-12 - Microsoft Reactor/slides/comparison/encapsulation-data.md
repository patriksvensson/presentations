---
title: Encapsulation of data
---

# Encapsulation of data <MarkerCSharp />

```csharp
public class Foo
{
    public int Bar { get; set; }
}
```

<div v-click>
<br />
```csharp
var foo = new Foo 
{ 
    Bar = 32, // Might be omitted
}
```
</div>

---
hideInToc: true
---

# Encapsulation of data <MarkerRust />

```rust
pub struct Foo 
{
    pub bar: i32,
}
```

<div v-click>
<br />
```rust
let foo = Foo { bar: 32 };
```

<p class="text-red-400">Struct members cannot be omitted!</p>

</div>

