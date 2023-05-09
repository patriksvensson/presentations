---
title: Polymorphism
---

<!------------------------------------------------------------------------------>
<!-- Polymorphism -->
<!------------------------------------------------------------------------------>

# Polymorphism <MarkerCSharp />

```csharp {1-4|6-12}
public interface IGreeter 
{
    string Greet();
}

public sealed class MicrosoftReactor : IGreeter
{
    public string Greet()
    {
        return "Hello from Microsoft Reactor!";
    }
}
```

---
hideInToc: true
---

# Polymorphism <MarkerRust />

```rust
pub trait Greeter
{
    fn greet(&self) -> String;
}
```

<div v-click>
<br />
```rust
pub struct MicrosoftReactor { }
```
</div>

<div v-click>
<br />
```rust
impl Greeter for MicrosoftReactor 
{
    fn greet(&self) -> String {
        "Hello from Microsoft Reactor!".to_string()
    }
}
```
</div>