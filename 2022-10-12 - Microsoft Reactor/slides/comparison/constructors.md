---
title: Constructors
---

<!------------------------------------------------------------------------------>
<!-- Constructors -->
<!------------------------------------------------------------------------------>

# Constructors <MarkerCSharp />

```csharp {5-8|13}
public sealed class Foo
{
    public int Bar { get; }

    public Foo(int bar) 
    {
        Bar = bar;
    }
}

public static void Main()
{
    var foo = new Foo(32);
}
```

---
hideInToc: true
---

# Constructors <MarkerRust />

```rust {5-15|19|7-14}
pub struct Foo 
{
    pub bar: i32,
}

impl Foo 
{
    pub fn new(bar: i32) -> Foo 
    {
        Foo 
        {
            bar: bar,
        }
    }
}

pub fn main()
{
    let foo = Foo::new(32);
}
```

---
hideInToc: true
---

# Constructors <MarkerRust />

```rust {5-12}
pub struct Foo 
{
    pub bar: i32,
}

impl Foo 
{
    pub fn new(bar: i32) -> Self
    {
        Self { bar }
    }
}

pub fn main()
{
    let foo = Foo::new(32);
}
```